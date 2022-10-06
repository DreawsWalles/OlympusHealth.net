using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.IllnessModel
{
    public class ResultIllness
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual SignsOfResearch SignsOfResearch { get; set; }
        public virtual IEnumerable<Description> Descriptions { get; set; }
    }
}
