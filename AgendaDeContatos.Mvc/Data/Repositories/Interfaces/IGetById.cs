namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IGetById<T> where T : class
{
    T? GetById(int id);
}
