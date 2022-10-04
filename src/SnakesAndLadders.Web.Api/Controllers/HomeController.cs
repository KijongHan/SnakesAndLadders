using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SnakesAndLadders.Web.Api.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
}
