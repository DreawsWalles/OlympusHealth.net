using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.IllnessModel
{
    public class Illness
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Method> Methods { get; set; }
        public virtual IEnumerable<SignsOfResearch> SignsOfResearches { get; set; }
    }
}
