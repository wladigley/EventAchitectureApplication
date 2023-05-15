namespace EventApplicationConsumer.Service.Interfaces
{
    public interface IConsumerMessage
    {
        bool ReceiveNotificationMessage(string message);
        List<string> GetAllMessage();
    }
}
