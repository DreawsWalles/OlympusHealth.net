using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public interface IStatusOfTheAttributeService
    {
        public StatusOfTheAttributeDto Create(StatusOfTheAttributeDto entity);
        public StatusOfTheAttributeDto Update(StatusOfTheAttributeDto entity);
        public void Remove(StatusOfTheAttributeDto entity);

        public ICollection<StatusOfTheAttributeDto> GetAll();
        public StatusOfTheAttributeDto GetById(Guid Id);

        public Task<StatusOfTheAttributeDto> CreateAsync(StatusOfTheAttributeDto entity);
        public Task<StatusOfTheAttributeDto> UpdateAsync(StatusOfTheAttributeDto entity);
        public Task<ICollection<StatusOfTheAttributeDto>> GetAllAsync();
        public Task<StatusOfTheAttributeDto> GetByIdAsync(Guid Id);
    }
}
