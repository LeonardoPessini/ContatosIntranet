using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers;
public class FilialController : ControllerBase<Filial>
{
    public FilialController(IRepository<Filial> repository) : base(repository)
    {
    }
    //private readonly IRepository<Models.Filial> _repository;

    //public FilialController(IRepository<Models.Filial> repository)
    //{
    //    _repository = repository;
    //}


    //public IActionResult Index()
    //{
    //    var filiais = _repository.GetAll();
    //    return View(filiais);
    //}


    //public IActionResult Edit(int filialId)
    //{
    //    var filial = _repository.GetById(filialId);

    //    if(filial == null) 
    //        return NotFound();

    //    return View(filial);
    //}

    //[HttpPost]
    //public IActionResult Edit(Filial filialEdit)
    //{
    //    if(!ModelState.IsValid)
    //        return View(filialEdit);

    //    if(filialEdit.Id == 0)
    //        return BadRequest();

    //    var model = _repository.GetById(filialEdit.Id);

    //    if(model == null)
    //        return NotFound();

    //    model.Nome = filialEdit.Nome;
    //    model.Cnpj = filialEdit.Cnpj;
    //    model.Estado = filialEdit.Estado;
    //    model.Cidade = filialEdit.Cidade;

    //    _repository.Update(model);

    //    return RedirectToAction("Index");
    //}


    //public IActionResult Create()
    //{
    //    return View();
    //}


    //[HttpPost]
    //public IActionResult Create(Filial filialCreate)
    //{
    //    if(!ModelState.IsValid)
    //        return View(filialCreate);

    //    _repository.Create(filialCreate);
    //    return RedirectToAction("Index");
    //}


    //public IActionResult Delete(int filialId)
    //{
    //    var filial = _repository.GetById(filialId);
    //    if(filial == null)
    //        return NotFound();

    //    return View(filial);
    //}


    //public IActionResult Remove(int filialId)
    //{
    //    if(_repository.GetById(filialId) == null)
    //        return NotFound();

    //    _repository.Delete(filialId);

    //    return RedirectToAction("Index");
    //}
}
