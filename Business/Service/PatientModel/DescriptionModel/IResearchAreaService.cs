using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public interface IResearchAreaService
    {
        public ResearchAreaDto Create(ResearchAreaDto entity);
        public ResearchAreaDto Update(ResearchAreaDto entity);
        public void Remove(ResearchAreaDto entity);

        public ICollection<ResearchAreaDto> GetAll();
        public ResearchAreaDto GetById(Guid id);

        public Task<ResearchAreaDto> CreateAsync(ResearchAreaDto entity);
        public Task<ResearchAreaDto> UpdateAsync(ResearchAreaDto entity);
        public Task<ICollection<ResearchAreaDto>> GetAllAsync();
        public Task<ResearchAreaDto> GetByIdAsync(Guid id);
    }
}
