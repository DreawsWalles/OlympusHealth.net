﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.IllnessModel
{
    public class ResultIllness
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public virtual SignsOfResearch SignsOfResearch { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; } = new List<Description>();
    }
}
