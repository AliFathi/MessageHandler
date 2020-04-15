using MessageHandler.Api.MessageHandlers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MessageHandlerExtensions
    {
        public static IServiceCollection AddMessageHandler<TMessageHandler>(
            this IServiceCollection services,
            MessageType messageType
        )
            where TMessageHandler : class, IMessageHandler
        {
            MessageHandlerProvider.Register(messageType, typeof(TMessageHandler));
            services.AddScoped<TMessageHandler>();

            return services;
        }
    }
}
