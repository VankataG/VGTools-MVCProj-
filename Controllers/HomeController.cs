using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstMVCProj.Models;



namespace FirstMVCProj.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Dashboard()
    {
        if (TempData["User"] == null) // Check if the user is logged in
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.User = TempData["User"]; // Pass TempData to the view
        TempData.Keep("User"); // Keep TempData for future requests
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Catalog()
    {
        return View();
    }

    public IActionResult Sprays()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult HandTools()
    {
        return View();
    }

    public IActionResult PowerTools()
    {
        return View();
    }
}