using MassTransit;
using order_ms.Infra;
using rabbitmq_message.Events;
using System.Threading.Tasks;

namespace order_ms.Consumers
{
    public class OrderCancelledConsumer : IConsumer<IOrderCancelEvent>
    {
        private readonly IOrderDataAccess _orderDataAccess;

        public OrderCancelledConsumer(IOrderDataAccess orderDataAccess)
        {
            _orderDataAccess = orderDataAccess;
        }

        public async Task Consume(ConsumeContext<IOrderCancelEvent> context)
        {
            var data = context.Message;
            _orderDataAccess.DeleteOrder(data.OrderId);
        }
    }
}
