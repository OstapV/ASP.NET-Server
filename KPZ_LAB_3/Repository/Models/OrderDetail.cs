using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerOrderId { get; set; }
        public int ProductAmount { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
