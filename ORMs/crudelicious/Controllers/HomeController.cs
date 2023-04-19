using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crudelicious.Models;

namespace crudelicious.Controllers;

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
        ViewBag.AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View("Index");
    }

    // ! Create GET !
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        return View("Create");
    }

    // ! Create POST !
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        else
        {
            return NewDish();
        }
    }

    // ! Read !
    [HttpGet("dishes/{id}")]
    public IActionResult ShowDish(int id)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        return View("OneDish", OneDish);
    }

    // ! Update (Edit) !
    [HttpGet("dishes/{id}/edit")]
    public IActionResult EditDish(int id)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if (DishToEdit == null)
        {
            return RedirectToAction("Index");
        }
        return View("EditDish",DishToEdit);
    }

    // ! Update (Update) !
    [HttpPost("dishes/{id}/update")]
    public IActionResult UpdateDish(Dish newDish, int id)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if (ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.Description = newDish.Description;
            OldDish.UpdatedAt = newDish.UpdatedAt;
            _context.SaveChanges();

            return View("OneDish", newDish);
        }
        else
        {
        return View("EditDish", OldDish);
        }
    }

    [HttpPost("dishes/{id}/destroy")]
    public IActionResult DestroyDish(int id)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(d => d.DishId == id);
        if (DishToDelete == null)
        {
            return RedirectToAction("Index");
        }
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
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
