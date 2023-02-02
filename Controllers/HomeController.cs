using Microsoft.ApplicationInsights;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using videowebapp.Models;

namespace videowebapp.Controllers;

public class HomeController : Controller
{
    private TelemetryClient aiClient;

    public HomeController(TelemetryClient aiClient)
    {
        this.aiClient = aiClient;
    }

    // private readonly ILogger<HomeController>? _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public ActionResult Like(string button)
    {
        this.aiClient.TrackEvent("LikeClicked");
        ViewBag.Message = "Thank you for your response, check the event name of LikeClicked on Azure Portal";
        return View("Index");
    }
}
