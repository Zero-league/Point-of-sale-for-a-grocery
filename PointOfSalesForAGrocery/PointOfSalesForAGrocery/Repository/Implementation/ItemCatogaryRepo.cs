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
    public class ItemCatogaryRepo : IItemCatogaryRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ItemCatogaryRepo(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ItemCatogary> DeleteItemCatogary(int id)
        {
            var itemCatogary = await GetItemCatogary(id);
            context.ItemCatogaries.Remove(itemCatogary);
            await context.SaveChangesAsync();
            if (itemCatogary == null)
            {
                return null;
            }
            else
            {
                return itemCatogary;
            }
            
        }

        public async Task<IEnumerable<ItemCatogary>> GetItemCatogaries()
        {
            var item = await context.ItemCatogaries.ToListAsync();
            return item;
        }

        public async Task<ItemCatogary> GetItemCatogary(int id)
        {
            var item = await context.ItemCatogaries.Where(i => i.Id == id).SingleOrDefaultAsync();

            return item;
        }

        public async Task<ItemCatogary> PostItemCatogary(ItemCatogary  itemCatogary)
        {
            await context.ItemCatogaries.AddAsync(itemCatogary);
            await context.SaveChangesAsync();
            var post = await GetItemCatogary(itemCatogary.Id);
            return post;


        }

        public async Task<ItemCatogary> UpdatetemCatogary(int id, ItemCatogaryDto itemCatogaryDto)
        {
            var item = await context.ItemCatogaries.Where(i => i.Id == id).SingleOrDefaultAsync();

            if (item == null)
            {
                return null;
            }
            else
            {
                var mp = mapper.Map(itemCatogaryDto, item);
                await context.SaveChangesAsync();

                return mp;

            }
        }
    }
}
