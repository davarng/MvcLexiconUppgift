namespace LexiconCarsApp.Web.Views.Cars;

public class IndexVm
{
    public class IndexItemVm
    {
        public required string CarMake { get; set; }

        public required int CarId { get; set; }
    }

    public required IndexItemVm[] ListOfIndexItemVms { get; set; }
}
