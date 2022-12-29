using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public interface IMethodService
    {
        public MethodDto Create(MethodDto entity);
        public MethodDto Update(MethodDto entity);
        public void Remove(MethodDto entity);

        public ICollection<MethodDto> GetAll();
        public MethodDto GetById(Guid id);

        public Task<MethodDto> CreateAsync(MethodDto entity);
        public Task<MethodDto> UpdateAsync(MethodDto entity);
        public Task<ICollection<MethodDto>> GetAllAsync();
        public Task<MethodDto> GetByIdAsync(Guid id);
    }
}
