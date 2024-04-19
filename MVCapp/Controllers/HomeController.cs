using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCapp.Data;
using MVCapp.Models;
using MVCapp.Models.Domain;

namespace MVCapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MVCappDbContext mvCappDbContext;

    public HomeController(ILogger<HomeController> logger, MVCappDbContext mvCappDbContext)
    {
        _logger = logger;
        this.mvCappDbContext = mvCappDbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult>  Index()
    {
        var user = await mvCappDbContext.Users.ToListAsync();
        
        return View(user);
    }

    [HttpGet]
    public IActionResult Form()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Form(AddUserRequest addUserRequest)
    {
        var user = new User
        {
            Name = addUserRequest.Name
        };

       await mvCappDbContext.Users.AddAsync(user);
       await mvCappDbContext.SaveChangesAsync();
      
          return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}