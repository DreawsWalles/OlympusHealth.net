using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel
{
    public class Files
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public virtual Medic Medic { get; set; }
    }
}
