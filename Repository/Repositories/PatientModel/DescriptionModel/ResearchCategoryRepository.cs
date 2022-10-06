using Business.Enties.PatientModel;
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
    public class ResearchCategoryRepository : AbstractRepository<ResearchCategory, Guid>, IResearchCategoryRepository
    {
        public ResearchCategoryRepository(Context context)
        {
            _context = context;
        }
        public override List<ResearchCategory> FromSqlInterpolated(FormattableString sqlCommand) => _context.ResearchCategories.FromSqlInterpolated(sqlCommand).ToList();


        public override List<ResearchCategory> FromSqlRow(string sqlCommand) => _context.ResearchCategories.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(ResearchCategory value)
        {
            _context.ResearchCategories.Add(value);
        }

        protected override async Task CreateImplementationAsync(ResearchCategory value)
        {
            await _context.ResearchCategories.AddAsync(value);
        }

        protected override void DeleteImplementation(ResearchCategory value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.ResearchCategories.Remove(entity);
        }

        protected override Guid KeySelector(ResearchCategory value) => value.Id;

        protected override IQueryable<ResearchCategory> QueryImplementation()
        {
            return _context.ResearchCategories
                            .Include(e => e.Methods); //здесь через многие ко многим
        }

        protected override ResearchCategory ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<ResearchCategory> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(ResearchCategory entity, ResearchCategory value)
        {
            _context.Update(value);
        }
    }
}
