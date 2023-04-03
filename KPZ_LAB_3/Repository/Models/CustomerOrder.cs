using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime OperationTime { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerOrderStatusId { get; set; }
        public int CustomerId { get; set; }
        public int? SalerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerOrderStatus CustomerOrderStatus { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Saler Saler { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
