using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel
{
    [Table("Files")]
    public class Files
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("MedicId")]
        public virtual Medic Medic { get; set; }
    }
}
