using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.EntityLayer.Concrete
{
    public class Role
    {
        public int RoleId { get; set; }
        public int UserRoleId { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
