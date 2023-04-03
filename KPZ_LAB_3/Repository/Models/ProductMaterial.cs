using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class ProductMaterial
    {
        public ProductMaterial()
        {
            ProductCompositions = new HashSet<ProductComposition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductComposition> ProductCompositions { get; set; }
    }
}
