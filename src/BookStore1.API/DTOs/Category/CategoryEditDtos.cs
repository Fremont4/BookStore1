using System.ComponentModel.DataAnnotations;

namespace BookStore1.API.DTOs.Category
{
    public class CategoryEditDtos
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} characters")]
        public string Name { get; set; }
    }
}
