using System.ComponentModel.DataAnnotations;

namespace LexiconCarsApp.Web.Views.Cars
{
    public class DetailsVm
    {
        public int Id { get; set; }
        public required string Model { get; set; }
        public required string Make { get; set; }
        public required int Year { get; set; }
        public required string Color { get; set; }
    }


}



