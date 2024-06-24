using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.Base.Interfaces;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;
using System.Net;

namespace _4Tables2._0.Domain.OrderContext.Order.Entity
{
    public class OrderEntity : BaseEntity, IAgreggateRoot
    {
        public OrderEntity(short tableNumber)
        {
            TableNumber = tableNumber;
        }

        protected OrderEntity() { }

        private List<ReceivedOrderEntity> _receveidOrders = new();

        public long Id { get; private set; }
        public decimal Total { get; private set; } = 0;
        public int TableNumber { get; private set; }
        public TableEntity Table { get; private set; }
        public IReadOnlyCollection<ReceivedOrderEntity> ReceivedOrders => _receveidOrders;

        public static OrderEntity Create(short tableNumber)
        {
            return new OrderEntity(tableNumber);
        }

        public OrderEntity PullReceivedOrder(ReceivedOrderEntity simpleOrder)
        {
            _receveidOrders.Add(simpleOrder); return this;
        }
        
        public void CalculateTotal(decimal total)
        {
            Total += total;
        }

        public bool OrderTableIsEqualReceivedOrderTable(short receivedOrderTable)
        {
            return this.TableNumber.Equals(receivedOrderTable);
        }
    }
}
