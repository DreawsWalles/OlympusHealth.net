using AutoMapper;
using Business.Enties;
using Business.Interop.Autefication;
using Business.Repository.DataRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Service
{
    public class SysAdminService : ISysAdminService 
    {
        private readonly ISysAdminRepository _sysAdminRepository;

        public SysAdminService(ISysAdminRepository sysAdminRepository)
        {
            _sysAdminRepository = sysAdminRepository ?? throw new ArgumentNullException(nameof(sysAdminRepository));
        }

        private static void CheckEntity(SysAdmin sysAdmin)
        {
            if (sysAdmin == null)
                throw new ArgumentNullException(nameof(sysAdmin));
            if(sysAdmin.Login == null || sysAdmin.Login.Trim() == "")
                throw new ArgumentNullException(nameof(sysAdmin.Login));
            if(sysAdmin.Password == null || sysAdmin.Password.Trim() == "")
                throw new ArgumentNullException(nameof(sysAdmin.Password));
        }
        private static void checkEntity(RegisterModelSysAdmin entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if(entity.Login == null || entity.Login.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Password == null || entity.Password.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Password));
        }
        private static void checkEntity(LoginModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Login == null || entity.Login.Trim() == "" )
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Password == null || entity.Password.Trim() == "" )
                throw new ArgumentNullException(nameof(entity.Password));
        }
        public SysAdmin Create(RegisterModelSysAdmin entity)
        {
            checkEntity(entity);
            SysAdmin sysAdmin = new()
            {
                Login = entity.Login,
                Password = entity.Password,
            };
            sysAdmin.Password = new PasswordHasher<SysAdmin>().HashPassword(sysAdmin, entity.Password);
            _sysAdminRepository.Create(sysAdmin);
            return sysAdmin;
        }

        public async Task<SysAdmin> CreateAsync(RegisterModelSysAdmin entity)
        {
            checkEntity(entity);
            SysAdmin sysAdmin = new()
            {
                Login = entity.Login,
                Password = entity.Password,
            };
            sysAdmin.Password = new PasswordHasher<SysAdmin>().HashPassword(sysAdmin, entity.Password);
            await _sysAdminRepository.CreateAsync(sysAdmin);
            return sysAdmin;
        }

        public ICollection<SysAdmin> GetAll()
        {
            return _sysAdminRepository.Query();
        }

        public async Task<ICollection<SysAdmin>> GetAllAsync()
        {
            return await _sysAdminRepository.QueryAsync();
        }

        public SysAdmin? GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException("id");
            return _sysAdminRepository.Query().FirstOrDefault(e => e.Id == id); 
        }

        public async Task<SysAdmin?> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException("id");
            var query = await _sysAdminRepository.QueryAsync();
            return query.FirstOrDefault(e => e.Id == id);
        }

        public SysAdmin? IsRegistered(LoginModel model)
        {
            checkEntity(model);
            SysAdmin sysAdmin = _sysAdminRepository.Query().FirstOrDefault(e => e.Login.Contains(model.Login, StringComparison.InvariantCultureIgnoreCase));
            if (sysAdmin == null)
                return null;
            var tmp = new PasswordHasher<SysAdmin>().VerifyHashedPassword(sysAdmin, sysAdmin.Password, model.Password);
            return tmp == PasswordVerificationResult.Success ? sysAdmin : null;
        }

        public async Task<SysAdmin?> IsRegisteredAsync(LoginModel model)
        {
            checkEntity(model);
            var query = await _sysAdminRepository.QueryAsync();
            SysAdmin? sysAdmin = query.FirstOrDefault(e => e.Login.Contains(model.Login, StringComparison.InvariantCultureIgnoreCase));
            if (sysAdmin == null)
                return null;
            var tmp = new PasswordHasher<SysAdmin>().VerifyHashedPassword(sysAdmin, sysAdmin.Password, model.Password);
            return tmp == PasswordVerificationResult.Success ? sysAdmin : null;
        }

        public void Remove(SysAdmin sysAdmin)
        {
            CheckEntity(sysAdmin);
            if (sysAdmin.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(sysAdmin.Id));
            _sysAdminRepository.Delete(sysAdmin);
        }

        public SysAdmin Update(SysAdmin updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            _sysAdminRepository.Update(updateEntity);
            return updateEntity;
        }

        public async Task<SysAdmin> UpdateAsync(SysAdmin updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            await _sysAdminRepository.CreateOrUpdateAsync(updateEntity);
            return updateEntity;
        }
    }
}
