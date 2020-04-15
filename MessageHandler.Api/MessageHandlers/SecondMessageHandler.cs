using System.Threading.Tasks;

namespace MessageHandler.Api.MessageHandlers
{
    public class SecondMessageHandler : BaseMessagehandler<SecondMessage>
    {
        public override Task<string> HandleMessageAsync(SecondMessage message)
        {
            return Task.FromResult("Second: " + message.Id);
        }
    }

    public class SecondMessage : IMessage
    {
        public int Id { get; set; }
    }
}
