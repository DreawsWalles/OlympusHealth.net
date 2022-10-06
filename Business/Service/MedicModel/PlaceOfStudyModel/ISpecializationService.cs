using Business.Interop.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public interface ISpecializationService
    {
        public SpecializationDto Create(SpecializationDto entity);
        public SpecializationDto Update(SpecializationDto entity);
        public void Remove(SpecializationDto entity);

        public IEnumerable<SpecializationDto> GetAll();
        public SpecializationDto GetById(Guid id);
    }
}
