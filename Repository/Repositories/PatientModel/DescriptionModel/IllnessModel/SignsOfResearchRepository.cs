using Business.Enties.PatientModel.DescriptionModel;
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
    public class SignsOfResearchRepository : AbstractRepository<SignsOfResearch, Guid>, ISignsOfResearchRepository
    {
        public SignsOfResearchRepository(Context context)
        {
            _context = context;
        }

        public override List<SignsOfResearch> FromSqlInterpolated(FormattableString sqlCommand) => _context.SignsOfResearch.FromSqlInterpolated(sqlCommand).ToList();

        public override List<SignsOfResearch> FromSqlRow(FormattableString sqlCommand) => _context.SignsOfResearch.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(SignsOfResearch value)
        {
            _context.SignsOfResearch.Add(value);
        }

        protected override async Task CreateImplementationAsync(SignsOfResearch value)
        {
            await _context.SignsOfResearch.AddAsync(value);
        }

        protected override void DeleteImplementation(SignsOfResearch value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.SignsOfResearch.Remove(entity);
        }

        protected override Guid KeySelector(SignsOfResearch value) => value.Id;

        protected override IQueryable<SignsOfResearch> QueryImplementation()
        {
            return _context.SignsOfResearch
                            .Include(e => e.Illness)
                                .ThenInclude(e => e.Methods); //здесь сделать многие ко многие
        }

        protected override SignsOfResearch ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<SignsOfResearch> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(SignsOfResearch entity, SignsOfResearch value)
        {
            _context.Update(value);
        }
    }
}
