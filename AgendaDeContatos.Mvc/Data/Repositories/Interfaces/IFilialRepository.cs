using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IFilialRepository : IGetById<Filial>, IGetByName<Filial>, ICreate<Filial>
{
}
