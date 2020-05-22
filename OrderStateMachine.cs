using Automatonymous;
using rabbitmq_message.Events;
using rabbitmq_message.StateMachine.Messages;
using System;

namespace rabbitmq_saga.StateMachine
{
    public class OrderStateMachine :
       MassTransitStateMachine<OrderStateData>
    {
        public OrderStateMachine()
        {
            Event(() => OrderStartedEvent, x => x.CorrelateById(m => m.Message.OrderId));

            Event(() => OrderCancelledEvent, x => x.CorrelateById(m => m.Message.OrderId));

            InstanceState(x => x.CurrentState);

            Initially(
               When(OrderStartedEvent)
                .Then(context =>
                {
                    context.Instance.OrderCreationDateTime = DateTime.Now;
                    context.Instance.OrderId = context.Data.OrderId;
                    context.Instance.PaymentCardNumber = context.Data.PaymentCardNumber;
                    context.Instance.ProductName = context.Data.ProductName;
                })
               .TransitionTo(OrderStarted)
               .Publish(context => new OrderValidateEvent(context.Instance)));

            During(OrderStarted,
                When(OrderCancelledEvent)
                    .Then(context => context.Instance.OrderCancelDateTime =
                        DateTime.Now)
                     .TransitionTo(OrderCancelled)
                
              );
        }

        public State OrderStarted { get; private set; }
        public State OrderCancelled { get; private set; }
        public Event<IOrderStartedEvent> OrderStartedEvent { get; private set; }
        public Event<IOrderCancelEvent> OrderCancelledEvent { get; private set; }
    }
}
