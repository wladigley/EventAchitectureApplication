using EventApplicationConsumer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EventApplicationConsumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerMessageController : ControllerBase
    {
        private readonly IConsumerMessage _consumerMessage;
        public ConsumerMessageController(IConsumerMessage consumerMessage)
        {
            _consumerMessage = consumerMessage;
        }
        [HttpGet(Name = "get-allMessage")]
        public ActionResult GetAllMessage()
        {
            var result = _consumerMessage.GetAllMessage();
            return Ok(result);
        }
    }
}
