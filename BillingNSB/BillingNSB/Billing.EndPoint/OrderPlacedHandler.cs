using Billing.Contracts.Events;
using NServiceBus;
using NServiceBus.Logging;
using Sales.Contracts.Events;
using System.Threading.Tasks;

namespace Billing.EndPoint
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlacedEvent>
    {
        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");
            var orderBilled = new OrderBilledEvent
            {
                OrderId = message.OrderId
            };
            return context.Publish(orderBilled);
        }
    }
}
