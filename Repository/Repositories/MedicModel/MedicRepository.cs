using Business.Enties.MedicModel;
using Business.Repository.DataRepository.MedicModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel
{
    public class MedicRepository : AbstractRepository<Medic, Guid>, IMedicRepository
    {
        public MedicRepository(Context context)
        {
            _context = context;
        }
        public override List<Medic> FromSqlInterpolated(FormattableString sqlCommand) => _context.Medics.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Medic> FromSqlRow(FormattableString sqlCommand) => _context.Medics.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(Medic value)
        {
            _context.Medics.Add(value);
        }

        protected override async Task CreateImplementationAsync(Medic value)
        {
            await _context.Medics.AddAsync(value);
        }

        protected override void DeleteImplementation(Medic value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Medics.Remove(entity);
        }

        protected override Guid KeySelector(Medic value) => value.Id;

        //Реализовать связи многие ко многим
        protected override IQueryable<Medic> QueryImplementation()
        {
            return _context.Medics
                .Include(e => e.HistoryNodes)
            .Include(e => e.Address)
                .ThenInclude(e => e.City)
                    .ThenInclude(e => e.Region)
                        .ThenInclude(e => e.Country)
            .Include(e => e.Descriptions)
            .Include(e => e.DesctioptionHeadOfDepartment)
            .Include(e => e.Files)
            .Include(e => e.Role)
            .Include(e => e.Files)
            .Include(e => e.Gender)
            .Include(e => e.HistoryNodes)
            .Include(e => e.PlaceOfStudies)
                .ThenInclude(e => e.AdvancedTrainingCourses)
                    .ThenInclude(e => e.Street)
                        .ThenInclude(e => e.City)
                            .ThenInclude(e => e.Region)
                                .ThenInclude(e => e.Country)
            .Include(e => e.PlaceOfStudies)
                .ThenInclude(e => e.Specialities)
                    .ThenInclude(e => e.Street)
                        .ThenInclude(e => e.City)
                            .ThenInclude(e => e.Region)
                                .ThenInclude(e => e.Country)
            .Include(e => e.PlaceOfStudies)
                .ThenInclude(e => e.HightSchools)
                    .ThenInclude(e => e.Street)
                        .ThenInclude(e => e.City)
                            .ThenInclude(e => e.Region)
                                .ThenInclude(e => e.Country)
            .Include(e => e.PlaceOfStudies)
                .ThenInclude(e => e.Interships)
                    .ThenInclude(e => e.Street)
                        .ThenInclude(e => e.City)
                            .ThenInclude(e => e.Region)
                                .ThenInclude(e => e.Country)
            .Include(e => e.PlaceOfStudies)
                .ThenInclude(e => e.Specialization)
            .Include(e => e.Doctors)
                .ThenInclude(e => e.Corpus)
                    .ThenInclude(e => e.Institution)
            .Include(e => e.HeadOfDepartment)
                .ThenInclude(e => e.Corpus)
                    .ThenInclude(e => e.Institution)
            .Include(e => e.MedicRegistrator)
                .ThenInclude(e => e.Corpus)
                    .ThenInclude(e => e.Institution)
            .Include(e => e.Corpuses);
        }

        protected override Medic ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Medic> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Medic entity, Medic value)
        {
            _context.Update(value);
        }
    }
}
