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
    public class GenderRepository : AbstractRepository<Gender, Guid>, IGenderRepository
    {
        public GenderRepository(Context context)
        {
            _context = context;
        }

        public override List<Gender> FromSqlInterpolated(FormattableString sqlCommand) => _context.Genders.FromSqlInterpolated(sqlCommand).ToList();


        public override List<Gender> FromSqlRow(string sqlCommand) => _context.Genders.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Gender value)
        {
            _context.Genders.Add(value);
        }

        protected override async Task CreateImplementationAsync(Gender value)
        {
            await _context.Genders.AddAsync(value);
        }

        protected override void DeleteImplementation(Gender value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Genders.Remove(entity);
        }

        protected override Guid KeySelector(Gender value) => value.Id;

        protected override IQueryable<Gender> QueryImplementation()
        {
            return _context.Genders;
        }

        protected override Gender ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Gender> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Gender entity, Gender value)
        {
            _context.Update(value);
        }
    }
}
