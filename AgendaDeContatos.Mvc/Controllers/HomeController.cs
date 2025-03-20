using System.Diagnostics;
using AgendaDeContatos.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
