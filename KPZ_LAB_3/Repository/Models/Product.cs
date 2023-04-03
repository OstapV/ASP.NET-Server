using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductCompositions = new HashSet<ProductComposition>();
        }

        [Key]
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public int ProductCollectionId { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public int Discount { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductCollection ProductCollection { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductComposition> ProductCompositions { get; set; }
    }
}
