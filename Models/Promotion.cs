using System;
using System.ComponentModel.DataAnnotations;

namespace LeadsSMS.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Display(Name = "Old Class")]
        public string FromClass { get; set; }

        [Display(Name = "Promoted To")]
        public string ToClass { get; set; }

        [Display(Name = "Promotion Date")]
        [DataType(DataType.Date)]
        public DateTime PromotionDate { get; set; }

        public Student Student { get; set; }
    }
}
