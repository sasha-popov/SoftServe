using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class TeamUser
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
    }
}
