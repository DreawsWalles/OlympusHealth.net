using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
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
    public class StatusOfTheAttributeRepository : AbstractRepository<StatusOfTheAttribute, Guid>, IStatusOfTheAttributeRepository
    {
        public StatusOfTheAttributeRepository(Context context)
        {
            _context = context;
        }

        public override List<StatusOfTheAttribute> FromSqlInterpolated(FormattableString sqlCommand) => _context.StatusOfTheAttributes.FromSqlInterpolated(sqlCommand).ToList();

        public override List<StatusOfTheAttribute> FromSqlRow(FormattableString sqlCommand) => _context.StatusOfTheAttributes.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(StatusOfTheAttribute value)
        {
            _context.StatusOfTheAttributes.Add(value);
        }

        protected override async Task CreateImplementationAsync(StatusOfTheAttribute value)
        {
            await _context.StatusOfTheAttributes.AddAsync(value);
        }

        protected override void DeleteImplementation(StatusOfTheAttribute value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.StatusOfTheAttributes.Remove(entity);
        }

        protected override Guid KeySelector(StatusOfTheAttribute value) => value.Id;

        protected override IQueryable<StatusOfTheAttribute> QueryImplementation()
        {
            return _context.StatusOfTheAttributes
                                .Include(e => e.DescriptionOfSigns)
                                    .ThenInclude(e => e.Methods); //Здесь реализовать многие ко многим
        }

        protected override StatusOfTheAttribute ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<StatusOfTheAttribute> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(StatusOfTheAttribute entity, StatusOfTheAttribute value)
        {
            _context.Update(value);
        }
    }
}
