using Back.Interview.Domain.Entities;

namespace Back.Interview.Domain.Repositories
{
    public interface IDataInterviewRepository
    {
        Task<Interview?> GetDataAsync();
    }
}