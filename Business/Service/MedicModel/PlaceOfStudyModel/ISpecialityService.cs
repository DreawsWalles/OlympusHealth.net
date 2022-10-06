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

        public IEnumerable<SpecialityDto> GetAll();
        public SpecialityDto GetById(Guid Id);
    }
}
