using Business.Enties.MedicModel.InstitutionModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel.InstitutionModel
{
    public class DepartmentRepository : AbstractRepository<Department, Guid>, IDepartmentRepository
    {
        public DepartmentRepository(Context context)
        {
            _context = context;
        }

        public override List<Department> FromSqlInterpolated(FormattableString sqlCommand) => _context.Departments.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Department> FromSqlRow(FormattableString sqlCommand) => _context.Departments.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(Department value)
        {
            _context.Departments.Add(value);
        }

        protected override async Task CreateImplementationAsync(Department value)
        {
            await _context.Departments.AddAsync(value);
        }

        protected override void DeleteImplementation(Department value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Departments.Remove(entity);
        }

        protected override Guid KeySelector(Department value) => value.Id;

        protected override IQueryable<Department> QueryImplementation()
        {
            return _context.Departments
                                .Include(e => e.Corpus)
                                    .ThenInclude(e => e.Institution)
                                .Include(e => e.ChiefsOfDepartment)
                                .Include(e => e.Medics)
                                .Include(e => e.MedicRegistrators);
        }

        protected override Department ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Department> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Department entity, Department value)
        {
            _context.Update(value);
        }
    }
}
