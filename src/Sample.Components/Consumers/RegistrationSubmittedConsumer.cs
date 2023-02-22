using MassTransit.MongoDbIntegration;
using MongoDB.Driver;

namespace Sample.Components.Consumers;

using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services;


public class RegistrationSubmittedConsumer :
    IConsumer<RegistrationSubmitted>
{
    readonly ILogger<RegistrationSubmittedConsumer> _logger;
    readonly IPublishEndpoint _publishEndpoint;

    public RegistrationSubmittedConsumer(ILogger<RegistrationSubmittedConsumer> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<RegistrationSubmitted> context)
    {
        _logger.LogInformation("Consuming RegistrationSubmitted");
        await _publishEndpoint.Publish(new RegistrationValidated { RegistrationId = context.Message.RegistrationId });
    }
}