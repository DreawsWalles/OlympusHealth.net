using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel
{
    public class ProcessDynamics
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; } = new List<Description>();   
    }
}
