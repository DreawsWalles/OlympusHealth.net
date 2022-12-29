using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.PlaceOfStudyModel
{
    public class PlaceOfStudy
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime StartEducation { get; set; }

        public DateTime? EndEducation { get; set; }

        public virtual Medic Medic { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual AdvancedTrainingCourses AdvancedTrainingCourses { get; set; }

        public virtual HightSchool HightSchools { get; set; }

        public virtual Intership Interships { get; set; }

        public virtual Speciality Specialities { get; set; }
    }
}
