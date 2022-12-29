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
    public class HightSchoolRepository : AbstractRepository<HightSchool, Guid>, IHightSchoolRepository
    {
        public HightSchoolRepository(Context context)
        {
            _context = context;
        }

        public override List<HightSchool> FromSqlInterpolated(FormattableString sqlCommand) => _context.HightSchools.FromSqlInterpolated(sqlCommand).ToList();

        public override List<HightSchool> FromSqlRow(FormattableString sqlCommand) => _context.HightSchools.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(HightSchool value)
        {
            _context.HightSchools.Add(value);
        }

        protected override async Task CreateImplementationAsync(HightSchool value)
        {
            await _context.HightSchools.AddAsync(value);
        }

        protected override void DeleteImplementation(HightSchool value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.HightSchools.Remove(entity);
        }

        protected override Guid KeySelector(HightSchool value) => value.Id;

        protected override IQueryable<HightSchool> QueryImplementation()
        {
            return _context.HightSchools
                                .Include(e => e.Street)
                                    .ThenInclude(e => e.City)
                                        .ThenInclude(e => e.Region)
                                            .ThenInclude(e => e.Country);
        }

        protected override HightSchool ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<HightSchool> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(HightSchool entity, HightSchool value)
        {
            _context.Update(value);
        }
    }
}
