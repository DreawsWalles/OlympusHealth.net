using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.PlaceOfStudyModel
{
    [Table("PlaceOfStudies")]
    public class PlaceOfStudy
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime StartEducation { get; set; }

        public DateTime? EndEducation { get; set; }

        [Required]
        [ForeignKey("MedicId")]
        public virtual Medic Medic { get; set; }

        [Required]
        [ForeignKey("SpecializationId")]
        public virtual Specialization Specialization { get; set; }

        [ForeignKey("AdvancedTrainingCoursesId")]
        public virtual AdvancedTrainingCourses? AdvancedTrainingCourses { get; set; }

        [ForeignKey("HightSchoolsId")]
        public virtual HightSchool? HightSchools { get; set; }

        [ForeignKey("IntershipsId")]
        public virtual Intership? Interships { get; set; }

        [ForeignKey("SpecialitiesId")]
        public virtual Speciality? Specialities { get; set; }
    }
}
