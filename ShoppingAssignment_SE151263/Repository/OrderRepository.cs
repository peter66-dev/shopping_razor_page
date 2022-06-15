using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Collections.Generic;

namespace ShoppingAssignment_SE151263.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public double GetTotal(List<Order> list) => OrderDAO.Instance.GetTotal(list);

        public List<Order> Statistic(DateTime date) => OrderDAO.Instance.Statistic(date);

        public List<Order> Statistic(DateTime start, DateTime end) => OrderDAO.Instance.Statistic(start, end);

        public List<Order> GetOrdersByCustomerID(string customerID) => OrderDAO.Instance.GetOrdersByCustomerID(customerID);

        public void DeleteOrder(string customerID) => OrderDAO.Instance.DeleteOrder(customerID);
    }
}
