using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public interface ISetorRepository : IGetById<Setor>, IGetByName<Setor>, ICreate<Setor>
{
}
