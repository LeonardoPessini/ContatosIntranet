namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IGetAll<T>
{
    IEnumerable<T> GetAll();
}
