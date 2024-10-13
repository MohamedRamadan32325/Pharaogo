using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication7.Models;

namespace DEPI.Models
{
    public class Review
    {
        [Key]
        public int Review_Id { get; set; }
        [ForeignKey("user")]
        public string User_ID { get; set; }
        public User user { get; set; }
        [ForeignKey("place")]
        public int Place_Id { get; set; }
        public Place place { get; set; }
        public string? Comment {  get; set; }
        [Required]
        public int Rating { get; set; }
        public DateTime? Date { get; set; }
    }
}
