namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IRepository<T> : ISearch<T>, ICreate<T> where T : class
{
}
