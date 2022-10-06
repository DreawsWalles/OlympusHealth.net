using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    [Table("Method_DescriptionsOfSigns")]
    [PrimaryKey("MethodId", "DescriptionOfSighsId")]
    public class Method_DescriptionOfSigns
    {
        [Column(Order = 1)]
        public Guid MethodId { get; set; }

        [Column(Order = 2)]
        public Guid DescriptionOfSighsId { get; set; }

        [Required]
        [ForeignKey("MethodId")]
        public virtual Method Method { get; set; }

        [Required]
        [ForeignKey("DescriptionOfSighsId")]
        public virtual DescriptionOfSigns DescriptionOfSigns { get; set; }
    }
}
