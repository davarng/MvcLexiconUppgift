using LexiconCarsApp.Web.Models;

namespace LexiconCarsApp.Web.Services
{
    public class CarService
    {
        private static readonly List<Car> cars = [
            new(1,"Yaris","Toyota",2012,"Gul"),
            new(2,"Yaris","Toyota",2012,"Gul"),
            new(3,"Yaris","Toyota",2012,"Gul"),
            new(4,"Yaris","Toyota",2012,"Gul")
            ];

        public Car[] GetAllCars() => [.. cars.OrderBy(c => c.Model)];

        public Car? GetCarById(int id) => cars
            .SingleOrDefault(c => c.Id == id);

        public void AddCar(Car car)
        {
            car.Id = cars.Max(c => c.Id) + 1;
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
