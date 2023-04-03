using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class CustomerOrderStatus
    {
        public CustomerOrderStatus()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
