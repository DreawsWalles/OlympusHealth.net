using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interop.PlaceOfStudyModel;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public interface IPlaceOfStudyService
    {
        public PlaceOfStudyDto Create(PlaceOfStudyDto entity);
        public PlaceOfStudyDto Update(PlaceOfStudyDto entity);
        public void Remove(PlaceOfStudyDto entity);

        public IEnumerable<PlaceOfStudyDto> GetAll();
        public PlaceOfStudyDto FindById(Guid id);
    }
}
