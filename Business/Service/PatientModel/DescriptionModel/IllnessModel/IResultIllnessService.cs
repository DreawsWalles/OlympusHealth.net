using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public interface IResultIllnessService
    {
        public ResultIllnessDto Create(ResultIllnessDto entity);
        public ResultIllnessDto Update(ResultIllnessDto entity);
        public void Remove(ResultIllnessDto entity);

        public ICollection<ResultIllnessDto> GetAll();
        public ResultIllnessDto GetById(Guid Id);


        public Task<ResultIllnessDto> CreateAsync(ResultIllnessDto entity);
        public Task<ResultIllnessDto> UpdateAsync(ResultIllnessDto entity);
        public Task<ICollection<ResultIllnessDto>> GetAllAsync();
        public Task<ResultIllnessDto> GetByIdAsync(Guid Id);
    }
}
