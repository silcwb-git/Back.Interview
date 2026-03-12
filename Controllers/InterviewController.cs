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

        public InterviewController(ILogger<InterviewController> logger, IGetInterviewUseCase getInterviewUseCase)
        {
            _logger = logger;
            _getInterviewUseCase = getInterviewUseCase;
        }

        [HttpGet(Name = "GetInterview")]
        public async Task<IActionResult> GetInterviewAsync()
        {
            _logger.LogInformation("Chegamos na controller e estamos no metodo GetInterviewAsync");
            
            var data = await _getInterviewUseCase.ExecuteAsync();
            
            if (data == null)
                return NotFound("Entrevista não encontrada");

            return Ok(data.ToString()); // Retorna "1 - Test - Ativo"
        }
    }
}