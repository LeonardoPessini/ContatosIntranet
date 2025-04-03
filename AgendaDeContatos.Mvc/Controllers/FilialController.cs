using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;

using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Mvc.Controllers;
public class FilialController(IRepository<Filial> repository) : ControllerBase<Filial>(repository)
{
}
