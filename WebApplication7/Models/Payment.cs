using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEPI.Models
{
    public class Payment
    {
        [Key]
        public int Payment_Id { get; set; }
        [ForeignKey("booking")]
        [Required]
        public int Booking_Id { get; set; }
        public Booking booking { get; set; }
        [Required]
        [Display(Name = "Payment Method :")]

        public string Payment_Method { get; set; }
        public int Payment_Status { get; set; }
        [Required]
       
        public int Amount { get; set; }
    }
}
