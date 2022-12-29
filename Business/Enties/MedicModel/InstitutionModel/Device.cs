using Business.Enties.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    public class Device
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public virtual Corpus Corpus { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; } = new List<Description>();
    }
}
