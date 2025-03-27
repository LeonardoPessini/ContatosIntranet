namespace AgendaDeContatos.Mvc.Data.Repositories.Interfaces;

public interface IVerifyCompatibilityModelData<T>
{
    bool IsCompatible(T model);
    void Verify(T model);
}
