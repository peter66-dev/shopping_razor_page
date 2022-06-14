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
    }
}
