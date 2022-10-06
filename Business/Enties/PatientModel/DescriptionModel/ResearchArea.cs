using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel
{
    [Table("ResearchAreas")]
    [Index("Patient", IsUnique = true)]
    public class ResearchArea
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        public virtual IEnumerable<Description>? Descriptions { get; set; }
        public virtual IEnumerable<Method> Methods { get; set; }
    }
}
