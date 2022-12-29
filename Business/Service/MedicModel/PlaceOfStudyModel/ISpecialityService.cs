using Business.Interop.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public interface ISpecialityService
    {
        public SpecialityDto Create(SpecialityDto entity);
        public SpecialityDto Update(SpecialityDto entity);
        public void Remove(SpecialityDto entity);

        public ICollection<SpecialityDto> GetAll();
        public SpecialityDto GetById(Guid Id);


        public Task<SpecialityDto> CreateAsync(SpecialityDto entity);
        public Task<SpecialityDto> UpdateAsync(SpecialityDto entity);

        public Task<ICollection<SpecialityDto>> GetAllAsync();
        public Task<SpecialityDto> GetByIdAsync(Guid Id);
    }
}
