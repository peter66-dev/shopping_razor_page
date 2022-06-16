using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingAssignment_SE151263.DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                }
                return instance;
            }
        }

        public bool CheckExist(string orderId, int productId)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                OrderDetail tmp = context.OrderDetails.SingleOrDefault(o => o.OrderId.Trim().Equals(orderId) && o.ProductId == productId);
                check = tmp != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error at CheckExist: " + ex.Message);
            }
            return check;
        }

        public void DeleteOrder(string orderId)
        {
            try
            {
                var context = new NorthwindCopyDBContext();
                List<OrderDetail> od = context.OrderDetails.Where(o => o.OrderId.Trim().Equals(orderId)).ToList();
                context.OrderDetails.RemoveRange(od);
            }
            catch (Exception ex)
            {
                throw new Exception("Error at DeleteOrder: " + ex.Message);
            }
        }

        public List<OrderDetail> GetListByProductID(int productId)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            try
            {
                var context = new NorthwindCopyDBContext();
                list = context.OrderDetails.Where(o => o.ProductId == productId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error at GetListByProductID: " + ex.Message);
            }
            return list;
        }
    }
}
