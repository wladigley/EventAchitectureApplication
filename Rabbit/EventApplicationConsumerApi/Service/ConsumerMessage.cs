using EventApplicationConsumer.Service.Interfaces;

namespace EventApplicationConsumer.Service
{
    public class ConsumerMessage : IConsumerMessage
    {
        private readonly List<string> _FakeDataBase = new();
        public bool ReceiveNotificationMessage(string message)
        {
            _FakeDataBase.Add(message);
            return true;
        }

        public List<string> GetAllMessage()
        {
            return _FakeDataBase.ToList();
        }

    }
}
