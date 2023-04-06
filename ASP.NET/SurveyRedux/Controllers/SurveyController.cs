using Microsoft.AspNetCore.Mvc;
using SurveyRedux.Models;

namespace SurveyRedux.Controllers;

public class SurveyController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("index");
    }

    [HttpPost("process")]
    public IActionResult Process(Survey survey)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("results", survey);
        }
        else
        {
            return View("index");
        }
    }

    [HttpGet("results")]
    public ViewResult Results(Survey survey)
    {
        return View("results", survey);
    }
}
