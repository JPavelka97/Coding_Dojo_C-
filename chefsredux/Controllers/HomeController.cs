using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chefsredux.Models;

namespace chefsredux.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // ! Read - Index Page (GET Chefs)
    public IActionResult Index()
    {
        ViewBag.AllChefs= _context.Chefs.OrderByDescending(c => c.CreatedAt).Include(d => d.AllDishes).ToList();
        return View("Index");
    }

    // ! Create - CHEFS GET FORM !
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View("CreateChef");
    }

    // ! Create - CHEFS POST FORM !
    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        else
        {
            return NewChef();
        }
    }

    // ! Read - Dishes
    [HttpGet("dishes")]
    public IActionResult ViewDishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Chef).ToList();
        return View("Dishes", AllDishes);
    }

    // ! Create - Dish - GET
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.AllChefs= _context.Chefs.OrderByDescending(c => c.CreatedAt).ToList();
        return View("CreateDish");
    }

    // ! Create - Dish - POST
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();

            return RedirectToAction("ViewDishes");
        }
        else
        {
            return NewDish();
        }
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
