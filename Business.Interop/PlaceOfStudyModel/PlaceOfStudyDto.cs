using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PlaceOfStudyModel
{
    public class PlaceOfStudyDto
    {
        public Guid Id { get; set; }
        public DateTime StartEducation { get; set; }
        public DateTime? EndEducation { get; set; }

        public virtual ChiefOfMedicine? Medic { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual HeadOfDepartment? HeadOfDepartment { get; set; }
        public virtual MedicRegistrator? MedicRegistrator { get; set; }
        public virtual SpecializationDto Specialization { get; set; }
        public virtual AdvancedTrainingCoursesDto? AdvancedTrainingCourses { get; set; }
        public virtual HightSchoolDto? HightSchools { get; set; }
        public virtual IntershipDto? Interships { get; set; }
        public virtual SpecialityDto? Specialities { get; set; }
    }
}
