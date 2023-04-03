using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class ProductComposition
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductMaterialId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductMaterial ProductMaterial { get; set; }
    }
}
