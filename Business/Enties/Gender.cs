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
    public class Gender
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Medic> Medics { get; set; } = new List<Medic>();
        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
