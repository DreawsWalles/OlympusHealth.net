using Business.Enties;
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
    public class Method_DescriptionOfSignsRepository : AbstractRepository<Method_DescriptionOfSigns, Dictionary<int, Guid>>, IMethod_DescriptionOfSignsRepository
    {
        public Method_DescriptionOfSignsRepository(Context context)
        {
            _context = context;
        }

        public override List<Method_DescriptionOfSigns> FromSqlInterpolated(FormattableString sqlCommand) => _context.Method_DescriptionOfSigns.FromSqlInterpolated(sqlCommand).ToList();


        public override List<Method_DescriptionOfSigns> FromSqlRow(string sqlCommand) => _context.Method_DescriptionOfSigns.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Method_DescriptionOfSigns value)
        {
            _context.Method_DescriptionOfSigns.Add(value);
        }

        protected override async Task CreateImplementationAsync(Method_DescriptionOfSigns value)
        {
            await _context.Method_DescriptionOfSigns.AddAsync(value);
        }

        protected override void DeleteImplementation(Method_DescriptionOfSigns value)
        {
            var entity = ReadImplementation(new Dictionary<int, Guid> { { 0, value.MethodId }, { 1, value.DescriptionOfSighs } });
            if (entity == null)
                return;
            _context.Method_DescriptionOfSigns.Remove(entity);
        }

        protected override Dictionary<int, Guid> KeySelector(Method_DescriptionOfSigns value) => new Dictionary<int, Guid> { { 0, value.MethodId }, { 1, value.DescriptionOfSighs } };

        protected override IQueryable<Method_DescriptionOfSigns> QueryImplementation()
        {
            return _context.Method_DescriptionOfSigns;
        }

        protected override Method_DescriptionOfSigns ReadImplementation(Dictionary<int, Guid> key)
        {
            return QueryImplementation().FirstOrDefault(i => i.MethodId == key[0] && i.DescriptionOfSighs == key[1]);
        }

        protected override async Task<Method_DescriptionOfSigns> ReadImplementationAsync(Dictionary<int, Guid> key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.MethodId == key[0] && i.DescriptionOfSighs == key[1]);
        }

        protected override void UpdateImplementation(Method_DescriptionOfSigns entity, Method_DescriptionOfSigns value)
        {
            _context.Update(value);
        }
    }
}
