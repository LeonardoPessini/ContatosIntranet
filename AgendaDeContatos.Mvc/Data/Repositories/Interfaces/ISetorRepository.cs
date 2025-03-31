using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface ISetorRepository : IGetById<Setor>, IGetByName<Setor>, ICreate<Setor>
{
}
