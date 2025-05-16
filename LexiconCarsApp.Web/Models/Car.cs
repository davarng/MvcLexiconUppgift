namespace LexiconCarsApp.Web.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;

        public Car(int id, string model, string make, int year, string color)
        {
            Id = id;
            Model = model;
            Make = make;
            Year = year;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Id}: {Model} {Make} {Year} {Color}";
        }

    }
}
