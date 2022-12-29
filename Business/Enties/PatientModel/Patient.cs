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
    public class Patient
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }


        public virtual Gender Gender { get; set; }
        public virtual ICollection<HistoryNode> HistoryNodes { get; set; } = new List<HistoryNode>();
        public virtual ICollection<OutpatientCard> OutpatientCards { get; set; } = new List<OutpatientCard>();
        public virtual ICollection<ResearchArea> ResearchAreas { get; set; } = new List<ResearchArea>();
    }
}
