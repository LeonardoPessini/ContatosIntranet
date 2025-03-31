using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;
using EntityFrameworkCore.Testing.Moq;

namespace AgendaDeContatos.Test.Data.Test;

public class SetorRepositoryTest
{
    private AppDbContext _context;
    private ISetorRepository _repository;
    private Setor _setor;
    private Filial _filial;

    public SetorRepositoryTest()
    {
        _context = Create.MockedDbContextFor<AppDbContext>();
        _repository = new SetorRepository(_context, new CheckCompatibilitySetor());
        _setor = SetorBuilder.Create().Build();
        _filial = FilialBuilder.Create().Build();

        _context.Setores.Add(_setor);
        _context.Filiais.Add(_filial);
        _context.SaveChanges();
    }

    private void AssertEqualSetores(Setor expected, Setor actual)
    {
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Nome, actual.Nome);
        Assert.Equal(expected.FilialId, actual.FilialId);
    }


    [Fact]
    public void GetById_DeveConsultarPorId()
    {
        var setorObtido = _repository.GetById(_setor.Id);

        Assert.NotNull(setorObtido);
        AssertEqualSetores(_setor, setorObtido);
    }


    [Fact]
    public void GetByName_DeveConsultarPorNome()
    {
        var setorObtido = _repository.GetByName(_setor.Nome);

        Assert.NotNull(setorObtido);
        AssertEqualSetores(_setor, setorObtido.Single());
    }


    [Fact]
    public void GetById_DeveRetornarNullCasoInexistente()
    {
        var setorObtido = _repository.GetById(-1);

        Assert.Null(setorObtido);
    }


    [Fact]
    public void GetByNome_DeveRetornarNullCasoInexistente()
    {
        var setorObtido = _repository.GetByName("NomeInexistente");

        Assert.Empty(setorObtido);
    }


    [Fact]
    public void GetByName_DeveRetorSetorQueContiveremAExpressaoPassada()
    {
        var setorobtido = _repository.GetByName(_setor.Nome.Substring(1, 1));
    }


    [Fact]
    public void Create_DeveCriarSetor()
    {
        var nomeValido = new Randomizer().String2(40);
        var setor = SetorBuilder.Create().WithNome(nomeValido).WithId(0).WithFilialId(_filial.Id).Build();

        _repository.Create(setor);

        var setorCreated = _context.Setores.Single(s => s.Id == setor.Id);

        Assert.NotNull(setorCreated);
        AssertEqualSetores(setor, setorCreated);
    }

    [Fact]
    public void Create_DeveAtribuirIdAoSetorCriado()
    {
        Assert.NotEqual(0, _setor.Id);
    }


    [Fact]
    public void Create_NaoDeveCriarSetorComNomeOverflow()
    {
        var nomeMuitoGrande = new Randomizer().String2(41);
        var setor = SetorBuilder.Create().WithNome(nomeMuitoGrande).WithId(0).WithFilialId(_filial.Id).Build();

        Assert.Throws<OverflowException>(() => _repository.Create(setor))
            .WithMessage($"Valor muito grande para ser armazenado : {setor.Nome}");
    }


    [Fact]
    public void Create_NaoDeveCriarSeIdForAtribuido()
    {
        var setor = SetorBuilder.Create().WithId(1).Build();

        Assert.Throws<InvalidOperationException>(() => _repository.Create(setor))
            .WithMessage("Nao e possivel armazenar um objeto que possui ID definido");
    }


    [Fact]
    public void Create_NaoDeveCriarSeNaoExistirFilialRelacionada()
    {
        var setor = SetorBuilder.Create().WithId(0).WithFilialId(_filial.Id + 1).Build();

        Assert.Throws<InvalidOperationException>(() => _repository.Create(setor))
            .WithMessage($"Filial nao existe na base: {setor.FilialId}");
    }
}
