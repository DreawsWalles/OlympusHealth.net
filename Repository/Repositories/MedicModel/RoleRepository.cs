using Business.Enties.MedicModel;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Repository.DataRepository.MedicModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel
{
    public class RoleRepository : AbstractRepository<Role, Guid>, IRoleRepository
    {
        public RoleRepository(Context context)
        {
            _context = context;
        }

        public override List<Role> FromSqlInterpolated(FormattableString sqlCommand) => _context.Roles.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Role> FromSqlRow(string sqlCommand) => _context.Roles.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Role value)
        {
            _context.Roles.Add(value);
        }

        protected override async Task CreateImplementationAsync(Role value)
        {
            await _context.Roles.AddAsync(value);
        }

        protected override void DeleteImplementation(Role value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Roles.Remove(entity);
        }

        protected override Guid KeySelector(Role value) => value.Id;

        protected override IQueryable<Role> QueryImplementation()
        {
            return _context.Roles
                                .Include(e => e.Medic); //Здесь реализовать многие ко многим
        }

        protected override Role ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Role> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Role entity, Role value)
        {
            _context.Update(value);
        }
    }
}
