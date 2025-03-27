using System;

namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IGetByName<T> where T : class
{
    IEnumerable<T> GetByName(string name);
}
