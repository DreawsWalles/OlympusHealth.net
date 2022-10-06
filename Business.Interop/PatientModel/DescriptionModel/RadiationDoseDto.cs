using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel
{
    public class RadiationDoseDto
    {
        public Guid Id { get; set; }
        public double Dose { get; set; }

        public virtual MethodDto Method { get; set; }
    }
}
