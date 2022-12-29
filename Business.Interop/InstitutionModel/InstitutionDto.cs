using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.InstitutionModel
{
    public class InstitutionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<CorpusDto> Corpuses { get; set; }
    }
}
