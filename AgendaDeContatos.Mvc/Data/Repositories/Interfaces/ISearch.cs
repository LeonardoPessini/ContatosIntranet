namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface ISearch<T> : IGetById<T>, IGetByName<T>, IGetAll<T> where T : class
{
}
