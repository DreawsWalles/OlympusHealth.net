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
    public class AdvancedTrainingCoursesRepository : AbstractRepository<AdvancedTrainingCourses, Guid>, IAdvancedTrainingCoursesRepository
    {
        public AdvancedTrainingCoursesRepository(Context context)
        {
            _context = context;
        }

        public override List<AdvancedTrainingCourses> FromSqlInterpolated(FormattableString sqlCommand) => _context.AdvancedTrainingCourses.FromSqlInterpolated(sqlCommand).ToList();

        public override List<AdvancedTrainingCourses> FromSqlRow(FormattableString sqlCommand) => _context.AdvancedTrainingCourses.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(AdvancedTrainingCourses value)
        {
            _context.AdvancedTrainingCourses.Add(value);
        }

        protected override async Task CreateImplementationAsync(AdvancedTrainingCourses value)
        {
            await _context.AdvancedTrainingCourses.AddAsync(value);
        }

        protected override void DeleteImplementation(AdvancedTrainingCourses value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.AdvancedTrainingCourses.Remove(entity);
        }

        protected override Guid KeySelector(AdvancedTrainingCourses value) => value.Id;

        protected override IQueryable<AdvancedTrainingCourses> QueryImplementation()
        {
            return _context.AdvancedTrainingCourses
                                .Include(e => e.Street)
                                    .ThenInclude(e => e.City)
                                        .ThenInclude(e => e.Region)
                                            .ThenInclude(e => e.Country);
        }

        protected override AdvancedTrainingCourses ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<AdvancedTrainingCourses> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(AdvancedTrainingCourses entity, AdvancedTrainingCourses value)
        {
            _context.Update(value);
        }
    }
}
