using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel
{
    public class Access
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Medic> Medics { get; set; } = new List<Medic>();
    }
}
