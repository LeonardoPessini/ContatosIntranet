
using AgendaDeContatos.Mvc.Models.ViewModel;

namespace AgendaDeContatos.Mvc.Models;

public class FilialFactory
{
    public Filial? CreateFilial(FilialViewModel viewModel)
    {
        try
        {
            return new Filial(viewModel.Nome)
            {
                Id = 0,
                Cidade = viewModel.Cidade,
                Estado = viewModel.Estado,
                Cnpj = viewModel.Cnpj,
            };
        }
        catch
        {
            return null;
        }
    }


    public FilialViewModel CreateViewModelBasic(Filial filial)
    {
        return new FilialViewModel
        {
            Id = filial.Id,
            Nome = filial.Nome,
            Cidade = filial.Cidade,
            Estado = filial.Estado,
            Cnpj = filial.Cnpj
        };
    }
}
