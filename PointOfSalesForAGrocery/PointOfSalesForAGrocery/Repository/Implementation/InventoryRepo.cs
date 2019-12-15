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

        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            var get = await context.Inventories.ToListAsync();
            return get;
        }

        public async Task<ItemDto> GetInventory(int id)
        {
            var get = await (from i in context.Inventories
                             join c in context.ItemCatogaries on i.ItemCatogaryId equals c.Id
                             join l in context.ItemLocations on i.ItemLocationId equals l.Id
                             join m in context.Unitmesurements on i.UnitmesurementId equals m.Id
                             where i.Id == id
                             select new {i.Id, i.ItemName,i.ExpireDate,i.QTY,i.Brand,i.ItemCost,i.RetailPrice,c.CatogaryName,l.LocationName,l.Position,m.mesurementName }).SingleOrDefaultAsync();

            ItemDto it = new ItemDto();
            it.Id = get.Id;
            it.ItemName = get.ItemName;
            it.ExpireDate = get.ExpireDate;
            it.QTY = get.QTY;
            it.Brand = get.Brand;
            it.ItemCost = get.ItemCost;
            it.RetailPrice = get.RetailPrice;
            it.CatogaryName = get.CatogaryName;
            it.LocationName = get.LocationName;
            it.Position = get.Position;
            it.mesurementName = get.mesurementName;
            
            return it;

        }
        public async Task<Inventory> GetInventoryById(int id)
        {
            var get = await context.Inventories.Where(i => i.Id == id).SingleOrDefaultAsync();
            return get;

        }
            public async Task<Inventory> PostInventory(Inventory inventor)
        {
            try
            {
                await context.Inventories.AddAsync(inventor);
                await context.SaveChangesAsync();
                var item = await GetInventoryById(inventor.Id);
                return item;
            }
            catch (Exception)
            {

                return null;
            }
            
           
        }

        public async Task<Inventory> RemoveInventory(int id)
        {
            var inventory = await GetInventoryById(id);
            if (inventory == null)
            {
                return null;
            }
            else
            {
                context.Inventories.Remove(inventory);
                await context.SaveChangesAsync();
                return inventory;
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
