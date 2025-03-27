using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class VerifyCompatibilityFilial : IVerifyCompatibilityModelData<Filial>
{
    public bool IsCompatible(Filial model)
    {
        try{
            Verify(model);
            return true;

        }catch(OverflowException) { 
            return false; 
        }
    }

    public void Verify(Filial model)
    {
        if (model.NomeDeExibicao.Length > 30)
            throw new OverflowException($"Valor muito grande para ser armazenado : {model.NomeDeExibicao}");

        if (model.Cidade != null && model.Cidade.Length > 40)
            throw new OverflowException($"Valor muito grande para ser armazenado : {model.Cidade}");
    }
}
