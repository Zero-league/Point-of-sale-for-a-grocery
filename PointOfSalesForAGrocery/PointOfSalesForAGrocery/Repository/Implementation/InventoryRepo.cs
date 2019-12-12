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

        public async Task<Inventory> GetInventory(int id)
        {
            var get = await context.Inventories.Where(g => g.Id == id).SingleOrDefaultAsync();
            return get;
        }

        public async Task<Inventory> PostInventory(Inventory inventor)
        {
            await context.Inventories.AddAsync(inventor);
            await context.SaveChangesAsync();
            var post = await GetInventory(inventor.Id);
            return post;
        }

        public async Task<Inventory> RemoveInventory(int id)
        {
            var inventory = await GetInventory(id);
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
