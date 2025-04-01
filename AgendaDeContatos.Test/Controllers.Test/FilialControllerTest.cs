using AgendaDeContatos.Mvc.Controllers;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Mvc.Models.ViewModel;
using AgendaDeContatos.Test.Builders;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AgendaDeContatos.Test.Controllers.Test;
public class FilialControllerTest
{
    private readonly List<Filial> _filiais;
    private Mock<IRepository<Filial>> _mock;
    private FilialController _controller;

    public FilialControllerTest()
    {
        _filiais = new List<Filial>() { new("Filial1") {Id = 1}, new("Filial2") {Id = 2} };
        _mock = new Mock<IRepository<Filial>>();
        _mock.Setup(r => r.GetAll()).Returns(_filiais);
        _mock.Setup(r => r.GetById(1)).Returns(_filiais.First(f => f.Id == 1));
        _mock.Setup(r => r.Create(It.Is<Filial>(f => true))).Callback<Filial>(f => _filiais.Add(f));
        _controller = new FilialController(_mock.Object);
    }


    [Fact]
    public void Index_DeveRetornarLista()
    {
        var result = _controller.Index();
        var viewResult = result as ViewResult;

        var filiais = viewResult!.Model as IEnumerable<FilialViewModel>;

        Assert.NotNull(viewResult);
        Assert.NotNull(filiais);
        Assert.True(filiais.Count() == 2);
    }


    [Fact]
    public void Create_DeveCriarFilial()
    {
        var filial = FilialBuilder.Create().Build();
        var filialViewModel = new FilialViewModel()
        {
            Nome = filial.Nome,
            Cidade = filial.Cidade,
            Estado = filial.Estado,
            Cnpj = filial.Cnpj,
        };

        _controller.Create(filialViewModel);

        Assert.NotNull(_filiais.FirstOrDefault(f => f.Nome == filial.Nome && f.Cnpj == filial.Cnpj));
    }


    [Fact]
    public void Edit_DeveRetornarFilialViewModel()
    {
        int filialId = 1;
        var result = _controller.Edit(filialId);
        var viewResult = result as ViewResult;

        var filial = viewResult!.Model as FilialViewModel;

        Assert.NotNull(viewResult);
        Assert.NotNull(filial);
        Assert.Equal(filialId, filial.Id);
    }

}



