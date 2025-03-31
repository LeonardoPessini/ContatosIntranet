namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IRepository<T> : IGetById<T>, IGetByName<T>, ICreate<T> where T : class
{
}
