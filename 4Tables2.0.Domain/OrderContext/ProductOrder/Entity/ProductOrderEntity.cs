﻿using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;
using _4Tables2._0.Domain.ProductDomain.Entity;

namespace _4Tables2._0.Domain.OrderContext.ProductOrder.Entity
{
    public class ProductOrderEntity : BaseEntity
    {
        public ProductOrderEntity(long productId, short productQuantity, string productName, decimal productPrice)
        {
            ProductId = productId;
            Quantity = productQuantity;
            ProductName = productName;

            _productPrice = productPrice;
        }

        protected ProductOrderEntity() { }

        public long Id { get; private set; }
        public virtual ProductEntity Product { get; private set; }
        public long ProductId { get; private set; }
        public ReceivedOrderEntity ReceivedOrder { get; private set; }
        public long SimpleOrderId { get; private set; }
        public short Quantity { get; private set; }
        public string ProductName { get; private set; }

        public decimal _productPrice { get; private set; }

        public static ProductOrderEntity Create(long productId, short productQuantity, string productName, decimal productPrice)
        {
            return new ProductOrderEntity(productId, productQuantity, productName, productPrice);

        }

        public void IncrementQuantity(short quantity)
        {
            Quantity += quantity;
        }
    }
}
