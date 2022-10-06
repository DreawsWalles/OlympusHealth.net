using Business.Enties.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel.DescriptionModel
{
    public class RadiationDoseRepository : AbstractRepository<RadiationDose, Guid>, IRadiationDoseRepository
    {
        public RadiationDoseRepository(Context context)
        {
            _context = context; 
        }

        public override List<RadiationDose> FromSqlInterpolated(FormattableString sqlCommand) => _context.RadiationDoses.FromSqlInterpolated(sqlCommand).ToList();

        public override List<RadiationDose> FromSqlRow(string sqlCommand) => _context.RadiationDoses.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(RadiationDose value)
        {
            _context.RadiationDoses.Add(value);
        }

        protected override async Task CreateImplementationAsync(RadiationDose value)
        {
            await _context.RadiationDoses.AddAsync(value);
        }

        protected override void DeleteImplementation(RadiationDose value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.RadiationDoses.Remove(entity);
        }

        protected override Guid KeySelector(RadiationDose value) => value.Id;

        protected override IQueryable<RadiationDose> QueryImplementation()
        {
            return _context.RadiationDoses;
        }

        protected override RadiationDose ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<RadiationDose> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(RadiationDose entity, RadiationDose value)
        {
            _context.Update(value);
        }
    }
}
