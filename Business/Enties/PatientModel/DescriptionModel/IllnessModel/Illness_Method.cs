using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.IllnessModel
{
    [Table("Illness_Methods")]
    [PrimaryKey("IllnessId", "MethodId")]
    public class Illness_Method
    {
        [Column(Order = 1)]
        public Guid IllnessId { get; set; }

        [Column(Order = 2)]
        public Guid MethodId { get; set; }

        [Required]
        [ForeignKey("IllnessId")]
        public virtual Illness Illness { get; set; }

        [Required]
        [ForeignKey("MethodId")]
        public virtual Method Method { get; set; }
    }
}
