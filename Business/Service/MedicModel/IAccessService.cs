using Business.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel
{
    public interface IAccessService
    {
        public AccessDto Create(AccessDto access);
        public AccessDto Update(AccessDto access);
        public void Remove(AccessDto access);

        public AccessDto GetById(Guid id);
        public ICollection<AccessDto> GetAll();

        public Task<AccessDto> CreateAsync(AccessDto access);
        public Task<AccessDto> UpdateASync(AccessDto access);

        public Task<AccessDto> GetByIdAsync(Guid id);
        public Task<ICollection<AccessDto>> GetAllAsync();
    }
}
