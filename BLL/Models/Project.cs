using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
   public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }

    }
}
