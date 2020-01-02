using AutoMapper;
using POS.Models;
using POS.Models.Entities;

namespace POS.PointOfSalesForAGrocery
{

    class AuttoMapping : Profile
    {
        public AuttoMapping()
        {
            CreateMap<InventoryDto, Inventory>();
            CreateMap<Inventory, InventoryDto>();

        }
    }
}
