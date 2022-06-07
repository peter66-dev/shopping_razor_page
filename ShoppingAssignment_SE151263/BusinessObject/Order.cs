using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShoppingAssignment_SE151263.DataAccess
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Display(Name ="ID")]
        public string OrderId { get; set; }

        [Display(Name = "CustomerID")]
        public string CustomerId { get; set; }

        [Display(Name = "OrderDate")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Required Date")]
        public DateTime? RequiredDate { get; set; }

        [Display(Name = "Shipped Date")]
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        [Display(Name = "Ship Address")]
        public string ShipAddress { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
