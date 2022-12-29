using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    public class Department
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public virtual Corpus Corpus { get; set; }
        public virtual Medic? ChiefsOfDepartment { get; set; }

        public virtual ICollection<Medic> Medics { get; set; } = new List<Medic>();

        public virtual ICollection<Medic> MedicRegistrators { get; set; } = new List<Medic>();
    }
}
