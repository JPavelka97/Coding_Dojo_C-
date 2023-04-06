using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class NumberController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {

        return View("index");
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        Console.WriteLine("Session Cleared");
        HttpContext.Session.SetInt32("Number", 25);
        return RedirectToAction("Index");
    }

    [HttpPost("dashboard")]
    public IActionResult Dashboard(string name)
    {
        Console.WriteLine(name);
        HttpContext.Session.SetString("UserName", $"{name}");
        HttpContext.Session.SetInt32("Number", 25);
        return View("dashboard");
    }

    [HttpPost("dashboard/process")]
    public IActionResult DashboardModify(string modifier)
    {
        Console.WriteLine(modifier);
        int origin = Convert.ToInt32(HttpContext.Session.GetInt32("Number"));
        if (modifier == "+1")
        {
            int modified = origin + 1;
            Console.WriteLine(modified);
            HttpContext.Session.SetInt32("Number", modified);
        }
        if (modifier == "-1")
        {
            int modified = origin - 1;
            Console.WriteLine(modified);
            HttpContext.Session.SetInt32("Number", modified);
        }
        if (modifier == "x2")
        {
            int modified = origin * 2;
            Console.WriteLine(modified);
            HttpContext.Session.SetInt32("Number", modified);
        }
        if (modifier == "Random")
        {
            Random rand = new Random();
            int modified = origin + (rand.Next(-25, 25));
            Console.WriteLine(modified);
            HttpContext.Session.SetInt32("Number", modified);
        }
        return View("dashboard");
    }
}
