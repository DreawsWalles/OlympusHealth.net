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
    public class IllnessRepository : AbstractRepository<Illness, Guid>, IIllnessRepository
    {
        public IllnessRepository(Context context)
        {
            _context = context;
        }

        public override List<Illness> FromSqlInterpolated(FormattableString sqlCommand) => _context.Illnesses.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Illness> FromSqlRow(string sqlCommand) => _context.Illnesses.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Illness value)
        {
            _context.Illnesses.Add(value);
        }

        protected override async Task CreateImplementationAsync(Illness value)
        {
            await _context.Illnesses.AddAsync(value);
        }

        protected override void DeleteImplementation(Illness value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Illnesses.Remove(entity);
        }

        protected override Guid KeySelector(Illness value) => value.Id;

        protected override IQueryable<Illness> QueryImplementation()
        {
            return _context.Illnesses
                            .Include(e => e.Methods);//здесь сделать многие ко многие
        }

        protected override Illness ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Illness> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Illness entity, Illness value)
        {
            _context.Update(value);
        }
    }
}
