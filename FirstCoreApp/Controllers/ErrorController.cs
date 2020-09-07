using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FirstCoreApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("CustomError/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorType = "Not Found Error";
                    ViewBag.ErrorMessage = "Resource you are looking for is not available";
                    break;
                case 500:
                    ViewBag.ErrorType = "Server Error";
                    ViewBag.ErrorMessage = "Oops! something went wrong please try again";
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Exception = exceptionHandler.Error;

            return View("Error");
        }
    }
}
