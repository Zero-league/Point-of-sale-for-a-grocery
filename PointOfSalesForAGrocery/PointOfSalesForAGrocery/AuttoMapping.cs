using AutoMapper;
using POS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    class AuttoMapping : Profile
    {
        public AuttoMapping()
        {
            CreateMap<InventoryDto,Inventory>();
           
        }
    }
}
