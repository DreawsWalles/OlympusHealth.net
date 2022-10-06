﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel.IllnessModel
{
    public class ResultIllnessDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual SignsOfResearchDto SignsOfResearch { get; set; }
        public virtual IEnumerable<DescriptionDto> Descriptions { get; set; }
    }
}
