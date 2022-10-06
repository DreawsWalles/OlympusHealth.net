using Business.Enties.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel.DescriptionModel
{
    public class MethodRepository : AbstractRepository<Method, Guid>, IMethodRepository
    {
        public MethodRepository(Context context)
        {
            _context = context;
        }

        public override List<Method> FromSqlInterpolated(FormattableString sqlCommand) => _context.Methods.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Method> FromSqlRow(string sqlCommand) => _context.Methods.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Method value)
        {
            _context.Methods.Add(value);
        }

        protected override async Task CreateImplementationAsync(Method value)
        {
            await _context.Methods.AddAsync(value);
        }

        protected override void DeleteImplementation(Method value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Methods.Remove(entity);
        }

        protected override Guid KeySelector(Method value) => value.Id;

        protected override IQueryable<Method> QueryImplementation()
        {
            return _context.Methods
                            .Include(e => e.Illnesses) //здесь нужна реализация многие ко многим
                                .ThenInclude(e => e.SignsOfResearches)
                                    .ThenInclude(e => e.ResultIllnesses)
                                        .ThenInclude(e => e.Descriptions)
                             .Include(e => e.DescriptionOfSigns)
                                .ThenInclude(e => e.StatusOfTheAttributes)
                                    .ThenInclude(e => e.Descriptions); //здесь нужна реализация многие ко многим
        }

        protected override Method ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Method> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Method entity, Method value)
        {
            _context.Update(value);
        }
    }
}
