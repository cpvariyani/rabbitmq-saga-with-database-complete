using MassTransit;
using rabbitmq_message.Events;
using System.Threading.Tasks;

namespace stock_ms
{
    public class OrderValidateConsumer :
      IConsumer<IOrderValidateEvent>
    {
        public async Task Consume(ConsumeContext<IOrderValidateEvent> context)
        {
            var data = context.Message;

            if (data.PaymentCardNumber.Contains("test"))
            {
                await context.Publish<IOrderCancelEvent>(
          new { OrderId = context.Message.OrderId, PaymentCardNumber = context.Message.PaymentCardNumber });
            }
            else
            {
                // send to next microservice
            }

        }
    }
}
