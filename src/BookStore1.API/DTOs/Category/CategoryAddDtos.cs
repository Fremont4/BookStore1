using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace BookStore1.API.DTOs.Category
{
    public class CategoryAddDtos
    {
        [Required (ErrorMessage ="The field {0}is required")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "The field {0} must be between {2} and {1} characters")]
        public string Name { get; set; }
    }
}
