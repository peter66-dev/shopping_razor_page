using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Collections.Generic;

namespace ShoppingAssignment_SE151263.Repository
{
    public interface IOrderDetailRepository
    {
        public bool CheckExist(string orderId, int productId);

        public void DeleteOrder(string orderId);

        public List<OrderDetail> GetListByProductID(int productId);

    }
}