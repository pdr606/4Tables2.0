using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.OrderContext.Order.Entity;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;
using System.Text.Json.Serialization;

namespace _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity
{
    public class ReceivedOrderEntity : BaseEntity
    {
        public ReceivedOrderEntity(string? observation, int table)
        {
            Observation = observation;
            Table = table;
        }

        protected ReceivedOrderEntity() { }

        private List<ProductOrderEntity> _productOrders = new();

        public long Id { get; private set; }
        public string? Observation { get; private set; } = string.Empty;
        public OrderEntity Order { get; private set; }
        public long OrderId { get; private set; }
        public int Table { get; private set; }
        public IReadOnlyCollection<ProductOrderEntity> ProductOrders => _productOrders;

        public static ReceivedOrderEntity Create(string? observation, int table)
        {
            return new ReceivedOrderEntity(observation, table);
        }

        public ReceivedOrderEntity PullOrderId(long orderId)
        {
            OrderId = orderId; return this;
        }

        public ReceivedOrderEntity PullOrder(OrderEntity order)
        {
            Order = order; return this;
        }

        public ReceivedOrderEntity PullProductOrder(List<ProductOrderEntity> productOder)
        {
            this._productOrders.AddRange(productOder); return this;
        }
    }
}
