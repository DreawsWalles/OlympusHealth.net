using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    [Table("Corpuses_Medics")]
    [PrimaryKey("CorpusId", "MedicId")]
    public class Corpus_Medic
    {
        [Column(Order = 1)]
        public Guid CorpusId { get; set; }

        [Column(Order = 2)]
        public Guid MedicId { get; set; }

        [Required]
        [ForeignKey("CorpusId")]
        public Corpus Corpus { get; set; }

        [ForeignKey("MedicId")]
        public Medic Medic { get; set; }
    }
}
