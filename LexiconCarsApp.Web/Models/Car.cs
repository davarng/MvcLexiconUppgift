using System.ComponentModel.DataAnnotations;

namespace LexiconCarsApp.Web.Models;

public class Car(int id, string model, string make, int year, string color)
{
    public int Id { get; set; } = id;

    [Required(ErrorMessage = "Enter a Model")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be 1-50 characters")]
    public string Model { get; set; } = model;

    [Required(ErrorMessage = "Enter a Make")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Make must be 1-50 characters")]
    public string Make { get; set; } = make;

    [Required(ErrorMessage = "Enter a Year")]
    [Range(1960, 2026, ErrorMessage = "Year must be between 1960 and 2026.")]
    public int Year { get; set; } = year;

    [Required(ErrorMessage = "Enter a Color")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Color must be 1-50 characters")]
    public string Color { get; set; } = color;

}
