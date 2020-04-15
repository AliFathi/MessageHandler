using MessageHandler.Api.MessageHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MessageHandler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotifyController : ControllerBase
    {
        private readonly IMessageHandlerProvider _provider;

        public NotifyController(IMessageHandlerProvider handlerProvider)
        {
            _provider = handlerProvider;
        }

        [HttpPost("{msgType}")]
        public async Task<IActionResult> Send(
            MessageType msgType,
            [FromBody]System.Text.Json.JsonElement message
        )
        {
            var json = message.ToString();
            var obj = await _provider.GetHandler(msgType)
                .HandleMessageAsync(json);

            return Ok(obj);
        }
    }
}
