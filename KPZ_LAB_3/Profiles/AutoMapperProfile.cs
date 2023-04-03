using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KPZ_LAB_3.Repository.Models;
using KPZ_LAB_3.ViewModels;

namespace KPZ_LAB_3.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Saler, SalerViewModel>().ReverseMap();
            CreateMap<Saler, UpdateSalerViewModel>().ReverseMap();
        }
    }
}
