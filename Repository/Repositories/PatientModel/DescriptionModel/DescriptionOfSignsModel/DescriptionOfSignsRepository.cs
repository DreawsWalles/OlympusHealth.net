using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class DescriptionOfSignsRepository : AbstractRepository<DescriptionOfSigns, Guid>, IDescriptionOfSignsRepository
    {
        public DescriptionOfSignsRepository(Context context)
        {
            _context = context;
        }

        public override List<DescriptionOfSigns> FromSqlInterpolated(FormattableString sqlCommand) => _context.DescriptionOfSigns.FromSqlInterpolated(sqlCommand).ToList();

        public override List<DescriptionOfSigns> FromSqlRow(string sqlCommand) => _context.DescriptionOfSigns.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(DescriptionOfSigns value)
        {
            _context.DescriptionOfSigns.Add(value);
        }

        protected override async Task CreateImplementationAsync(DescriptionOfSigns value)
        {
            await _context.DescriptionOfSigns.AddAsync(value);
        }

        protected override void DeleteImplementation(DescriptionOfSigns value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.DescriptionOfSigns.Remove(entity);
        }

        protected override Guid KeySelector(DescriptionOfSigns value) => value.Id;

        protected override IQueryable<DescriptionOfSigns> QueryImplementation()
        {
            return _context.DescriptionOfSigns
                                .Include(e => e.Methods); //Здесь реализовать многие ко многим
        }

        protected override DescriptionOfSigns ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<DescriptionOfSigns> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(DescriptionOfSigns entity, DescriptionOfSigns value)
        {
            _context.Update(value);
        }
    }
}
