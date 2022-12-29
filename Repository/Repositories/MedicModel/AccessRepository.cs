using Business.Enties.MedicModel;
using Business.Repository.DataRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel
{
    public class AccessRepository : AbstractRepository<Access, Guid>, IAccessRepository
    {
        public AccessRepository(Context context)
        {
            _context = context;
        }

        public override List<Access> FromSqlInterpolated(FormattableString sqlCommand) => _context.Accesses.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Access> FromSqlRow(FormattableString sqlCommand) => _context.Accesses.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(Access value)
        {
            _context.Accesses.Add(value);
        }

        protected override async Task CreateImplementationAsync(Access value)
        {
            await _context.Accesses.AddAsync(value);
        }

        protected override void DeleteImplementation(Access value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Accesses.Remove(entity);
        }

        protected override Guid KeySelector(Access value) => value.Id;

        protected override IQueryable<Access> QueryImplementation()
        {
            return _context.Accesses
                                .Include(e => e.Medics); //Здесь реализовать многие ко многим
        }

        protected override Access ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Access> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Access entity, Access value)
        {
            _context.Update(value);
        }
    }
}
