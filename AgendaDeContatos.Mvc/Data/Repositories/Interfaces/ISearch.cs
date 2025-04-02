namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface ISearch<T> where T : class
{
    IEnumerable<T> GetByName(string name);
    T? GetById(int id);
    IEnumerable<T> GetAll();
}
