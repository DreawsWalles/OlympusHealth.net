using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.IllnessModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel.DescriptionModel.IllnessModel
{
    public class Illness_MethodRepository : AbstractRepository<Illness_Method, Dictionary<int, Guid>>, IIllness_MethodRepository
    {
        public Illness_MethodRepository(Context context)
        {
            _context = context;   
        }
        public override List<Illness_Method> FromSqlInterpolated(FormattableString sqlCommand) => _context.Illness_Methods.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Illness_Method> FromSqlRow(string sqlCommand) => _context.Illness_Methods.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Illness_Method value)
        {
            _context.Illness_Methods.Add(value);
        }

        protected override async Task CreateImplementationAsync(Illness_Method value)
        {
            await _context.Illness_Methods.AddAsync(value);
        }

        protected override void DeleteImplementation(Illness_Method value)
        {
            var entity = ReadImplementation(new Dictionary<int, Guid> { { 0, value.IllnessId }, { 1, value.MethodId } });
            if (entity == null)
                return;
            _context.Illness_Methods.Remove(entity);
        }

        protected override Dictionary<int, Guid> KeySelector(Illness_Method value) => new Dictionary<int, Guid> { { 0, value.IllnessId }, { 1, value.MethodId } };

        protected override IQueryable<Illness_Method> QueryImplementation()
        {
            return _context.Illness_Methods;
        }

        protected override Illness_Method ReadImplementation(Dictionary<int, Guid> key)
        {
            return QueryImplementation().FirstOrDefault(i => i.IllnessId == key[0] && i.MethodId == key[1]);
        }

        protected override async Task<Illness_Method> ReadImplementationAsync(Dictionary<int, Guid> key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.IllnessId == key[0] && i.MethodId == key[1]);
        }

        protected override void UpdateImplementation(Illness_Method entity, Illness_Method value)
        {
            _context.Update(value);
        }
    }
}
