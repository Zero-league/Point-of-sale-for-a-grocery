﻿using POS.Models;
using POS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IItemCatogaryRepository
    {
        Task<IEnumerable<ItemCatogary>> GetItemCatogaries();
        Task<ItemCatogary> GetItemCatogary(int id);
        Task<ItemCatogary> UpdatetemCatogary(int id, ItemCatogaryDto itemCatogaryDto);
        Task<ItemCatogary> PostItemCatogary(ItemCatogary itemCatogary);
        Task<ItemCatogary> DeleteItemCatogary(int id);
    }
}
