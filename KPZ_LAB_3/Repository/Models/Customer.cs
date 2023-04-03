using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual PersonDatum PersonDatum { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
