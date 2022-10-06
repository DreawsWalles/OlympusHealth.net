using Business.Enties.MedicModel;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.Address
{
    [Table("Streets")]
    public class Street
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? NumberOfHouse { get; set; }

        [Required]
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public virtual IEnumerable<Medic>? Medics { get; set; }
        public virtual IEnumerable<AdvancedTrainingCourses>? AdvancedTrainingCourses { get; set; }
        public virtual IEnumerable<HightSchool>? HightSchools { get; set; }
        public virtual IEnumerable<Intership>? Interships { get; set; }
        public virtual IEnumerable<Speciality>? Specialities { get; set; }
        public virtual IEnumerable<Corpus> Corpuses { get; set; }
    }
}
