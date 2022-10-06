using Business.Enties.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel
{
    [Table("OutpatientCards")]
    public class OutpatientCard
    {
        [Key]
        public Guid Id { get; set; }
        public string? File { get; set; }
        public string? Text { get; set; }

        [Required]
        public DateTime DateLastAdmission { get; set; }
        public DateTime? DateNextAdmission { get; set; }

        [Required]
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [Required]
        [ForeignKey("ResearchAreaId")]
        public virtual ResearchArea? ResearchArea { get; set; }
    }
}
