using Business.Enties;
using Business.Repository.DataRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SysAdminRepository : AbstractRepository<SysAdmin, Guid>, ISysAdminRepository
    {
        public SysAdminRepository(Context context)
        {
            _context = context;
        }

        public override List<SysAdmin> FromSqlInterpolated(FormattableString sqlCommand) => _context.SysAdmins.FromSqlInterpolated(sqlCommand).ToList();


        public override List<SysAdmin> FromSqlRow(FormattableString sqlCommand) => _context.SysAdmins.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(SysAdmin value)
        {
            _context.SysAdmins.Add(value);
        }

        protected override async Task CreateImplementationAsync(SysAdmin value)
        {
            await _context.SysAdmins.AddAsync(value);
        }

        protected override void DeleteImplementation(SysAdmin value)
        {
            var entity = ReadImplementation(value.Id);
            if(entity == null)
                return;
            _context.SysAdmins.Remove(entity);
        }

        protected override Guid KeySelector(SysAdmin value) => value.Id;

        protected override IQueryable<SysAdmin> QueryImplementation()
        {
            return _context.SysAdmins
                .Include(e => e.HistoryNodes);
        }

        protected override SysAdmin ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<SysAdmin> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(SysAdmin entity, SysAdmin value)
        {
            _context.Update(value);
        }
    }
}
