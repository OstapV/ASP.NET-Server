using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPZ_LAB_3.Repository.Models;

namespace KPZ_LAB_3.ViewModels
{
    public class UpdateSalerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsManager { get; set; }
    }
}
