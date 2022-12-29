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
    public class ResearchAreaRepository : AbstractRepository<ResearchArea, Guid>, IResearchAreaRepository
    {
        public ResearchAreaRepository(Context context)
        {
            _context = context;
        }

        public override List<ResearchArea> FromSqlInterpolated(FormattableString sqlCommand) => _context.ResearchAreas.FromSqlInterpolated(sqlCommand).ToList();

        public override List<ResearchArea> FromSqlRow(FormattableString sqlCommand) => _context.ResearchAreas.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(ResearchArea value)
        {
            _context.ResearchAreas.Add(value);
        }

        protected override async Task CreateImplementationAsync(ResearchArea value)
        {
            await _context.ResearchAreas.AddAsync(value);
        }

        protected override void DeleteImplementation(ResearchArea value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.ResearchAreas.Remove(entity);
        }

        protected override Guid KeySelector(ResearchArea value) => value.Id;

        protected override IQueryable<ResearchArea> QueryImplementation()
        {
            return _context.ResearchAreas
                            .Include(e => e.Methods); //здесь через многие ко многим
        }

        protected override ResearchArea ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<ResearchArea> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(ResearchArea entity, ResearchArea value)
        {
            _context.Update(value);
        }
    }
}
