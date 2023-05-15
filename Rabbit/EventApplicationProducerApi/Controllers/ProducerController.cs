using EventApplicationProducer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventApplicationProducer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerMessage _producerMessage;

        public ProducerController(IProducerMessage producerMessage)
        {
            _producerMessage = producerMessage;
        }

        [HttpPut(Name = "publish-message")]
        public async Task<ActionResult> PublishMessage([FromBody] string MessasgeContent)
        {
            var result = await _producerMessage.PostMessage(MessasgeContent);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
