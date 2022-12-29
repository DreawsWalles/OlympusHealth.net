using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public interface ISignsOfResearchService
    {
        public SignsOfResearchDto Create(SignsOfResearchDto entity);
        public SignsOfResearchDto Update(SignsOfResearchDto entity);
        public void Remove(SignsOfResearchDto entity);

        public ICollection<SignsOfResearchDto> GetAll();
        public SignsOfResearchDto GetById(Guid Id);

        public Task<SignsOfResearchDto> CreateAsync(SignsOfResearchDto entity);
        public Task<SignsOfResearchDto> UpdateAsync(SignsOfResearchDto entity);
        public Task<ICollection<SignsOfResearchDto>> GetAllAsync();
        public Task<SignsOfResearchDto> GetByIdAsync(Guid Id);
    }

}
