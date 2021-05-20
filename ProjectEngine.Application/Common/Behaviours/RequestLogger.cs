
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using ProjectEngine.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEngine.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
       // private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger/*, ICurrentUserService currentUserService*/)
        {
            _logger = logger;
           // _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;
           // _currentUserService.UserId {@UserId}
            _logger.LogInformation("Project Engine Request: {Name} {@Request}", 
                name, request);

            return Task.CompletedTask;
        }
    }
}
