using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class SetorRepository : IRepository<Setor>
{
    private AppDbContext _context;

    public SetorRepository(AppDbContext context)
    {
        _context = context;
    }


    public void Create(Setor entity)
    {
        CheckIfItCanBeStored(entity);

        _context.Setores.Add(entity);
        _context.SaveChanges();
    }

    private void CheckIfItCanBeStored(Setor entity)
    {
        if (entity.Id != 0)
            throw new InvalidOperationException("Nao e possivel armazenar um objeto que possui ID definido");

        var filialExisteNaBase =
            _context.Filiais.AsNoTracking().FirstOrDefault(f => f.Id == entity.FilialId) != null;

        if (!filialExisteNaBase)
            throw new InvalidOperationException($"Filial nao existe na base: {entity.FilialId}");
    }


    public Setor? GetById(int id)
    {
        return _context.Setores.FirstOrDefault(s => s.Id == id);
    }


    public IEnumerable<Setor> GetByName(string name)
    {
        return _context.Setores.Where(s => s.Nome.Contains(name));
    }

    public IEnumerable<Setor> GetAll()
    {
        return _context.Setores.OrderBy(s => s.Filial).ThenBy(s => s.Nome).ToList();
    }

    public void Update(Setor entity)
    {
        throw new NotImplementedException();
    }
}
