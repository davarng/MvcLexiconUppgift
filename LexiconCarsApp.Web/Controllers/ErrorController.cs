using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LexiconCarsApp.Web.Controllers;

public class ErrorController : Controller
{
    [HttpGet("/error/exception")]
    public IActionResult ServerError()
    {
        var error = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        if (error != null)
        {
            Debug.WriteLine(error.Message);
        }

        return View();
    }

    [HttpGet("/error/http/{code}")]
    public IActionResult HttpError(int code)
    {
        return View(code);
    }
}
