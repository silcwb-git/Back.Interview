using Back.Interview.Application.Services;
using Microsoft.Extensions.Logging;

namespace Back.Interview.Infrastructure.Services
{
    public class ConcurrencyService : IConcurrencyService
    {
        private readonly ILogger<ConcurrencyService> _logger;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(10);

        public ConcurrencyService(ILogger<ConcurrencyService> logger)
        {
            _logger = logger;
        }

        public async Task<T> ExecuteWithLimitAsync<T>(Func<Task<T>> operation, string operationName)
        {
            bool acquired = await _semaphore.WaitAsync(TimeSpan.FromSeconds(30));
            
            if (!acquired)
            {
                _logger.LogWarning("Timeout em {OperationName}", operationName);
                throw new InvalidOperationException("Muitas requisições simultâneas");
            }

            try
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;
                _logger.LogInformation("Thread {ThreadId}: Iniciando {OperationName}", threadId, operationName);
                
                return await operation();
            }
            finally
            {
                _semaphore.Release();
                _logger.LogInformation("Thread {ThreadId}: Finalizando {OperationName}", 
                    Thread.CurrentThread.ManagedThreadId, operationName);
            }
        }
    }
}