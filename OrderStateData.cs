using Automatonymous;
using System;

namespace rabbitmq_saga.StateMachine
{
    public class OrderStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? OrderCreationDateTime { get; set; }
        public DateTime? OrderCancelDateTime { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentCardNumber { get; set; }
        public string ProductName { get; set; }
    }
}
