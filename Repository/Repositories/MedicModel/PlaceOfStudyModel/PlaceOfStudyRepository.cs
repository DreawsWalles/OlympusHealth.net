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
    public class PlaceOfStudyRepository : AbstractRepository<PlaceOfStudy, Guid>, IPlaceOfStudyRepository
    {
        public PlaceOfStudyRepository(Context context)
        {
            _context = context;
        }

        public override List<PlaceOfStudy> FromSqlInterpolated(FormattableString sqlCommand) => _context.PlaceOfStudies.FromSqlInterpolated(sqlCommand).ToList();

        public override List<PlaceOfStudy> FromSqlRow(FormattableString sqlCommand) => _context.PlaceOfStudies.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(PlaceOfStudy value)
        {
            _context.PlaceOfStudies.Add(value);
        }

        protected override async Task CreateImplementationAsync(PlaceOfStudy value)
        {
            await _context.PlaceOfStudies.AddAsync(value);
        }

        protected override void DeleteImplementation(PlaceOfStudy value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.PlaceOfStudies.Remove(entity);
        }

        protected override Guid KeySelector(PlaceOfStudy value) => value.Id;

        protected override IQueryable<PlaceOfStudy> QueryImplementation()
        {
            return _context.PlaceOfStudies
                                .Include(e => e.Specialization)
                                .Include(e => e.AdvancedTrainingCourses)
                                    .ThenInclude(e => e.Street)
                                        .ThenInclude(e => e.City)
                                            .ThenInclude(e => e.Region)
                                                .ThenInclude(e => e.Country)
                                 .Include(e => e.Specialities)
                                    .ThenInclude(e => e.Street)
                                        .ThenInclude(e => e.City)
                                            .ThenInclude(e => e.Region)
                                                .ThenInclude(e => e.Country)
                                .Include(e => e.HightSchools)
                                    .ThenInclude(e => e.Street)
                                        .ThenInclude(e => e.City)
                                            .ThenInclude(e => e.Region)
                                                .ThenInclude(e => e.Country)
                                .Include(e => e.Interships)
                                    .ThenInclude(e => e.Street)
                                        .ThenInclude(e => e.City)
                                            .ThenInclude(e => e.Region)
                                                .ThenInclude(e => e.Country);
        }

        protected override PlaceOfStudy ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<PlaceOfStudy> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(PlaceOfStudy entity, PlaceOfStudy value)
        {
            _context.Update(value);
        }
    }
}
