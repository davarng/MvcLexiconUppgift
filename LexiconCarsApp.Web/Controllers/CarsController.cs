using LexiconCarsApp.Web.Models;
using LexiconCarsApp.Web.Services;
using LexiconCarsApp.Web.Views.Cars;
using Microsoft.AspNetCore.Mvc;

namespace LexiconCarsApp.Web.Controllers
{
    public class CarsController(CarService carService) : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            var model = carService.GetAllCars();

            var viewModel = new IndexVm
            {
                ListOfIndexItemVms = [.. model.Select(c => new IndexVm.IndexItemVm
                {
                    CarMake = c.Make,
                    CarId = c.Id
                })]
            };

            return View(viewModel);
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
            if (ModelState.IsValid)
            {
                carService.AddCar(car);
                return RedirectToAction(nameof(Index));
            }

            return View();
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
            if (ModelState.IsValid)
            {
                carService.UpdateCar(car);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
