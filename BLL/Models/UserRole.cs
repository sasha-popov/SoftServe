using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
