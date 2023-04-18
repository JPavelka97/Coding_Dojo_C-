using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // ! INDEX - LOGIN/REGISTER - GET
    public IActionResult Index()
    {
        return View("Index");
    }

    // ! INDEX - REGISTER - POST
    [HttpPost("users/create")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    // ! INDEX - LOGIN - POST
    [HttpPost("users/login")]
    public IActionResult Login(UserLogin userSubmit)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmit.EmailLogin);
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<UserLogin> hasher = new PasswordHasher<UserLogin>();
            var result = hasher.VerifyHashedPassword(
                userSubmit,
                userInDb.Password,
                userSubmit.PasswordLogin
            );
            if (result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    // ! DASHBOARD - DISPLAY ALL WEDDINGS - GET
    [SessionCheck]
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        List<Wedding> AllWeddings = _context.Weddings
            .Include(attendees => attendees.Attendees)
            .ThenInclude(attendees => attendees.User)
            .ToList();
        return View("Dashboard", AllWeddings);
    }

    // ! CREATE - CREATE WEDDING - GET
    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        return View("NewWedding");
    }

    // ! CREATE - CREATE WEDDING - POST
    [SessionCheck]
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        newWedding.CreatorId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();

            return View("ReadWedding", newWedding);
        }
        else
        {
            return NewWedding();
        }
    }

    // ! CREATE - CREATE ATTENDEE - POST
    [SessionCheck]
    [HttpPost("weddings/{id}/addrsvp")]
    public IActionResult AddRSVP(Attendee newAttendee, int id)
    {
        Attendee? AttendeeToAdd = _context.Attendees.FirstOrDefault(
            a => a.WeddingId == id && a.UserId == (int)HttpContext.Session.GetInt32("UserId")
        );
        if (AttendeeToAdd != null)
        {
            return RedirectToAction("Index");
        }
        newAttendee.UserId = (int)HttpContext.Session.GetInt32("UserId");
        newAttendee.WeddingId = id;
        if (ModelState.IsValid)
        {
            _context.Add(newAttendee);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        else
        {
            return NewWedding();
        }
    }

    // ! DELETE - REMOVE ATTENDEE - POST
    [SessionCheck]
    [HttpPost("weddings/{id}/removersvp")]
    public IActionResult RemoveRSVP(Attendee oldAttendee, int id)
    {
        Attendee? AttendeeToDelete = _context.Attendees.FirstOrDefault(
            a => a.WeddingId == id && a.UserId == (int)HttpContext.Session.GetInt32("UserId")
        );
        if (AttendeeToDelete == null)
        {
            return RedirectToAction("Index");
        }
        _context.Attendees.Remove(AttendeeToDelete);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // ! DELETE - REMOVE WEDDING - POST
    [SessionCheck]
    [HttpPost("weddings/{id}/destroy")]
    public IActionResult DestroyWedding(int id)
    {
        Wedding? WeddingToDelete = _context.Weddings.FirstOrDefault(a => a.WeddingId == id);
        if (WeddingToDelete == null)
        {
            return RedirectToAction("Index");
        }
        _context.Weddings.Remove(WeddingToDelete);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // ! READ - SINGLE WEDDING - GET
    [SessionCheck]
    [HttpGet("weddings/{id}")]
    public IActionResult ReadWedding(int id)
    {
        Wedding? OneWedding = _context.Weddings
            .Include(attendees => attendees.Attendees)
            .ThenInclude(attendees => attendees.User)
            .FirstOrDefault(w => w.WeddingId == id);
        return View("ReadWedding", OneWedding);
    }

    // ! LOGOUT - POST
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
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

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
