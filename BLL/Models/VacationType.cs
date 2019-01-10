using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
   public class VacationType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<VacationPolicy> VacationPolicies { get; set; }
    }
}
