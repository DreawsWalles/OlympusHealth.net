using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop
{
    public class SysAdminDto
    {
        public Guid Id { get; set; }

        public string Login { get; set; }


        public bool Accept { get; set; } = false;
    }
}
