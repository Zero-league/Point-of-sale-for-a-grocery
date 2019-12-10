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

        public UnitMesurementRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Task<Unitmesurement> DeleteUnitmesurement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Unitmesurement> GetUnitmesurement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Unitmesurement>> GetUnitmesurements()
        {
            throw new NotImplementedException();
        }

        public Task<Unitmesurement> PostUnitmesurement(UnitmesurementDto unitmesurementDto)
        {
            throw new NotImplementedException();
        }

        public Task<Unitmesurement> PutUnitmesurement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
