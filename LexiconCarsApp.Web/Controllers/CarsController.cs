using LexiconCarsApp.Web.Services;
using LexiconCarsApp.Web.Views.Cars;
using Microsoft.AspNetCore.Mvc;

namespace LexiconCarsApp.Web.Controllers;
//Dependency injection in primary constructor.
public class CarsController(CarService carService) : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        //Get all cars and map them to the view model.
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

        if (model == null)
            return NotFound("Car not found");

        var viewModel = new DetailsVm()
        {
            Year = model.Year,
            Make = model.Make,
            Color = model.Color,
            Model = model.Model,
            Id = model.Id
        };

        return View(viewModel);
    }

    [HttpGet("/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("/create")]
    public IActionResult Create(CreateVm car)
    {
        //Checks if attributes in the model are valid. Redirects to the view if not valid.
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

        if (model == null)
            return NotFound("Car not found");

        var viewModel = new EditVm()
        {
            Year = model.Year,
            Make = model.Make,
            Color = model.Color,
            Model = model.Model,
        };
        return View(viewModel);
    }

    [HttpPost("/edit/{id}")]
    public IActionResult Edit(EditVm carEdit, int id)
    {
        //Checks if attributes in the model are valid. Redirects to the view if not valid.
        if (ModelState.IsValid)
        {
            //Sends EditVm and id to update specific car.
            carService.UpdateCar(carEdit, id);
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
