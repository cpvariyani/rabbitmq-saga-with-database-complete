using rabbitmq_message.Events;
using System;

namespace rabbitmq_saga.StateMachine
{
    public class OrderValidateEvent : IOrderValidateEvent
    {
        private readonly OrderStateData orderSagaState;
        public OrderValidateEvent(OrderStateData orderStateData)
        {
            this.orderSagaState = orderStateData;
        }

        public Guid OrderId => orderSagaState.OrderId;
        public string PaymentCardNumber => orderSagaState.PaymentCardNumber;
        public string ProductName => orderSagaState.ProductName;
    }
}
