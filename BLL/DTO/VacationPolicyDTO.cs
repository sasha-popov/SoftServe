using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class VacationPolicyDTO
    {
        public int Id { get; set; }
        public string VacationType { get; set; }
        public int WorkingYear { get; set; }
        public int Count { get; set; }
        public string Payments { get; set; }
    }
}
