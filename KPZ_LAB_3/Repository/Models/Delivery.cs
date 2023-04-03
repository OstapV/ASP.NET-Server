using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class Delivery
    {
        public int Id { get; set; }
        public int CustomerOrderId { get; set; }
        public decimal Price { get; set; }
        public string DeliveryMethod { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }
    }
}
