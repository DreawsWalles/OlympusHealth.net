using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel
{
    public class RadiationDose
    {
        public Guid Id { get; set; }

        public double Dose { get; set; }

        public virtual Method Method { get; set; }
    }
}
