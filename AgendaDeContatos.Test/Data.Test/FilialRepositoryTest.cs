using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;
using EntityFrameworkCore.Testing.Moq;

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
        _filial = FilialBuilder.Create().WithId(0).Build();

        _context.Filiais.Add(_filial);
        _context.SaveChanges();
    }

    private void AssertEqualFiliais(Filial expected, Filial actual)
    {
        Assert.Equal(expected.NomeDeExibicao, actual.NomeDeExibicao);
        Assert.Equal(expected.Estado, actual.Estado);
        Assert.Equal(expected.Cidade, actual.Cidade);
        Assert.Equal(expected.Cnpj, actual.Cnpj);
    }


    [Fact]
    public void GetById_DeveConsultarFilialPorId()
    {
        var filialObtida = _repository.GetById(_filial.Id);

        Assert.NotNull(filialObtida);
        AssertEqualFiliais(_filial, filialObtida);
    }

    [Fact]
    public void GetById_DeveRetornarNuloCasoNaoExista()
    {
        var filial = _repository.GetById(-1);
        Assert.Null(filial);
    }

    [Fact]
    public void GetByNome_DeveConsultarFilialPorNome()
    {
        var filialObtida = _repository.GetByName(_filial.NomeDeExibicao);

        Assert.NotNull(filialObtida);
        AssertEqualFiliais(_filial, filialObtida.Single());
    }

    [Fact]
    public void GetByNome_DeveRetornarVazioCasoNaoExista()
    {
        var filial = _repository.GetByName("nomeInexistente");
        Assert.Empty(filial);
    }

    [Fact]
    public void Create_DeveCriarFilial()
    {
        var filial = FilialBuilder.Create().WithId(0).Build();
        _repository.Create(filial);
        var filialCreated = _context.Filiais.Single(f => f.Id == filial.Id);

        Assert.NotNull(filialCreated);
        AssertEqualFiliais(filial, filialCreated);
    }

    [Fact]
    public void Create_NomeDeExibicao_NaoDeveCriarComValorMaiorQueODaColuna()
    {
        var nomeMuitoGrande = new Randomizer().String2(31);
        var filial = FilialBuilder.Create().WithNome(nomeMuitoGrande).WithId(0).Build();

        Assert.Throws<OverflowException>(()=> _repository.Create(filial))
            .WithMessage($"Valor muito grande para ser armazenado : {filial.NomeDeExibicao}");
    }

    [Fact]
    public void Create_Cidade_NaoDeveCriarComValorMaiorQueODaColuna()
    {
        var nomeMuitoGrande = new Randomizer().String2(41);
        var filial = FilialBuilder.Create().WithCidade(nomeMuitoGrande).WithId(0).Build();

        Assert.Throws<OverflowException>(() => _repository.Create(filial))
            .WithMessage($"Valor muito grande para ser armazenado : {filial.Cidade}");
    }

    [Fact]
    public void Create_DeveLancarExceptionSeIdForDiferenteDe0()
    {
        var filial = FilialBuilder.Create().Build();

        Assert.Throws<InvalidOperationException>(() => _repository.Create(filial))
            .WithMessage("Nao e possivel armazenar um objeto que possui ID definido");
    }

    [Fact]
    public void Create_DeveAtribuirIdAoObjetoCriado()
    {
        Assert.NotEqual(0, _filial.Id);
    }
}
