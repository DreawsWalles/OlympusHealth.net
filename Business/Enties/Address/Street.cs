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
    public class Street
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? NumberOfHouse { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Medic> Medics { get; set; } = new List<Medic>();
        public virtual ICollection<AdvancedTrainingCourses> AdvancedTrainingCourses { get; set; } = new List<AdvancedTrainingCourses>();
        public virtual ICollection<HightSchool> HightSchools { get; set; } = new List<HightSchool>();
        public virtual ICollection<Intership> Interships { get; set; } = new List<Intership>();
        public virtual ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();
        public virtual ICollection<Corpus> Corpuses { get; set; } = new List<Corpus>();
    }
}
