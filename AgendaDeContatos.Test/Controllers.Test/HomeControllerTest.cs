using AgendaDeContatos.Mvc.Controllers;
using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AgendaDeContatos.Test.Controllers.Test;

public class HomeControllerTest
{
    private HomeController _home;
    private Mock<ISearch<Contato>> _mock;


    public HomeControllerTest()
    {
        var contato1 = ContatoBuilder.Create().Build();
        var contato2 = ContatoBuilder.Create().Build();

        _mock = new Mock<ISearch<Contato>>();
        _mock.Setup(r => r.GetAll()).Returns([contato1, contato2]);

        _home = new HomeController(_mock.Object);
    }


    [Fact]
    public void Index_DeveRetornarListaDeContatos()
    {
        var result = _home.Index();
        var viewResult = result as ViewResult;

        var contatos = viewResult?.Model as IEnumerable<Contato>;

        Assert.NotNull(result);
        Assert.NotNull(viewResult);
        Assert.NotNull(contatos);
        Assert.True(contatos.Count() == 2);
    }
}
