using Business.Enties.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel
{
    [Table("Patients")]
    [Index(new[] { "Login", "Email", "PhoneNumber" }, IsUnique = true)]
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }

        [Required]
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }
        public virtual IEnumerable<HistoryNode>? HistoryNodes { get; set; }
        public virtual IEnumerable<OutpatientCard>? OutpatientCards { get; set; }
        public virtual IEnumerable<ResearchArea> ResearchAreas { get; set; }
    }
}
