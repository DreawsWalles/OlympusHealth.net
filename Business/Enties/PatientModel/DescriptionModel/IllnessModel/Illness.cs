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
    [Table("Illnesses")]
    [Index("Name", IsUnique = true)]
    public class Illness
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Method> Methods { get; set; }
        public virtual IEnumerable<SignsOfResearch> SignsOfResearches { get; set; }
    }
}
