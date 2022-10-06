using Business.Enties.Address;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Enties.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel
{
    [Table("Medics")]
    [Index(new [] { "Login", "Email", "PhoneNumber" }, IsUnique = true)]
    public class Medic
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surnane { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }

        [Required]
        public DateTime DateEmployment { get; set; }
        public DateTime? DateDismissal { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateBirthday { get; set; }

        [Required]
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        [Required]
        [ForeignKey("GenderId")]
        public virtual Role Role { get; set; }
        public virtual IEnumerable<HistoryNode>? HistoryNodes { get; set; }

        [Required]
        [ForeignKey("AddressId")]
        public virtual Street? Address { get; set; }
        public virtual IEnumerable<Files>? Files { get; set; }
        public virtual IEnumerable<PlaceOfStudy>? PlaceOfStudies { get; set; }
        public virtual IEnumerable<Department>? HeadOfDepartment { get; set; }
        public virtual Department? Doctors { get; set; }
        public virtual Department? MedicRegistrator { get; set; }

        [InverseProperty("HeadOfDepartment")]
        public virtual IEnumerable<Description>? DesctioptionHeadOfDepartment { get; set; }

        [InverseProperty("Doctor")]
        public virtual IEnumerable<Description>? Descriptions { get; set; }

        public virtual IEnumerable<Corpus_Medic> Corpus_Medics { get; set; }

        [NotMapped]
        public virtual IEnumerable<Corpus>? Corpuses { get; set; }
    }
}
