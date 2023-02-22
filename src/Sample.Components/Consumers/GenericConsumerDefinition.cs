namespace Sample.Components.Consumers;

using MassTransit;


public class GenericConsumerDefinition<T> :
    ConsumerDefinition<T> where T : class, IConsumer
{
    readonly IServiceProvider _provider;

    public GenericConsumerDefinition(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<T> consumerConfigurator)
    {
        // endpointConfigurator.UseMessageRetry(r => r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000));

        endpointConfigurator.UseMongoDbOutbox(_provider);
    }
}