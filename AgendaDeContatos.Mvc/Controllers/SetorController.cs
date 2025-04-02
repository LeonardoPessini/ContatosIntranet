
using AgendaDeContatos.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers;

public class SetorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Setor viewModel)
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }
}
