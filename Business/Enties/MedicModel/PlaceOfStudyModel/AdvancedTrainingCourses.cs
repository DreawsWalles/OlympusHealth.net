using Business.Enties.Address;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.PlaceOfStudyModel
{
    [Index("Name", IsUnique = true)]
    public class AdvancedTrainingCourses
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public virtual Street Street { get; set; }

        public virtual ICollection<PlaceOfStudy> PlaceOfStudies { get; set; } = new List<PlaceOfStudy>();
    }
}
