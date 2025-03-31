using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IContatoRepository : IGetById<Contato>, IGetByName<Contato>, ICreate<Contato>
{
}
