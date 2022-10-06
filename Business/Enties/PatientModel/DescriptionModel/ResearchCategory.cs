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
    [Table("ResearchCategories")]
    [Index("Name", IsUnique = true)]
    public class ResearchCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Method> Methods { get; set; }
    }
}
