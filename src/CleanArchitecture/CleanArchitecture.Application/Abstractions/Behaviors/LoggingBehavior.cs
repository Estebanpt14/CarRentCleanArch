using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TResquest, TResponse>(ILogger<TResquest> logger)
        : IPipelineBehavior<TResquest, TResponse>
        where TResquest : IBaseCommand
    {
        private readonly ILogger<TResquest> _logger = logger;

        public async Task<TResponse> Handle(
            TResquest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken
        )
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation($"Executing the command request: {name}");
                var result = await next();
                _logger.LogInformation($"The command {name} wass successfully executed");

                return result;
            }
            catch (System.Exception exception)
            {
                _logger.LogError(exception, $"The command {name} had errors");
                throw;
            }
        }
    }
}