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
    [Table("SysAdmins")]
    [Index("Login", IsUnique = true)]
    public class SysAdmin
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual IEnumerable<HistoryNode>? HistoryNodes { get; set; }
    }
}
