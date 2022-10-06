using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel
{
    public class PatientDto
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

        public virtual GenderDto Gender { get; set; }
        public virtual IEnumerable<OutpatientCardDto>? OutpatientCards { get; set; }
        public virtual IEnumerable<ResearchAreaDto>? ResearchAreas { get; set; }
    }
}
