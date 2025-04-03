using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers;

public class ControllerBase<T> : Controller where T : class
{
    private readonly IRepository<T> _repository;

    public ControllerBase(IRepository<T> repository)
    {
        _repository = repository;
    }


    public IActionResult Index()
    {
        var filiais = _repository.GetAll();
        return View(filiais);
    }


    public IActionResult Edit(int entityId)
    {
        var filial = _repository.GetById(entityId);

        if (filial == null)
            return NotFound();

        return View(filial);
    }

    [HttpPost]
    public IActionResult Edit(T entity)
    {
        if (!ModelState.IsValid)
            return View(entity);

        _repository.Update(entity);

        return RedirectToAction("Index");
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(T entity)
    {
        if (!ModelState.IsValid)
            return View(entity);

        _repository.Create(entity);
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int entityId)
    {
        var filial = _repository.GetById(entityId);
        if (filial == null)
            return NotFound();

        return View(filial);
    }


    public IActionResult Remove(int entityId)
    {
        if (_repository.GetById(entityId) == null)
            return NotFound();

        _repository.Delete(entityId);

        return RedirectToAction("Index");
    }
}
