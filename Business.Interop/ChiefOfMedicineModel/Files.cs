﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.ChiefOfMedicineModel
{
    public class Files
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public virtual ChiefOfMedicine Medic { get; set; }
    }
}
