using Business.Enties;
using Business.Enties.PatientModel;
using Business.Repository.DataRepository.PatientModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel
{
    public class OutpatientCardRepository : AbstractRepository<OutpatientCard, Guid>, IOutpatientCardRepository
    {
        public OutpatientCardRepository(Context context)
        {
            _context = context;
        }
        public override List<OutpatientCard> FromSqlInterpolated(FormattableString sqlCommand) => _context.OutpatientCards.FromSqlInterpolated(sqlCommand).ToList();


        public override List<OutpatientCard> FromSqlRow(string sqlCommand) => _context.OutpatientCards.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(OutpatientCard value)
        {
            _context.OutpatientCards.Add(value);
        }

        protected override async Task CreateImplementationAsync(OutpatientCard value)
        {
            await _context.OutpatientCards.AddAsync(value);
        }

        protected override void DeleteImplementation(OutpatientCard value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.OutpatientCards.Remove(entity);
        }

        protected override Guid KeySelector(OutpatientCard value) => value.Id;

        protected override IQueryable<OutpatientCard> QueryImplementation()
        {
            return _context.OutpatientCards
                            .Include(e => e.Patient);
        }

        protected override OutpatientCard ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<OutpatientCard> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(OutpatientCard entity, OutpatientCard value)
        {
            _context.Update(value);
        }
    }
}
