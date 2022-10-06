using Business.Interop.ChiefOfMedicineModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.InstitutionModel
{
    public class Corpus_MedicDto
    {
        public Guid CorpusId { get; set; }
        public Guid MedicId { get; set; }
        public CorpusDto Corpus { get; set; }
        public ChiefOfMedicine ChiefOfMedicine { get; set; }
    }
}
