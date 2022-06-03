using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAssignment_SE151263.Models
{
    public class OrderDetail
    {
        [StringLength(30)]
        public string OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}