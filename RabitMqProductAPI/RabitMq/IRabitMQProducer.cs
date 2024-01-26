namespace RabitMqProductAPI.RabitMq
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
