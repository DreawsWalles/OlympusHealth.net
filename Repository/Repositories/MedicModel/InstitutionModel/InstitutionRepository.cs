using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel.InstitutionModel
{
    public class InstitutionRepository : AbstractRepository<Institution, Guid>, IInstitutionRepository
    {
        public InstitutionRepository(Context context)
        {
            _context = context;
        }

        public override List<Institution> FromSqlInterpolated(FormattableString sqlCommand) => _context.Institutions.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Institution> FromSqlRow(string sqlCommand) => _context.Institutions.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Institution value)
        {
            _context.Institutions.Add(value);
        }

        protected override async Task CreateImplementationAsync(Institution value)
        {
            await _context.Institutions.AddAsync(value);
        }

        protected override void DeleteImplementation(Institution value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Institutions.Remove(entity);
        }

        protected override Guid KeySelector(Institution value) => value.Id;

        protected override IQueryable<Institution> QueryImplementation()
        {
            return _context.Institutions
                            .Include(e => e.Corpuses)
                                .ThenInclude(e => e.Street)
                                    .ThenInclude(e => e.City)
                                        .ThenInclude(e => e.Region)
                                            .ThenInclude(e => e.Country)
                            .Include(e => e.Corpuses)
                                .ThenInclude(e => e.Devices)
                            .Include(e => e.Corpuses)
                                .ThenInclude(e => e.Medics)
                            .Include(e => e.Corpuses)
                                .ThenInclude(e => e.Departments)
                                    .ThenInclude(e => e.MedicRegistrators)
                            .Include(e => e.Corpuses)
                                .ThenInclude(e => e.Departments)
                                    .ThenInclude(e => e.ChiefsOfDepartment);
        }

        protected override Institution ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Institution> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Institution entity, Institution value)
        {
            _context.Update(value);
        }
    }
}
