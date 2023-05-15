using EventApplicationConsumer.Service.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventApplicationConsumer.Service
{
    public class ConsumerEventNotification : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName = "event-application";
        private readonly string _nomeFila = "envent-notification-queue";
        private readonly IConsumerMessage _consumerMessage;
        public ConsumerEventNotification(IConsumerMessage consumerMessage)
        {
            _consumerMessage = consumerMessage;

            _connection = new ConnectionFactory() { HostName = "localhost", Port = 5672 }.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);
            _nomeFila = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _nomeFila, exchange: _exchangeName, routingKey: "");
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body;
                var mensagem = Encoding.UTF8.GetString(body.ToArray());
                _consumerMessage.ReceiveNotificationMessage(mensagem);
            };
            _channel.BasicConsume(queue: _nomeFila, autoAck: true, consumer: consumer);
            
            return Task.CompletedTask;
        }
    }
}
