using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserVacationRequestDTO
    {
        public int Id { get; set; }
        public int User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VacationType { get; set; }
        public string Status { get; set; }
    }
}
