using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS.DataSource;
using POS.Models;
using POS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implementation
{
    public class ItemlocationRepo : IItemLocationRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ItemlocationRepo(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ItemLocation> DeleteItemLocation(int id)
        {
            var itemLocation = await GetItemLocation(id);
           
                 context.ItemLocations.Remove(itemLocation);
                var item = await GetItemLocation(id);
                if (item  == null)
                {
                    return null;
                }
                else
                {
                    return item;
                }
            
        }

        public async Task<ItemLocation> GetItemLocation(int id)
        {
            var location = await context.ItemLocations.Where(i => i.Id == id).SingleOrDefaultAsync();
            return location;
        }

        public async Task<IEnumerable<ItemLocation>> GetItemLocations()
        {
            var locations = await context.ItemLocations.ToListAsync() ;
            return locations;
        }

        public async Task<ItemLocation> PostItemLocation(ItemLocation itemLocation)
        {
           await context.ItemLocations.AddAsync(itemLocation);
           await context.SaveChangesAsync();
           return itemLocation;
        }

        public async Task<ItemLocation> PutItemLocation(int id, ItemLocationDto itemLocation)
        {
            var item =await context.ItemLocations.Where(i => i.Id == id).SingleOrDefaultAsync();
            if (item == null)
            {
                return null;
            }
            else
            {
                var map = mapper.Map(itemLocation, item);
                context.ItemLocations.Update(map);
                return map;
            }
           

        }
    }
}
