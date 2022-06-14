using ShoppingAssignment_SE151263.DataAccess;
using System.Collections.Generic;

namespace ShoppingAssignment_SE151263.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public double GetTotal(List<Order> list) => OrderDAO.Instance.GetTotal(list);
    }
}
