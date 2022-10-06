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
    [Table("ResultIllnesses")]
    [Index("Name", IsUnique = true)]
    public class ResultIllness
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("SignsOfResearchId")]
        public virtual SignsOfResearch SignsOfResearch { get; set; }
        public virtual IEnumerable<Description> Descriptions { get; set; }
    }
}
