namespace EventApplicationProducer.Service.Interfaces
{
    public interface IProducerMessage
    {
        Task<bool> PostMessage(string message);
    }
}
