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
    public class HistoryNodeRepository : AbstractRepository<HistoryNode, Guid>, IHistoryNodeRepository
    {
        public HistoryNodeRepository(Context context)
        {
            _context = context;
        }

        public override List<HistoryNode> FromSqlInterpolated(FormattableString sqlCommand) => _context.HistoryNodes.FromSqlInterpolated(sqlCommand).ToList();


        public override List<HistoryNode> FromSqlRow(string sqlCommand) => _context.HistoryNodes.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(HistoryNode value)
        {
            _context.HistoryNodes.Add(value);
        }

        protected override async Task CreateImplementationAsync(HistoryNode value)
        {
            await _context.HistoryNodes.AddAsync(value);
        }

        protected override void DeleteImplementation(HistoryNode value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.HistoryNodes.Remove(entity);
        }

        protected override Guid KeySelector(HistoryNode value) => value.Id;

        protected override IQueryable<HistoryNode> QueryImplementation()
        {
            return _context.HistoryNodes
                .Include(e => e.SysAdmin)
                .Include(e => e.Medic)
                .Include(e => e.Patient);
        }

        protected override HistoryNode ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<HistoryNode> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(HistoryNode entity, HistoryNode value)
        {
            _context.Update(value);
        }
    }
}
