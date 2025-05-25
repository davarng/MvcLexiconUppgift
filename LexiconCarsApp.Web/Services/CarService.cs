using LexiconCarsApp.Web.Models;
using LexiconCarsApp.Web.Views.Cars;

namespace LexiconCarsApp.Web.Services;

public class CarService
{
    private static readonly List<Car> cars =
    [
        new Car(1, "Model", "Toyota", 2012, "Blue"),
        new Car(2, "Model", "Honda", 2012, "Yellow"),
        new Car(3, "Model", "Hyundai", 2012, "Green"),
        new Car(4, "Model", "Subaru", 2012, "Black")
    ];

    public Car[] GetAllCars() => [.. cars.OrderBy(c => c.Model)];

    public Car? GetCarById(int id) => cars.SingleOrDefault(c => c.Id == id);

    public void AddCar(CreateVm carCreate)
    {
        var car = new Car(cars.Count == 0 ? 1 : cars.Max(o => o.Id) + 1,
            carCreate.Model, carCreate.Make, carCreate.Year, carCreate.Color);

        cars.Add(car);
    }

    public void UpdateCar(EditVm carEdit, int id)
    {
        var carFound = GetCarById(id);
        if (carFound != null)
        {
            carFound.Model = carEdit.Model;
            carFound.Make = carEdit.Make;
            carFound.Year = carEdit.Year;
            carFound.Color = carEdit.Color;
        }
    }

    public void DeleteCar(int id)
    {
        var car = GetCarById(id);
        if (car != null)
        {
            cars.Remove(car);
        }
    }
}
