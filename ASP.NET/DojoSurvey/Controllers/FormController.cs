using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;   
public class FormController : Controller
{      
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public ViewResult Process(string name, string location, string language, string comment) 
    {
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.Language = language;
        ViewBag.Comment = comment;

        return View("process");
    }

    [HttpGet("results")]
    public ViewResult Results()
    {
        return View("results");
    }
}

