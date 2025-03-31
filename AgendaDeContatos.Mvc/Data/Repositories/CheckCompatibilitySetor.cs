using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class CheckCompatibilitySetor : ICheckCompatibilityModelData<Setor>
{
    public bool IsCompatible(Setor model)
    {
        try{
            Verify(model);
            return true;

        }catch(OverflowException) { 
            return false; 
        }
    }

    public void Verify(Setor model)
    {
        if (model.Nome.Length > 40)
            throw new OverflowException($"Valor muito grande para ser armazenado : {model.Nome}");
    }
}
