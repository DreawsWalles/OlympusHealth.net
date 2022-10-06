using Business.Enties.MedicModel;
using Business.Enties.PatientModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties
{
    [Table("HistoryNodes")]
    public class HistoryNode
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string? File { get; set; }

        [ForeignKey("SysAdminId")]
        public virtual SysAdmin? SysAdmin { get; set; }

        [ForeignKey("MedicId")]
        public virtual Medic? Medic { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient? Patient { get; set; }
    }
}
