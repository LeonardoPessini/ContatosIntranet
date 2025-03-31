using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using System;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class FilialRepository : IRepository<Filial>
{
    private readonly AppDbContext _context;
    private readonly ICheckCompatibilityModelData<Filial> _compatibility;


    public FilialRepository(AppDbContext context, ICheckCompatibilityModelData<Filial> verify)
    {
        _context = context;
        _compatibility = verify;
    }


    public void Create(Filial entity)
    {
        CheckIfItCanBeStored(entity);

        _context.Filiais.Add(entity);
        _context.SaveChanges();
    }


    private void CheckIfItCanBeStored(Filial entity)
    {
        if (entity.Id != 0)
            throw new InvalidOperationException("Nao e possivel armazenar um objeto que possui ID definido");

        _compatibility.Verify(entity);
    }


    public Filial? GetById(int id)
    {
        return _context.Filiais.SingleOrDefault(f => f.Id == id);
    }


    public IEnumerable<Filial> GetByName(string name)
    {
        return _context.Filiais
            .Where(f => f.NomeDeExibicao.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
