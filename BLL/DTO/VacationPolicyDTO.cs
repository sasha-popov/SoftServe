using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO
{
    public class VacationPolicyDTO
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Vacation type is required")]
        public string VacationType { get; set; }
        [Required(ErrorMessage = "Working is required")]
        public int WorkingYear { get; set; }
        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }
        [Required(ErrorMessage = "Payments is required")]
        public string Payments { get; set; }
    }
}
