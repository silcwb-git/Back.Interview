using Back.Interview.Domain.Entities;
using Back.Interview.Domain.Repositories;

namespace Back.Interview.Infrastructure.Repositories
{
    public class DataInterviewRepository : IDataInterviewRepository
    {
        private readonly ILogger<DataInterviewRepository> _logger;

        public DataInterviewRepository(ILogger<DataInterviewRepository> logger)
        {
            _logger = logger;
        }

        public async Task<Interview?> GetDataAsync()
        {
            _logger.LogInformation("Buscando dados da entrevista no repositório");
            
            var interview = new Interview
            {
                Id = 1,
                Name = "Test",
                Status = "Ativo"
            };

            return await Task.FromResult(interview);
        }
    }
}