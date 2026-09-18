using System;
using System.ComponentModel.DataAnnotations;

namespace LeadsSMS.Models
{
    public class StudentFee
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Display(Name = "Month")]
        public string FeeMonth { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        // Navigation property (optional)
        public Student Student { get; set; }
    }
}