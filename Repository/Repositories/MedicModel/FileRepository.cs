using Business.Enties.MedicModel;
using Business.Repository.DataRepository.MedicModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel
{
    public class FileRepository : AbstractRepository<Files, Guid>, IFileRepository
    {
        public FileRepository(Context context)
        {
            _context = context;
        }

        public override List<Files> FromSqlInterpolated(FormattableString sqlCommand) => _context.Files.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Files> FromSqlRow(string sqlCommand) => _context.Files.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Files value)
        {
            _context.Files.Add(value);
        }

        protected override async Task CreateImplementationAsync(Files value)
        {
            await _context.Files.AddAsync(value);
        }

        protected override void DeleteImplementation(Files value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Files.Remove(entity);
        }

        protected override Guid KeySelector(Files value) => value.Id;

        protected override IQueryable<Files> QueryImplementation()
        {
            return _context.Files
                                .Include(e => e.Medic); //Здесь реализовать многие ко многим
        }

        protected override Files ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Files> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Files entity, Files value)
        {
            _context.Update(value);
        }
    }
}
