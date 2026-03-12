namespace Back.Interview.Application.Services
{
    public interface IConcurrencyService
    {
        Task<T> ExecuteWithLimitAsync<T>(Func<Task<T>> operation, string operationName);
    }
}