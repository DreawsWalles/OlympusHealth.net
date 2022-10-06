using Business.Interop.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public interface IAdvancedTrainingCourcesService
    {
        public AdvancedTrainingCoursesDto Create(AdvancedTrainingCoursesDto entity);
        public AdvancedTrainingCoursesDto Update(AdvancedTrainingCoursesDto entity);
        public void Remove(AdvancedTrainingCoursesDto entity);

        public IEnumerable<AdvancedTrainingCoursesDto> GetAll();
        public AdvancedTrainingCoursesDto GetBuId(Guid Id);
    }
}
