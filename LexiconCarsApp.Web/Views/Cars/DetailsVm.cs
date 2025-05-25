using System.ComponentModel.DataAnnotations;

namespace LexiconCarsApp.Web.Views.Cars
{
    public class DetailsVm
    {

        [Required(ErrorMessage = "Enter a name")]
        [Display(Name = "Make", Prompt = "Make")]
        public required string CarMake { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        [Display(Name = "Make", Prompt = "Make")]
        public required int CarId { get; set; }
    }


}



