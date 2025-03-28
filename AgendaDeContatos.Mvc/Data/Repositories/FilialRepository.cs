using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using System;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class FilialRepository : IFilialRepository
{
    private readonly AppDbContext _context;
    private readonly IVerifyCompatibilityModelData<Filial> _compatibility;

    public FilialRepository(AppDbContext context, IVerifyCompatibilityModelData<Filial> verify)
    {
        _context = context;
        _compatibility = verify;
    }

    public void Create(Filial entity)
    {
        if (entity.Id != 0)
            throw new InvalidOperationException("Nao e possivel armazenar um objeto que possui ID definido");

        _compatibility.Verify(entity);

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
            .Where(f => f.NomeDeExibicao.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
