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
    public class CountryRepository : AbstractRepository<Country, Guid>, ICountryRepository
    {
        public CountryRepository(Context context)
        {
            _context = context;
        }

        public override List<Country> FromSqlInterpolated(FormattableString sqlCommand) => _context.Countries.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Country> FromSqlRow(string sqlCommand) => _context.Countries.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Country value)
        {
            _context.Countries.Add(value);
        }

        protected override async Task CreateImplementationAsync(Country value)
        {
            await _context.Countries.AddAsync(value);
        }

        protected override void DeleteImplementation(Country value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Countries.Remove(entity);
        }

        protected override Guid KeySelector(Country value) => value.Id;

        protected override IQueryable<Country> QueryImplementation()
        {
            return _context.Countries
                                .Include(e => e.Regions)
                                    .ThenInclude(e => e.Citys)
                                        .ThenInclude(e => e.Streets);
        }

        protected override Country ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Country> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Country entity, Country value)
        {
            _context.Update(value);
        }
    }
}
