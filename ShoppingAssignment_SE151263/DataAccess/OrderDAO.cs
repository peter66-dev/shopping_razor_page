using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingAssignment_SE151263.DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();

        private OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                }
                return instance;
            }
        }

        public double GetTotal(List<Order> list)
        {
            double total = 0;
            try
            {
                var context = new NorthwindCopyDBContext();
                foreach (var o in list)
                {
                    total += (double)o.Freight.Value;
                    List<OrderDetail> list2 = context.OrderDetails.Where(ord => ord.OrderId.Equals(o.OrderId)).ToList();
                    if (list2.Count != 0)
                    {
                        foreach (var od in list2)
                        {
                            total += (double)(od.Quantity * od.UnitPrice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at GetTotal: " + ex.Message);
            }
            return total;
        }

        public List<Order> Statistic(DateTime date)
        {
            List<Order> list = new List<Order>();
            try
            {
                var context = new NorthwindCopyDBContext();
                list = context.Orders.Where(o => o.OrderDate.Value.CompareTo(date) == 0).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error at Statistic: " + ex.Message);
            }
            return list;
        }

        public List<Order> Statistic(DateTime start, DateTime end)
        {
            List<Order> list = new List<Order>();
            try
            {
                var context = new NorthwindCopyDBContext();
                list = context.Orders.Where(o => o.OrderDate.Value.CompareTo(start) >= 0 && o.OrderDate.Value.CompareTo(end) <= 0).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error at Statistic: " + ex.Message);
            }
            return list;
        }

        public List<Order> GetOrdersByCustomerID(string customerID)
        {
            List<Order> list = new List<Order>();
            try
            {
                var context = new NorthwindCopyDBContext();
                list = context.Orders.Where(o => o.CustomerId.Trim().Equals(customerID.Trim())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error at GetOrdersByCustomerID: " + ex.Message);
            }
            return list;
        }

        public void DeleteOrder(string customerID)
        {
            List<Order> list = new List<Order>();
            try
            {
                var context = new NorthwindCopyDBContext();
                list = context.Orders.Where(o => o.CustomerId.Trim().Equals(customerID.Trim())).ToList();
                context.Orders.RemoveRange(list);
            }
            catch (Exception ex)
            {
                throw new Exception("Error at DeleteOrder: " + ex.Message);
            }
        }
    }
}
