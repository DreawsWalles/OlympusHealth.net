using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.IllnessModel
{
    public class SignsOfResearch
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public virtual Illness Illness { get; set; }
        public virtual ICollection<ResultIllness> ResultIllnesses { get; set; } = new List<ResultIllness>();
    }
}
