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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel
{
    public class Medic
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }

        public DateTime DateEmployment { get; set; }
        public DateTime? DateDismissal { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateBirthday { get; set; }

        public virtual Gender Gender { get; set; }


        public virtual Role Role { get; set; }
        public virtual ICollection<HistoryNode> HistoryNodes { get; set; } = new List<HistoryNode>();

        public virtual Street Address { get; set; }
        public virtual ICollection<Files> Files { get; set; } = new List<Files>();
        public virtual ICollection<PlaceOfStudy> PlaceOfStudies { get; set; } = new List<PlaceOfStudy>();
        public virtual ICollection<Department> HeadOfDepartment { get; set; } = new List<Department>();
        public virtual Department? Doctors { get; set; }
        public virtual Department? MedicRegistrator { get; set; }

        public virtual ICollection<Description> DesctioptionHeadOfDepartment { get; set; } = new List<Description>();

        public virtual ICollection<Description> Descriptions { get; set; } = new List<Description>();

        public virtual ICollection<Corpus> Corpuses { get; set; } = new List<Corpus>();

        public bool Accept { get; set; } = false;

        public virtual ICollection<Access> AccessRights { get; set; } = new List<Access>();
    }
}
