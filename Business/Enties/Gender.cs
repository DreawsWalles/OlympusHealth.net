using Business.Enties.MedicModel;
using Business.Enties.PatientModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties
{
    [Table("Genders")]
    [Index("Name", IsUnique = true)]
    public class Gender
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Medic> Medics { get; set; }
        public virtual IEnumerable<Patient> Patients { get; set; }
    }
}
