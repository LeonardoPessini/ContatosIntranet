using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Mvc.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers;
public class FilialController : Controller
{
    private readonly IRepository<Filial> _repository;
    private readonly FilialFactory _factory;

    public FilialController(IRepository<Filial> repository)
    {
        _repository = repository;
        _factory = new FilialFactory();
    }


    public IActionResult Index()
    {
        var filiais = _repository.GetAll().Select(f => _factory.CreateViewModelBasic(f));
        return View(filiais);
    }


    public IActionResult Edit(int filialId)
    {
        var filial = _repository.GetById(filialId);

        if(filial == null) 
            return NotFound();

        var viewModel = _factory.CreateViewModelBasic(filial);

        return View(viewModel);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(FilialViewModel filialCreate)
    {
        if(!ModelState.IsValid)
            return View(filialCreate);

        var filial = _factory.CreateFilial(filialCreate);

        if (filial == null)
            return BadRequest();

        _repository.Create(filial);
        return RedirectToAction("Index");
    }
}
