using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel
{
    public class ProcessDynamics
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Description> Descriptions { get; set; }
    }
}
