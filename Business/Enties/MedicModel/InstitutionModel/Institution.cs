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
    public class Institution
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public virtual ICollection<Corpus> Corpuses { get; set; } = new List<Corpus>();
    }
}
