using Business.Enties.Address;
using Business.Repository.DataRepository.Address;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Address
{
    public class StreetRepository : AbstractRepository<Street, Guid>, IStreetRepository
    {
        public StreetRepository(Context context)
        {
            _context = context;
        }

        public override List<Street> FromSqlInterpolated(FormattableString sqlCommand) => _context.Streets.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Street> FromSqlRow(FormattableString sqlCommand) => _context.Streets.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(Street value)
        {
            _context.Streets.Add(value);
        }

        protected override async Task CreateImplementationAsync(Street value)
        {
            await _context.Streets.AddAsync(value);
        }

        protected override void DeleteImplementation(Street value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Streets.Remove(entity);
        }

        protected override Guid KeySelector(Street value) => value.Id;

        protected override IQueryable<Street> QueryImplementation()
        {
            return _context.Streets
                                .Include(e => e.City)
                                    .ThenInclude(e => e.Region)
                                        .ThenInclude(e => e.Country);
        }

        protected override Street ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Street> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Street entity, Street value)
        {
            _context.Update(value);
        }
    }
}
