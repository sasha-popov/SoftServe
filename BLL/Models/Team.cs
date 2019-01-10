using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //check if user have a status "Manager"
        public User Manager { get; set; }

        public ICollection<Project> Projects { get; set; }
        //add only employees
        public ICollection<TeamUser> TeamUsers { get; set; }
    }
}
