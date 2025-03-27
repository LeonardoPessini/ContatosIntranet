namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface ICreate<T> where T : class
{
    void Create(T entity);
}
