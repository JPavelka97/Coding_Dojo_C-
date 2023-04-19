using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsanddishes.Models;

namespace chefsanddishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private DishContext _context;

    public HomeController(ILogger<HomeController> logger, DishContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        // !!!! Get List of ALL CHEFS
        List<Chef> AllChefs = _context.Chefs.OrderByDescending(c => c.CreatedAt).ToList();
        return View(AllChefs);
    }

    // ! CREATE CHEF - GET
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View("CreateChef");
    }

    // ! CREATE CHEF - POST
    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Chefs.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return NewChef();
        }
    }

    // ! CREATE DISH - GET
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        List<Chef> AllChefs = _context.Chefs.OrderByDescending(c => c.CreatedAt).ToList();
        return View("CreateDish", AllChefs);
    }

    // ! CREATE DISH - POST
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        else
        {
            return NewDish();
        }
    }

    // ! READ ALL DISH - GET
    public IActionResult Dishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Chef).ToList();
        return View("Dishes", AllDishes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
