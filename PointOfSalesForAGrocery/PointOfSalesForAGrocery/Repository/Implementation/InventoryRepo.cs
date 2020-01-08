using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.DataSource;
using POS.Models;
using POS.Models.Entities;

namespace PointOfSalesForAGrocery.Repository
{
    public class InventoryRepo : IInventoryRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public InventoryRepo(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> GetInventories()
        {
            var get = await (from i in context.Inventories
                             join c in context.ItemCatogaries on i.ItemCatogaryId equals c.Id
                             join l in context.ItemLocations on i.ItemLocationId equals l.Id
                             join m in context.Unitmesurements on i.UnitmesurementId equals m.Id
                             select new ItemDto { Id= i.Id, ItemName=i.ItemName, ExpireDate=i.ExpireDate, QTY=i.QTY, Brand=i.Brand, ItemCost= i.ItemCost, RetailPrice=i.RetailPrice, CatogaryName=c.CatogaryName, LocationName=l.LocationName, Position=l.Position, mesurementName= m.mesurementName, CatogaryID=c.Id, LocationID=l.Id, mesurementID=m.Id }).ToListAsync(); ;
            InventoryDto dto = new InventoryDto();
            return get;
        }

        public async Task<ItemDto> GetInventory(int id)
        {
            var get = await (from i in context.Inventories
                             join c in context.ItemCatogaries on i.ItemCatogaryId equals c.Id
                             join l in context.ItemLocations on i.ItemLocationId equals l.Id
                             join m in context.Unitmesurements on i.UnitmesurementId equals m.Id
                             where i.Id == id
                             select new ItemDto { Id = i.Id, ItemName = i.ItemName, ExpireDate = i.ExpireDate, QTY = i.QTY, Brand = i.Brand, ItemCost = i.ItemCost, RetailPrice = i.RetailPrice, CatogaryName = c.CatogaryName, LocationName = l.LocationName, Position = l.Position, mesurementName = m.mesurementName }).SingleOrDefaultAsync();

          
            
            return get;

        }
        public async Task<Inventory> GetInventoryById(int id)
        {
            var get = await context.Inventories.Where(i => i.Id == id).SingleOrDefaultAsync();
            return get;

        }
            public async Task<Inventory> PostInventory(InventoryDto inventoryDto)
        {
            var finalitem = mapper.Map<Inventory>(inventoryDto);
            try
            {
                await context.Inventories.AddAsync(finalitem);
                await context.SaveChangesAsync();
                var item = await GetInventoryById(finalitem.Id);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
            
           
        }

        public async Task RemoveInventory(int id)
        {
            var inventory = await GetInventoryById(id);

            try
            {
                context.Inventories.Remove(inventory);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
                
            

        }

        public async Task<Inventory> UpdateInventory(int id, InventoryDto c)
        {
            var item = await context.Inventories.FindAsync(id);
            if (item != null)
            {
                try
                {
                    var finalitem = mapper.Map(c,item);
                    context.SaveChanges();
                    return finalitem;
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            else
            {
                return null;
            }
        }
    }
}
