using ShoppingAssignment_SE151263.DataAccess;
using System.Collections.Generic;

namespace ShoppingAssignment_SE151263.Repository
{
    public interface IOrderRepository
    {
        public double GetTotal(List<Order> list);
    }
}