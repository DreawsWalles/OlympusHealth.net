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
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace Business.Service
{
    public class SysAdminService : ISysAdminService 
    {
        private readonly ISysAdminRepository _sysAdminRepository;

        public SysAdminService(ISysAdminRepository sysAdminRepository)
        {
            _sysAdminRepository = sysAdminRepository;
        }

        public SysAdmin Create(RegisterModelSysAdmin entity)
        {
            SysAdmin sysAdmin = new SysAdmin()
            {
                Login = entity.Login,
                Password = entity.Password,
            };
            sysAdmin.Password = new PasswordHasher<SysAdmin>().HashPassword(sysAdmin, entity.Password);
            _sysAdminRepository.Create(sysAdmin);
            return sysAdmin;
        }

        public IEnumerable<SysAdmin> GetAll()
        {
            return _sysAdminRepository.Query();
        }

        public SysAdmin? GetById(Guid id)
        {
            return _sysAdminRepository.Query().FirstOrDefault(e => e.Id == id); //Написть запрос
        }

        public SysAdmin? IsRegistered(LoginModel model)
        {
            SysAdmin sysAdmin = _sysAdminRepository.Query().FirstOrDefault(e => e.Login.Contains(model.Login, StringComparison.InvariantCultureIgnoreCase));
            if (sysAdmin == null)
                return null;
            var tmp = new PasswordHasher<SysAdmin>().VerifyHashedPassword(sysAdmin, sysAdmin.Password, model.Password);
            return tmp == PasswordVerificationResult.Success ? sysAdmin : null;
        }
        public void Remove(SysAdmin sysAdmin)
        {
            _sysAdminRepository.Delete(sysAdmin);
        }

        public SysAdmin Update(SysAdmin updateEntity)
        {
            _sysAdminRepository.Update(updateEntity);
            return updateEntity;
        }
    }
}
