using LexiconCarsApp.Web.Models;
using LexiconCarsApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LexiconCarsApp.Web.Controllers
{
    public class CarsController : Controller
    {
        static readonly CarService carService = new();

        [HttpGet("/")]
        public IActionResult Index()
        {
            var model = carService.GetAllCars();
            return View(model);
        }

        [HttpGet("/details/{id}")]
        public IActionResult Details(int id)
        {
            var model = carService.GetCarById(id);
            return View(model);
        }

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/create")]
        public IActionResult Create(Car car)
        {
            carService.AddCar(car);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = carService.GetCarById(id);
            return View(model);
        }

        [HttpPost("/edit/{id}")]
        public IActionResult Edit(Car car)
        {
            carService.UpdateCar(car);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
