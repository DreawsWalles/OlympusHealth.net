using Business.Enties;
using Business.Interop.Autefication;
using Business.Interop.DoctorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface ISysAdminService
    {
        public SysAdmin Create(RegisterModelSysAdmin sysAdmin);
        public SysAdmin? IsRegistered(LoginModel model);
        public ICollection<SysAdmin> GetAll();
        public SysAdmin Update(SysAdmin updateEntity);
        public SysAdmin? GetById(Guid id);
        public void Remove(SysAdmin sysAdmin);

        public Task<SysAdmin> CreateAsync(RegisterModelSysAdmin sysAdmin);
        public  Task<SysAdmin?> IsRegisteredAsync(LoginModel model);
        public Task<ICollection<SysAdmin>> GetAllAsync();
        public Task<SysAdmin> UpdateAsync(SysAdmin updateEntity);
        public Task<SysAdmin?> GetByIdAsync(Guid id);
    }
}
