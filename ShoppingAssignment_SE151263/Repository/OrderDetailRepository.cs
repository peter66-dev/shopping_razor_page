using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Collections.Generic;

namespace ShoppingAssignment_SE151263.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public bool CheckExist(string orderId, int productId) => OrderDetailDAO.Instance.CheckExist(orderId, productId);

        public void DeleteOrder(string orderId) => OrderDetailDAO.Instance.DeleteOrder(orderId);
    }
}
