using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAssignment_SE151263.Models
{
    public class Order
    {
        [Key]
        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(30)]
        public string? CustomerID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public decimal? Freight { get; set; }

        [StringLength(60)]
        public string? ShipAddress { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}