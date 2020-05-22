namespace rabbitmq_message.BusConfiguration
{
    public class BusConstants
    {
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string OrderQueue = "validate-order-queue";
        public const string SagaBusQueue = "saga-bus-queue";
        public const string StartOrderQueue = "start-order";
    }
}
