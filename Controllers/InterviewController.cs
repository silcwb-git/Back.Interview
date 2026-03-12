using Back.Interview.Application.Services;
using Back.Interview.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Back.Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterviewController : ControllerBase
    {
        private readonly ILogger<InterviewController> _logger;
        private readonly IGetInterviewUseCase _getInterviewUseCase;
        private readonly IConcurrencyService _concurrencyService;

        public InterviewController(
            ILogger<InterviewController> logger, 
            IGetInterviewUseCase getInterviewUseCase,
            IConcurrencyService concurrencyService)
        {
            _logger = logger;
            _getInterviewUseCase = getInterviewUseCase;
            _concurrencyService = concurrencyService;
        }

        [HttpGet(Name = "GetInterview")]
        public async Task<IActionResult> GetInterviewAsync()
        {
            try
            {
                var data = await _concurrencyService.ExecuteWithLimitAsync(
                    () => _getInterviewUseCase.ExecuteAsync(),
                    "GetInterview"
                );
                
                if (data == null)
                    return NotFound("Entrevista não encontrada");

                return Ok(data.ToString());
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(429, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar GetInterviewAsync");
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}