using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.IllnessModel
{
    [Table("SignsOfResearches")]
    public class SignsOfResearch
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [ForeignKey("IllnessId")]
        public virtual Illness Illness { get; set; }
        public virtual IEnumerable<ResultIllness> ResultIllnesses { get; set; }
    }
}
