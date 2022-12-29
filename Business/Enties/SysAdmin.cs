using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties
{
    public class SysAdmin
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<HistoryNode> HistoryNodes { get; set; } = new List<HistoryNode>();

        public bool Accept { get; set; } = false;
    }
}
