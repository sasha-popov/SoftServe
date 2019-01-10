using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateRecruitment { get; set; }

        //public TeamUser TeamUserId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
