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
    public class IntershipRepository : AbstractRepository<Intership, Guid>, IIntershipRepository
    {
        public IntershipRepository(Context context)
        {
            _context = context;
        }

        public override List<Intership> FromSqlInterpolated(FormattableString sqlCommand) => _context.Interships.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Intership> FromSqlRow(string sqlCommand) => _context.Interships.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Intership value)
        {
            _context.Interships.Add(value);
        }

        protected override async Task CreateImplementationAsync(Intership value)
        {
            await _context.Interships.AddAsync(value);
        }

        protected override void DeleteImplementation(Intership value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Interships.Remove(entity);
        }

        protected override Guid KeySelector(Intership value) => value.Id;

        protected override IQueryable<Intership> QueryImplementation()
        {
            return _context.Interships
                                .Include(e => e.Street)
                                    .ThenInclude(e => e.City)
                                        .ThenInclude(e => e.Region)
                                            .ThenInclude(e => e.Country);
        }

        protected override Intership ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Intership> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Intership entity, Intership value)
        {
            _context.Update(value);
        }
    }
}
