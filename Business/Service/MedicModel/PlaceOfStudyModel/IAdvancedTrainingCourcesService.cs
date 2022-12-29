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

        public ICollection<AdvancedTrainingCoursesDto> GetAll();
        public AdvancedTrainingCoursesDto GetById(Guid Id);

        public Task<AdvancedTrainingCoursesDto> CreateAsync(AdvancedTrainingCoursesDto entity);
        public Task<AdvancedTrainingCoursesDto> UpdateAsync(AdvancedTrainingCoursesDto entity);

        public Task<ICollection<AdvancedTrainingCoursesDto>> GetAllAsync();
        public Task<AdvancedTrainingCoursesDto> GetByIdAsync(Guid Id);
    }
}
