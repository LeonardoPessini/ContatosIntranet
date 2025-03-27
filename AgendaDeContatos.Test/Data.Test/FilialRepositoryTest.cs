using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Moq;

namespace AgendaDeContatos.Test.Data.Test;
public class FilialRepositoryTest
{
    private readonly AppDbContext _context;
    private readonly IFilialRepository _repository;
    private readonly Filial _filial;

    public FilialRepositoryTest()
    {
        _context = Create.MockedDbContextFor<AppDbContext>();
        _repository = new FilialRepository(_context, new VerifyCompatibilityFilial());
        _filial = FilialBuilder.Create().Build();
    }

    private void AssertEqualFiliais(Filial expected, Filial actual)
    {
        Assert.Equal(expected.NomeDeExibicao, actual.NomeDeExibicao);
        Assert.Equal(expected.Estado, actual.Estado);
        Assert.Equal(expected.Cidade, actual.Cidade);
        Assert.Equal(expected.Cnpj, actual.Cnpj);
    }


    [Fact]
    public void Create_DeveCriarFilial()
    {
        _repository.Create(_filial);
        var filialCreated = _context.Filiais.Single(f => f.Id == _filial.Id);

        Assert.NotNull(filialCreated);
        AssertEqualFiliais(_filial, filialCreated);
    }

    [Fact]
    public void GetById_DeveConsultarFilialPorId()
    {
        _context.Filiais.Add(_filial);
        _context.SaveChanges();
        var filialObtida = _repository.GetById(_filial.Id);

        Assert.NotNull(filialObtida);
        AssertEqualFiliais(_filial, filialObtida);
    }

    [Fact]
    public void GetByNome_DeveConsultarFilialPorNome()
    {
        _context.Filiais.Add(_filial);
        _context.SaveChanges();

        var filialObtida = _repository.GetByName(_filial.NomeDeExibicao);

        Assert.NotNull(filialObtida);
        AssertEqualFiliais(_filial, filialObtida.Single());
    }


    [Fact]
    public void Create_NomeDeExibicao_NaoDeveCriarComValorMaiorQueODaColuna()
    {
        var nomeMuitoGrande = new Randomizer().String2(31);
        var filial = FilialBuilder.Create().WithNome(nomeMuitoGrande).Build();

        Assert.Throws<OverflowException>(()=>
            _repository.Create(filial))
            .WithMessage($"Valor muito grande para ser armazenado : {filial.NomeDeExibicao}");
    }

    [Fact]
    public void Create_Cidade_NaoDeveCriarComValorMaiorQueODaColuna()
    {
        var nomeMuitoGrande = new Randomizer().String2(41);
        var filial = FilialBuilder.Create().WithCidade(nomeMuitoGrande).Build();

        Assert.Throws<OverflowException>(() =>
            _repository.Create(filial))
            .WithMessage($"Valor muito grande para ser armazenado : {filial.Cidade}");
    }
}
