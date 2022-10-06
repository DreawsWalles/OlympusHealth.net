using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.InstitutionModel
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual CorpusDto Corpus { get; set; }
    }
}
