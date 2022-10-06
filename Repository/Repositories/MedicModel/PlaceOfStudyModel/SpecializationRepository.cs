using Business.Enties.MedicModel;
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
    public class SpecializationRepository : AbstractRepository<Specialization, Guid>, ISpecializationRepository
    {
        public SpecializationRepository(Context context)
        {
            _context = context;
        }

        public override List<Specialization> FromSqlInterpolated(FormattableString sqlCommand) => _context.Specializations.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Specialization> FromSqlRow(string sqlCommand) => _context.Specializations.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Specialization value)
        {
            _context.Specializations.Add(value);
        }

        protected override async Task CreateImplementationAsync(Specialization value)
        {
            await _context.Specializations.AddAsync(value);
        }

        protected override void DeleteImplementation(Specialization value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Specializations.Remove(entity);
        }

        protected override Guid KeySelector(Specialization value) => value.Id;

        protected override IQueryable<Specialization> QueryImplementation()
        {
            return _context.Specializations;
        }

        protected override Specialization ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Specialization> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Specialization entity, Specialization value)
        {
            _context.Update(value);
        }
    }
}
