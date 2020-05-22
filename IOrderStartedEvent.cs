using System;

namespace rabbitmq_message.StateMachine.Messages
{
    public interface IOrderStartedEvent
    {
        public Guid OrderId { get;  }
        public string PaymentCardNumber { get; }
        public string ProductName { get; }
    }
}
