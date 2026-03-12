using Back.Interview.Domain.Entities;
using Back.Interview.Domain.Repositories;

namespace Back.Interview.Application.UseCases
{
    public interface IGetInterviewUseCase
    {
        Task<Interview?> ExecuteAsync();
    }

    public class GetInterviewUseCase : IGetInterviewUseCase
    {
        private readonly IDataInterviewRepository _repository;
        private readonly ILogger<GetInterviewUseCase> _logger;

        public GetInterviewUseCase(IDataInterviewRepository repository, ILogger<GetInterviewUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Interview?> ExecuteAsync()
        {
            _logger.LogInformation("Executando use case GetInterview");
            var data = await _repository.GetDataAsync();
            return data;
        }
    }
}