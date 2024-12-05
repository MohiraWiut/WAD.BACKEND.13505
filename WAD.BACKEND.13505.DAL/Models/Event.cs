using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._13505.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [MaxLength(100, ErrorMessage = "Event name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        public string Location { get; set; }

        public int? EventCategoryId { get; set; }

        [ForeignKey("EventCategoryId")]
        public EventCategory? EventCategory { get; set; }
    }
}
