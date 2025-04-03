using AgendaDeContatos.Mvc.Data.Context;
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

        _context.Contatos.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Contato> GetAll()
    {
        return _context.Contatos.OrderBy(c => c.Setor.FilialId).ThenBy(c => c.SetorId).ThenBy(c => c.Nome).ToList();
    }

    public Contato? GetById(int id)
    {
        return _context.Contatos.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Contato> GetByName(string name)
    {
        return _context.Contatos.Where(c => c.Nome.Contains(name));
    }

    public void Update(Contato entity)
    {
        throw new NotImplementedException();
    }

    private void CheckIfItCanBeStored(Contato model)
    {
        if(model.Id != 0)
            throw new InvalidOperationException("Nao e possivel armazenar um objeto que possui ID definido");

        if (model.Ramal == null && model.Celular == null && model.Email == null)
            throw new InvalidOperationException("O registro deve conter ao menos um dos meios de contato preenchido.");

        if (_context.Setores.FirstOrDefault(s => s.Id == model.SetorId) == null)
            throw new InvalidOperationException($"Setor nao existe na base: {model.SetorId}");
    }
}
