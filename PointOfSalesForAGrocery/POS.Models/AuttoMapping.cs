using AutoMapper;
using POS.Models;
using POS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.PointOfSalesForAGrocery
{

    class AuttoMapping : Profile
    {
        public AuttoMapping()
        {
            CreateMap<InventoryDto,Inventory>();
            CreateMap<Inventory,InventoryDto>();

        }
    }
}
