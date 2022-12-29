using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public interface IIllnessService
    {
        public IllnessDto Create(IllnessDto entity);
        public IllnessDto Update(IllnessDto entity);
        public void Remove(IllnessDto entity);

        public ICollection<IllnessDto> GetAll();
        public IllnessDto GetById(Guid Id);

        public Task<IllnessDto> CreateAsync(IllnessDto entity);
        public Task<IllnessDto> UpdateAsync(IllnessDto entity);
        public Task<ICollection<IllnessDto>> GetAllAsync();
        public Task<IllnessDto> GetByIdAsync(Guid Id);
    }
}
