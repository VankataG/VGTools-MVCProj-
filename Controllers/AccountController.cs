using FirstMVCProj.Models;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private static List<UserModel> users = new List<UserModel>(); // Temporary user storage

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(UserModel model)
    {
        if (users.Exists(u => u.Email == model.Email))
        {
            ModelState.AddModelError("", "Email already exists.");
            return View(model);
        }

        users.Add(model);
        TempData["User"] = model.Email; // Store the user in TempData
        return RedirectToAction("Dashboard", "Home");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = users.Find(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            TempData["User"] = user.Email; // Store the user in TempData
            return RedirectToAction("Dashboard", "Home");
        }

        ModelState.AddModelError("", "Invalid email or password.");
        return View();
    }

    public IActionResult Logout()
    {
        TempData.Remove("User"); // Clear TempData
        return RedirectToAction("Login");
    }
}