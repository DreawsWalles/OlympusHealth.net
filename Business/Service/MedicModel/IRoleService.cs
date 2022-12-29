using Business.Enties.MedicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel
{
    public interface IRoleService
    {
        public Role Create(Role entity);
        public Role Update(Role updateEntity);
        public void Remove(Role entity);
        public ICollection<Role> GetAll();
        public Role? GetById(Guid id);

        public Task<Role> CreateAsync(Role entity);
        public Task<Role> UpdateAsync(Role updateEntity);
        public Task<ICollection<Role>> GetAllAsync();
        public Task<Role?> GetByIdAsync(Guid id);

    }
}
