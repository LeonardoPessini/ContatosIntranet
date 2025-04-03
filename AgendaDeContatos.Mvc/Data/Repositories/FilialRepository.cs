using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class FilialRepository : IRepository<Filial>
{
    private readonly AppDbContext _context;

    public FilialRepository(AppDbContext context)
    {
        _context = context;
    }


    public void Create(Filial entity)
    {
        if (entity.Id != 0)
            throw new InvalidOperationException("Nao e possivel armazenar um objeto que possui ID definido");

        _context.Filiais.Add(entity);
        _context.SaveChanges();
    }


    public Filial? GetById(int id)
    {
        return _context.Filiais.SingleOrDefault(f => f.Id == id);
    }


    public IEnumerable<Filial> GetByName(string name)
    {
        return _context.Filiais
            .Where(f => f.Nome.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IEnumerable<Filial> GetAll()
    {
        return _context.Filiais.OrderBy(f => f.Id).ToList();
    }

    public void Update(Filial entity)
    {
        _context.Filiais.Attach(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var filial = _context.Filiais.FirstOrDefault(f => f.Id == id)!;
        _context.Remove(filial);
        _context.SaveChanges();
    }
}
