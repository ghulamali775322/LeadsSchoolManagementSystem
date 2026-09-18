using System;
using System.ComponentModel.DataAnnotations;

namespace LeadsSMS.Models
{
    public class EmployeeAttendance
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public string Status { get; set; } // Present / Absent / Leave
    }
}
