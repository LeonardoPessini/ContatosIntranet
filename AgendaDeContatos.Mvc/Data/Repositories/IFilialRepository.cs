using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public interface IFilialRepository : IGetById<Filial>, IGetByName<Filial>, ICreate<Filial>
{
}
