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
    public class ResultIllnessRepository : AbstractRepository<ResultIllness, Guid>, IResultIllnessRepository
    {
        public ResultIllnessRepository(Context context)
        {
            _context = context;
        }

        public override List<ResultIllness> FromSqlInterpolated(FormattableString sqlCommand) => _context.ResultIllnesses.FromSqlInterpolated(sqlCommand).ToList();

        public override List<ResultIllness> FromSqlRow(FormattableString sqlCommand) => _context.ResultIllnesses.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(ResultIllness value)
        {
            _context.ResultIllnesses.Add(value);
        }

        protected override async Task CreateImplementationAsync(ResultIllness value)
        {
            await _context.ResultIllnesses.AddAsync(value);
        }

        protected override void DeleteImplementation(ResultIllness value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.ResultIllnesses.Remove(entity);
        }

        protected override Guid KeySelector(ResultIllness value) => value.Id;

        protected override IQueryable<ResultIllness> QueryImplementation()
        {
            return _context.ResultIllnesses
                            .Include(e => e.SignsOfResearch)
                                .ThenInclude(e => e.Illness)
                                    .ThenInclude(e => e.Methods);//здесь сделать многие ко многие
        }

        protected override ResultIllness ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<ResultIllness> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(ResultIllness entity, ResultIllness value)
        {
            _context.Update(value);
        }
    }
}
