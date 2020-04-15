using System.Threading.Tasks;

namespace MessageHandler.Api.MessageHandlers
{
    public class FirstMessageHandler : BaseMessagehandler<FirstMessage>
    {
        public override Task<string> HandleMessageAsync(FirstMessage message)
        {
            return Task.FromResult("First: " + message.Name);
        }
    }

    public class FirstMessage : IMessage
    {
        public string Name { get; set; }
    }
}
