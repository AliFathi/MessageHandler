using System.Threading.Tasks;

namespace MessageHandler.Api.MessageHandlers
{
    public class DefaultMessageHandler : BaseMessagehandler<DefaultMessage>
    {
        public override Task<string> HandleMessageAsync(DefaultMessage message)
        {
            return Task.FromResult("Default");
        }
    }

    public class DefaultMessage : IMessage
    {
    }
}
