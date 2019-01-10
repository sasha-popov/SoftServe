using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
