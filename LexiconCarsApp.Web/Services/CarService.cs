using LexiconCarsApp.Web.Models;
using LexiconCarsApp.Web.Views.Cars;
using LexiconCarsApp.Web.Views.Shared;

namespace LexiconCarsApp.Web.Services
{
    public class CarService
    {
        private static readonly List<Car> cars =
        [
            new Car { Id = 1, Model = "Model", Make = "Toyota", Year = 2012, Color = "Yellow" },
            new Car { Id = 2, Model = "Model", Make = "Toyota", Year = 2012, Color = "Yellow" },
            new Car { Id = 3, Model = "Model", Make = "Toyota", Year = 2012, Color = "Yellow" },
            new Car { Id = 4, Model = "ModelS", Make = "Toyota", Year = 2012, Color = "Yellow" }
        ];

        public Car[] GetAllCars() => [.. cars.OrderBy(c => c.Model)];

        public Car? GetCarById(int id) => cars.SingleOrDefault(c => c.Id == id);

        public void AddCar(CreateVm carCreate)
        {
            var car = new Car
            {
                Model = carCreate.Model,
                Make = carCreate.Make,
                Year = carCreate.Year,
                Color = carCreate.Color,
                Id = cars.Count == 0 ? 1 : cars.Max(o => o.Id) + 1
            };

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
}
