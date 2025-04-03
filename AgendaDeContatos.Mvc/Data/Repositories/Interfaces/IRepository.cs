namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IRepository<T> : ISearch<T> where T : class
{
    void Update(T entity);
    void Create(T entity);
    void Delete(int id);
}
