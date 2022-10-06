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
    [Table("ProcessDynamicses")]
    [Index("Name", IsUnique = true)]
    public class ProcessDynamics
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Description> Descriptions { get; set; }
    }
}
