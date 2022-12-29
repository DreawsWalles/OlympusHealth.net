using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public interface IResearchCategoryService
    {
        public ResearchCategoryDto Create(ResearchCategoryDto entity);
        public ResearchCategoryDto Update(ResearchCategoryDto entity);
        public void Remove(ResearchCategoryDto entity);

        public ICollection<ResearchCategoryDto> GetAll();
        public ResearchCategoryDto GetById(Guid id);

        public Task<ResearchCategoryDto> CreateAsync(ResearchCategoryDto entity);
        public Task<ResearchCategoryDto> UpdateAsync(ResearchCategoryDto entity);
        public Task<ICollection<ResearchCategoryDto>> GetAllAsync();
        public Task<ResearchCategoryDto> GetByIdAsync(Guid id);
    }
}
