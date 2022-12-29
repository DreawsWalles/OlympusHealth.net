using Business.Enties.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    public class Corpus
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual Institution Institution { get; set; }

        public virtual Street Street { get; set; }
        public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

        public virtual Medic Medics { get; set; }
    }
}
