using Microsoft.AspNetCore.Mvc;

namespace SIDAPA.presentation.Controllers.Web.SIDAPA;

public class IndexController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View("~/Views/SIDAPA/Index.cshtml");
    }
}