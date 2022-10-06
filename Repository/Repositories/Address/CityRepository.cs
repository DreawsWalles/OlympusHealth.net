using Business.Enties.Address;
using Business.Enties.MedicModel.InstitutionModel;
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
    public class CityRepository : AbstractRepository<City, Guid>, ICityRepository
    {
        public CityRepository(Context context)
        {
            _context = context;
        }

        public override List<City> FromSqlInterpolated(FormattableString sqlCommand) => _context.Cities.FromSqlInterpolated(sqlCommand).ToList();

        public override List<City> FromSqlRow(string sqlCommand) => _context.Cities.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(City value)
        {
            _context.Cities.Add(value);
        }

        protected override async Task CreateImplementationAsync(City value)
        {
            await _context.Cities.AddAsync(value);
        }

        protected override void DeleteImplementation(City value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Cities.Remove(entity);
        }

        protected override Guid KeySelector(City value) => value.Id;

        protected override IQueryable<City> QueryImplementation()
        {
            return _context.Cities
                        .Include(e => e.Streets)
                        .Include(e => e.Region)
                            .ThenInclude(e => e.Country);
        }

        protected override City ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<City> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(City entity, City value)
        {
            _context.Update(value);
        }
    }
}
