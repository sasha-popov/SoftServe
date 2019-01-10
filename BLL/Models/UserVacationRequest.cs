using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
   public class UserVacationRequest
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationType VacationType { get; set; }

        public int Payment { get; set; }
        public int Status { get; set; }
    }
}
