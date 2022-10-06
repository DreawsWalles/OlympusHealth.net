using Business.Enties.PatientModel.DescriptionModel;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
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
    public class DescriptionRepository : AbstractRepository<Description, Guid>, IDescriptionRepository
    {
        public DescriptionRepository(Context context)
        {
            _context = context;
        }

        public override List<Description> FromSqlInterpolated(FormattableString sqlCommand) => _context.Descriptions.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Description> FromSqlRow(string sqlCommand) => _context.Descriptions.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Description value)
        {
            _context.Descriptions.Add(value);
        }

        protected override async Task CreateImplementationAsync(Description value)
        {
            await _context.Descriptions.AddAsync(value);
        }

        protected override void DeleteImplementation(Description value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Descriptions.Remove(entity);
        }

        protected override Guid KeySelector(Description value) => value.Id;

        protected override IQueryable<Description> QueryImplementation()
        {
            return _context.Descriptions
                            .Include(e => e.ProcessDynamics)
                            .Include(e => e.ResearchArea)
                                .ThenInclude(e => e.Patient)
                            .Include(e => e.StatusOfTheAttributes)//здесь реализовать многие ко многие
                                .ThenInclude(e => e.DescriptionOfSigns)
                                    .ThenInclude(e => e.Methods)//Здесь реализовать многие ко многим
                                        .ThenInclude(e => e.RadiationDose)
                            .Include(e => e.ResultIllness)
                                .ThenInclude(e => e.SignsOfResearch)
                                    .ThenInclude(e => e.Illness)
                                        .ThenInclude(e => e.Methods) //здесь релизовать многие ко многим
                                            .ThenInclude(e => e.ResearchCategory);
        }

        protected override Description ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Description> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Description entity, Description value)
        {
            _context.Update(value);
        }
    }
}
