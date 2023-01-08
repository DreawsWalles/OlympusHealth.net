using Business.Interop.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Autefication
{
    public class RegisterModelUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual GenderDto Gender { get; set; }
        public virtual StreetDto? Street { get; set; }
        public virtual string? City { get; set; }   
        public virtual string? Region { get; set; }
        public virtual string? Country { get; set; }    
        public string? Role { get; set; }
        public RoleDto? RoleMedic { get; set; }
    }
}
