using AutoMapper;
using Business.Enties.MedicModel;
using Business.Interop;
using Business.Repository.DataRepository.MedicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        private static void CheckEntity(Role entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentException(nameof(entity.Name));
        }

        public Role Create(Role entity)
        {
            CheckEntity(entity);
            _roleRepository.Create(entity);
            return entity;
        }

        public async Task<Role> CreateAsync(Role entity)
        {
            CheckEntity(entity);
            await _roleRepository.CreateAsync(entity);
            return entity;
        }

        public ICollection<Role> GetAll()
        {
            return _roleRepository.Query();
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            return await _roleRepository.QueryAsync();
        }

        public Role? GetById(Guid id)
        {
            if(id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _roleRepository.Query().FirstOrDefault(e => e.Id == id);
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            var list = await _roleRepository.QueryAsync();
            return list.FirstOrDefault(e => e.Id == id);
        }

        public void Remove(Role entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            _roleRepository.Delete(entity);
        }

        public Role Update(Role updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            _roleRepository.Update(updateEntity);
            return updateEntity;
        }

        public async Task<Role> UpdateAsync(Role updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            await _roleRepository.CreateOrUpdateAsync(updateEntity);
            return updateEntity;
        }
    }
}
