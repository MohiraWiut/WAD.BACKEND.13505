using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._13505.Models
{
    public class EventCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string? Description { get; set; }
    }
}
