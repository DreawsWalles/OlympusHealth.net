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
    public class HistoryNode
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string? File { get; set; }

        public virtual SysAdmin? SysAdmin { get; set; }

        public virtual Medic? Medic { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
