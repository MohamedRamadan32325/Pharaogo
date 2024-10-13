using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEPI.Models
{
    public class Promotion
    {
        [Key]
        public int promotion_Id { get; set; }
        [Display(Name = "Promotion Code :")]
        [Required]

        public string promotion_Code { get;set; }
        [Display(Name = "Discount Amount :")]
        public int Discount_Amount {  get; set; }
        [ForeignKey("booking")]
        public int booking_ID {  get; set; }
        public Booking booking { get; set; }
    }
}
