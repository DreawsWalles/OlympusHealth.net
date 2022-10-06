using AutoMapper;
using Business.Enties.MedicModel;
using Business.Repository.DataRepository.MedicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role Create(Role entity)
        {
            _roleRepository.Create(entity);
            return entity;
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.Query();
        }

        public Role? GetById(Guid id)
        {
            return _roleRepository.Query().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(Role entity)
        {
            _roleRepository.Delete(entity);
        }

        public Role Update(Role updateEntity)
        {
            _roleRepository.Update(updateEntity);
            return updateEntity;
        }
    }
}
