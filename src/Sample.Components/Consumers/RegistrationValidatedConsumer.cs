using MassTransit;
using Microsoft.Extensions.Logging;

namespace Sample.Components.Consumers;

public class RegistrationValidatedConsumer : IConsumer<RegistrationValidated>
{
    private readonly ILogger<RegistrationValidatedConsumer> _logger;

    public RegistrationValidatedConsumer(ILogger<RegistrationValidatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RegistrationValidated> context)
    {
        _logger.LogInformation("Consuming RegistrationValidated");
        
        return Task.CompletedTask;
    }
}