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
    public class UnitMesurementRepo : IUnitMesurementRepositorys
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public UnitMesurementRepo(AppDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unitmesurement> DeleteUnitmesurement(int id)
        {
            var item = await GetUnitmesurement(id);
            context.Unitmesurements.Remove(item);
            if (item == null)
            {
                return null;
            }
            else
            {
                return item;
            }
        }

        public async Task<Unitmesurement> GetUnitmesurement(int id)
        {
            var item = await context.Unitmesurements.Where(i => i.Id == id).SingleOrDefaultAsync();

            return item;
        }

        public async Task<IEnumerable<Unitmesurement>> GetUnitmesurements()
        {
            var item = await context.Unitmesurements.ToListAsync();
            return item;
        }

        public async Task<Unitmesurement> PostUnitmesurement(UnitmesurementDto unitmesurementDto)
        {
            var mp = mapper.Map<Unitmesurement>(unitmesurementDto);
            await context.Unitmesurements.AddAsync(mp);
            await context.SaveChangesAsync();
            var post = await GetUnitmesurement(mp.Id);
            return post;
        }

        public async Task<Unitmesurement> PutUnitmesurement(int id, UnitmesurementDto unitmesurementDto)
        {
            var item = await context.Unitmesurements.Where(i => i.Id == id).SingleOrDefaultAsync();

            if (item == null)
            {
                return null;
            }
            else
            {
                var mp = mapper.Map(unitmesurementDto, item);
                await context.SaveChangesAsync();

                return mp;

            }
        }
    }
}
