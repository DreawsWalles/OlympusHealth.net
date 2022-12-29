using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public interface IDescriptionService
    {
        public DescriptionDto Create(DescriptionDto entity);
        public DescriptionDto Update(DescriptionDto entity);
        public void Remove(DescriptionDto entity);

        public ICollection<DescriptionDto> GetAll();
        public DescriptionDto GetById(Guid id);

        public Task<DescriptionDto> CreateAsync(DescriptionDto entity);
        public Task<DescriptionDto> UpdateAsync(DescriptionDto entity);
        public Task<ICollection<DescriptionDto>> GetAllAsync();
        public Task<DescriptionDto> GetByIdAsync(Guid id);
    }
}
