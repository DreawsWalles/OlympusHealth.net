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
    public class RegionRepository : AbstractRepository<Region, Guid>, IRegionRepository
    {
        public RegionRepository(Context context)
        {
            _context = context;
        }

        public override List<Region> FromSqlInterpolated(FormattableString sqlCommand) => _context.Regions.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Region> FromSqlRow(string sqlCommand) => _context.Regions.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Region value)
        {
            _context.Regions.Add(value);
        }

        protected override async Task CreateImplementationAsync(Region value)
        {
            await _context.Regions.AddAsync(value);
        }

        protected override void DeleteImplementation(Region value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Regions.Remove(entity);
        }

        protected override Guid KeySelector(Region value) => value.Id;

        protected override IQueryable<Region> QueryImplementation()
        {
            return _context.Regions
                                .Include(e => e.Country)
                                .Include(e => e.Citys)
                                    .ThenInclude(e => e.Streets);
        }

        protected override Region ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Region> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Region entity, Region value)
        {
            _context.Update(value);
        }
    }
}
