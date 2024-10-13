using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication7.Models;

namespace DEPI.Models
{
    public class Booking
    {
        [Key]
        public int booking_Id { get; set; }
        [ForeignKey("user")]
        public string User_ID {  get; set; }
        public User user { get; set; }
        [ForeignKey("place")]
        [Required]
        public int Place_ID { get; set; }
        public Place place { get; set; }
        [Display(Name = "Promotion Code:")]

        public string? promotion_Code { get; set; }

        public bool? payment_state {  get; set; }
        public int total_amount {  get; set; }
        [Display(Name = "Number of dayes :")]
        public int? total_Dayes { get; set; }
    }
}
