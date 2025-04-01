using System.Diagnostics;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ISearch<Contato> _search;

    public HomeController(ISearch<Contato> contatos)
    {
        _search = contatos;
    }

    public IActionResult Index()
    {
        var contatos = _search.GetAll();
        return View(contatos);
    }
}
