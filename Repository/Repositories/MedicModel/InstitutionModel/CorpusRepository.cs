using Business.Enties.MedicModel.InstitutionModel;
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
    public class CorpusRepository : AbstractRepository<Corpus, Guid>, ICorpusRepository
    {
        public CorpusRepository(Context context)
        {
            _context = context;
        }

        public override List<Corpus> FromSqlInterpolated(FormattableString sqlCommand) => _context.Corpuses.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Corpus> FromSqlRow(string sqlCommand) => _context.Corpuses.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Corpus value)
        {
            _context.Corpuses.Add(value);
        }

        protected override async Task CreateImplementationAsync(Corpus value)
        {
            await _context.Corpuses.AddAsync(value);
        }

        protected override void DeleteImplementation(Corpus value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Corpuses.Remove(entity);
        }

        protected override Guid KeySelector(Corpus value) => value.Id;

        protected override IQueryable<Corpus> QueryImplementation()
        {
            return _context.Corpuses
                            .Include(e => e.Institution)
                            .Include(e => e.Devices)
                            .Include(e => e.Medics)
                            .Include(e => e.Departments)
                                .ThenInclude(e => e.MedicRegistrators)
                            .Include(e => e.Departments)
                                .ThenInclude(e => e.ChiefsOfDepartment)
                            .Include(e => e.Departments)
                                .ThenInclude(e => e.Medics)
                            .Include(e => e.Street)
                                .ThenInclude(e => e.City)
                                    .ThenInclude(e => e.Region)
                                        .ThenInclude(e => e.Country);
        }

        protected override Corpus ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Corpus> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Corpus entity, Corpus value)
        {
            _context.Update(value);
        }
    }
}
