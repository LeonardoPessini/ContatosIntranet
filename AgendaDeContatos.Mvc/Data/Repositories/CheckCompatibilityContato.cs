using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

namespace AgendaDeContatos.Mvc.Data.Repositories;

public class CheckCompatibilityContato : ICheckCompatibilityModelData<Contato>
{
    public bool IsCompatible(Contato model)
    {
        try{
            Verify(model);
            return true;

        }catch(OverflowException) { 
            return false; 
        }
    }


    public void Verify(Contato model)
    {
        if (model.Nome.Length > 50)
            throw new OverflowException($"Valor muito grande para ser armazenado : {model.Nome}");

        if(model.Ramal?.Length > 10)
            throw new OverflowException($"Valor muito grande para ser armazenado : {model.Ramal}");

        if(model.Email?.Length > 100)
            throw new OverflowException($"Valor muito grande para ser armazenado : {model.Email}");

        if(model.Celular?.Length > 14)
            throw new OverflowException($"Valor muito grande para ser armazenado : {model.Celular}");
    }
}
