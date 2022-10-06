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
        public IEnumerable<Role> GetAll();
        public Role? GetById(Guid id);

    }
}
