using Business.Enties;
using Business.Interop;
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
        public SysAdminDto Create(RegisterModelSysAdmin sysAdmin);
        public SysAdminDto? IsRegistered(LoginModel model);
        public SysAdminDto? FindByLogin(string login);
        public ICollection<SysAdminDto> GetAll();
        public SysAdminDto Update(SysAdminDto updateEntity);
        public SysAdminDto? GetById(Guid id);
        public void Remove(SysAdminDto sysAdmin);
        public void Accept(Guid id);

        public Task<SysAdminDto> CreateAsync(RegisterModelSysAdmin sysAdmin);
        public  Task<SysAdminDto?> IsRegisteredAsync(LoginModel model);
        public Task<SysAdminDto?> FindByLoginAsync(string login);
        public Task<ICollection<SysAdminDto>> GetAllAsync();
        public Task<SysAdminDto> UpdateAsync(SysAdminDto updateEntity);
        public Task<SysAdminDto?> GetByIdAsync(Guid id);
        public Task AcceptAsync(Guid id);
    }
}
