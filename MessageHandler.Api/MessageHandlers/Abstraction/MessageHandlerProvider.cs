using System.Collections.Generic;

namespace MessageHandler.Api.MessageHandlers
{
    public interface IMessageHandlerProvider
    {
        IMessageHandler GetHandler(MessageType messageType);
    }

    public class MessageHandlerProvider : IMessageHandlerProvider
    {
        private readonly System.IServiceProvider _serviceProvider;
        private static readonly Dictionary<MessageType, System.Type> _typeStore = new Dictionary<MessageType, System.Type>();

        public MessageHandlerProvider(System.IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMessageHandler GetHandler(MessageType messageType)
        {
            if (_typeStore.TryGetValue(messageType, out System.Type handlerType))
                return _serviceProvider.GetService(handlerType) as IMessageHandler;

            if (_typeStore.TryGetValue(MessageType.Unknwon, out System.Type defaultHandlerType))
                return _serviceProvider.GetService(defaultHandlerType) as IMessageHandler;

            return null;
        }

        public static void Register(MessageType messageType, System.Type handlerType)
        {
            _typeStore.TryAdd(messageType, handlerType);
        }
    }
}
