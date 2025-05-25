using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LexiconCarsApp.Web.Controllers;

public class ErrorController : Controller
{
    [HttpGet("/error/exception")]
    public IActionResult ServerError()
    {
        // Get the exception that was thrown.
        var error = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        if (error != null)
        {
            //Log the error message to the debug output.
            Debug.WriteLine(error.Message);
        }
        //Show the ServerError view.
        return View();
    }

    //Http error that gets shown when the url is not a valid page.
    [HttpGet("/error/http/{code}")]
    public IActionResult HttpError(int code)
    {
        return View(code);
    }
}
