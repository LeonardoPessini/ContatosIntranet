using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
