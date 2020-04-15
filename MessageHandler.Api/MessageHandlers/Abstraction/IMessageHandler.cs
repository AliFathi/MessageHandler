using System.Linq;
using System.Threading.Tasks;

namespace MessageHandler.Api.MessageHandlers
{
    public interface IMessageHandler
    {
        Task<string> HandleMessageAsync(string jsonMessage);
    }

    public interface IMessageHandler<TMessage> where TMessage : IMessage
    {
        Task<string> HandleMessageAsync(TMessage message);
    }

    public abstract class BaseMessagehandler<TMessage> : IMessageHandler, IMessageHandler<TMessage> where TMessage : IMessage
    {
        public Task<string> HandleMessageAsync(string jsonMessage)
        {
            var handlerType = this.GetType();
            var genericMsgType = handlerType.BaseType.GenericTypeArguments[0];
            var genericMsg = ConvertType(jsonMessage, genericMsgType);
            var method = handlerType.GetMethods().First(m => m.IsDefined(typeof(FlagAttribute), inherit: true));

            var result = method.Invoke(this, new object[] { genericMsg });
            return result as Task<string>;
        }

        [Flag]
        public abstract Task<string> HandleMessageAsync(TMessage message);

        private object ConvertType(string jsonInput, System.Type destinationType)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonInput, destinationType);
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal class FlagAttribute : System.Attribute { }
}
