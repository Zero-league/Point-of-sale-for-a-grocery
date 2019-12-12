using POS.Models;
using POS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IUnitMesurementRepositorys
    {

        Task<IEnumerable<Unitmesurement>> GetUnitmesurements();
        Task<Unitmesurement> GetUnitmesurement(int id);
        Task<Unitmesurement> PutUnitmesurement(int id, UnitmesurementDto unitmesurementDto);
        Task<Unitmesurement> PostUnitmesurement(UnitmesurementDto unitmesurementDto);
        Task<Unitmesurement> DeleteUnitmesurement(int id);
    }
}
