using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Medic> Medic { get; set; } = new List<Medic>();
    }
}
