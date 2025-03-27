using System.ComponentModel.DataAnnotations;

namespace BookStore1.API.DTOs.Book
{
    public class BookEditDtos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} characters")]
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public double Value { get; set; }

    }
}
