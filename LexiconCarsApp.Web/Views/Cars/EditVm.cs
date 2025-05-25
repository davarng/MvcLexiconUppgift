using System.ComponentModel.DataAnnotations;

namespace LexiconCarsApp.Web.Views.Cars
{
    public class EditVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a Model")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be 1-50 characters")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Enter a Make")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Make must be 1-50 characters")]
        public required string Make { get; set; }

        [Required]
        [Range(1960, 2026, ErrorMessage = "Year must be between 1960 and 2026.")]
        public required int Year { get; set; }

        [Required(ErrorMessage = "Enter a Color")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Color must be 1-50 characters")]
        public required string Color { get; set; }
    }
}
