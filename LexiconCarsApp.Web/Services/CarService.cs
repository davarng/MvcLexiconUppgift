using LexiconCarsApp.Web.Models;

namespace LexiconCarsApp.Web.Services
{
    public class CarService
    {
        private static readonly List<Car> cars = new()
            {
                new Car { Id = 1, Model = "Yaris", Make = "Toyota", Year = 2012, Color = "Yellow" },
                new Car { Id = 2, Model = "Yaris", Make = "Toyota", Year = 2012, Color = "Yellow" },
                new Car { Id = 3, Model = "Yaris", Make = "Toyota", Year = 2012, Color = "Yellow" },
                new Car { Id = 4, Model = "Yaris", Make = "Toyota", Year = 2012, Color = "Yellow" }
            };

        public Car[] GetAllCars() => cars.OrderBy(c => c.Model).ToArray();

        public Car? GetCarById(int id) => cars.SingleOrDefault(c => c.Id == id);

        public void AddCar(Car car)
        {
            car.Id = cars.Count == 0 ? 1 : cars.Max(o => o.Id) + 1;
            cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            var carFound = GetCarById(car.Id);
            if (carFound != null)
            {
                carFound.Model = car.Model;
                carFound.Make = car.Make;
                carFound.Year = car.Year;
                carFound.Color = car.Color;
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
