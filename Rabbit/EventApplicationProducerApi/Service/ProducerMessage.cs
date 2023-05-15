using EventApplicationProducer.Service.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EventApplicationProducer.Service
{
    public class ProducerMessage : IProducerMessage
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName = "event-application";

        public ProducerMessage()
        {
            _connection = new ConnectionFactory() { HostName = "localhost", Port = 5672 }.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare( exchange: _exchangeName, type: ExchangeType.Fanout);

        }
        public Task<bool> PostMessage(string message)
        {
            var messagejson = JsonSerializer.Serialize(message);
            var messageBody = Encoding.UTF8.GetBytes(messagejson);
            _channel.BasicPublish( exchange: _exchangeName, routingKey: "", basicProperties: null, body: messageBody);

            return Task.FromResult(true);
        }
    }
}
