using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class VacationPolicy
    {
        public int Id { get; set; }
        public int WorkingYear { get; set; }
        public VacationType VacationType { get; set; }
        public int Count { get; set; }
        public int Payments { get; set; }
    }
}
