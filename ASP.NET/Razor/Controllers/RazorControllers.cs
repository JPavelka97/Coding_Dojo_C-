using Microsoft.AspNetCore.Mvc;
namespace Razor.Controllers;

public class RazorController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }
}