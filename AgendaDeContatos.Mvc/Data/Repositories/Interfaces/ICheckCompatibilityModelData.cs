namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface ICheckCompatibilityModelData<T>
{
    bool IsCompatible(T model);
    void Verify(T model);
}
