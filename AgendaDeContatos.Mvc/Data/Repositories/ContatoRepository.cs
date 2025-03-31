﻿using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class ContatoRepository : IRepository<Contato>
{
    private AppDbContext _context;

    public ContatoRepository(AppDbContext context)
    {
        this._context = context;
    }


    public void Create(Contato entity)
    {
        CheckIfItCanBeStored(entity);

        _context.Conatatos.Add(entity);
        _context.SaveChanges();
    }

    public Contato? GetById(int id)
    {
        return _context.Conatatos.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Contato> GetByName(string name)
    {
        return _context.Conatatos.Where(c => c.Nome.Contains(name));
    }

    private void CheckIfItCanBeStored(Contato model)
    {
        if(model.Id != 0)
            throw new InvalidOperationException("Nao e possivel armazenar um objeto que possui ID definido");

        if (model.Ramal == null && model.Celular == null && model.Email == null)
            throw new InvalidOperationException("O registro deve conter ao menos um dos meios de contato preenchido.");

        if (_context.Setores.FirstOrDefault(s => s.Id == model.SetorId) == null)
            throw new InvalidOperationException($"Setor nao existe na base: {model.SetorId}");

        _context.CompatibilityContato.Verify(model);
    }
}
