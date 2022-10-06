using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Repository.DataRepository.MedicModel.PlaceOfStudyModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel.PlaceOfStudyModel
{
    public class SpecialityRepository : AbstractRepository<Speciality, Guid>, ISpecialityRepository
    {
        public SpecialityRepository(Context context)
        {
            _context = context;
        }

        public override List<Speciality> FromSqlInterpolated(FormattableString sqlCommand) => _context.Specialities.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Speciality> FromSqlRow(string sqlCommand) => _context.Specialities.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Speciality value)
        {
            _context.Specialities.Add(value);
        }

        protected override async Task CreateImplementationAsync(Speciality value)
        {
            await _context.Specialities.AddAsync(value);
        }

        protected override void DeleteImplementation(Speciality value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Specialities.Remove(entity);
        }

        protected override Guid KeySelector(Speciality value) => value.Id;

        protected override IQueryable<Speciality> QueryImplementation()
        {
            return _context.Specialities
                                .Include(e => e.Street)
                                    .ThenInclude(e => e.City)
                                        .ThenInclude(e => e.Region)
                                            .ThenInclude(e => e.Country);
        }

        protected override Speciality ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Speciality> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Speciality entity, Speciality value)
        {
            _context.Update(value);
        }
    }
}
