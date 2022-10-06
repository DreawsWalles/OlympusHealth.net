using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel
{
    [Table("RadiationDoses")]
    public class RadiationDose
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public double Dose { get; set; }

        [Required]
        [ForeignKey("MethodId")]
        public virtual Method Method { get; set; }
    }
}
