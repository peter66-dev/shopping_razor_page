using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Collections.Generic;

namespace ShoppingAssignment_SE151263.Repository
{
    public interface IOrderRepository
    {
        public double GetTotal(List<Order> list);

        public List<Order> Statistic(DateTime date);

        public List<Order> Statistic(DateTime start, DateTime end);

        public List<Order> GetOrdersByCustomerID(string customerID);

        public void DeleteOrder(string customerID);

    }
}