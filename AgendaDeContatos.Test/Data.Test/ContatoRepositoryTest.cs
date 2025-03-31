using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatos.Test.Data.Test;

public class ContatoRepositoryTest
{
    private AppDbContext _context;
    private IRepository<Contato> _repository;
    private Contato _contato;
    private Setor _setor;


    public ContatoRepositoryTest()
    {
        _context = Create.MockedDbContextFor<AppDbContext>();
        _repository = new ContatoRepository(_context, new CheckCompatibilityContato());

        var filial = FilialBuilder.Create().Build();
        _setor = SetorBuilder.Create().WithFilialId(filial.Id).Build();
        _contato = ContatoBuilder.Create().WithId(0).WithSetorId(_setor.Id).Build();

        _context.Filiais.Add(filial);
        _context.Setores.Add(_setor);
        _context.Conatatos.Add(_contato);
        _context.SaveChanges();
    }


    private void AssertEqualsContato(Contato expected, Contato actual)
    {
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Nome, actual.Nome);
        Assert.Equal(expected.Ramal, actual.Ramal);
        Assert.Equal(expected.Celular, actual.Celular);
        Assert.Equal(expected.Email, actual.Email);
        Assert.Equal(expected.SetorId, actual.SetorId);
    }


    [Fact]
    public void GetById_DeveConsultarPorId()
    {
        var contatoObtido = _repository.GetById(_contato.Id);

        Assert.NotNull(contatoObtido);
        AssertEqualsContato(_contato, contatoObtido);
    }


    [Fact]
    public void GetByName_DeveConsultarPorNome()
    {
        var contatoObtido = _repository.GetByName(_contato.Nome);

        Assert.NotNull(contatoObtido);
        Assert.NotEmpty(contatoObtido);
        Assert.Equal(_contato, contatoObtido.First());
    }


    [Fact]
    public void GetById_DeveRetornarNullCasoInexistente()
    {
        var contatoObtido = _repository.GetById(_contato.Id + 1);

        Assert.Null(contatoObtido);
    }


    [Fact]
    public void GetByNome_DeveRetornarNullCasoInexistente()
    {
        var contatoObtido = _repository.GetByName("NomeInexistente");

        Assert.Empty(contatoObtido);
    }


    [Fact]
    public void GetByName_DeveRetorContatoQueContiveremAExpressaoPassada()
    {
        var contatoObtido = _repository.GetByName(_contato.Nome.Substring(1, 1));

        Assert.NotEmpty(contatoObtido);
    }


    [Fact]
    public void Create_DeveCriarContato()
    {
        var contato = ContatoBuilder.Create().WithId(0).WithSetorId(_setor.Id).Build();

        _repository.Create(contato);

        var contatoCriado = _context.Conatatos.FirstOrDefault(c => c.Id == contato.Id);

        Assert.NotNull(contatoCriado);
        AssertEqualsContato(contato, contatoCriado);
    }


    [Fact]
    public void Create_DeveCriarContatoApenasComParametrosNecessarios()
    {
        var contato = new Contato("teste", _setor.Id) { Email = "teste@gmail.com" };

        _repository.Create(contato);
        var contatoCriado = _context.Conatatos.First(c => c.Id == contato.Id);

        Assert.NotNull(contatoCriado);
        AssertEqualsContato(contato, contatoCriado);
    }


    [Fact]
    public void Create_NaoDeveCriarSeNaoTiverNenhumMeioDeContato()
    {
        var contato = new Contato("teste", _setor.Id);

        Assert.Throws<InvalidOperationException>(() => _repository.Create(contato))
            .WithMessage("O registro deve conter ao menos um dos meios de contato preenchido.");
    }


    [Fact]
    public void Create_DeveAtribuirIdAoContatoCriado()
    {
        Assert.NotEqual(0, _contato.Id);
    }


    [Fact]
    public void Create_NaoDeveCriarContatoComNomeOverflow()
    {
        var nomeMuitoGrande = new Randomizer().String2(51);
        var contato = ContatoBuilder.Create()
                                    .WithNome(nomeMuitoGrande)
                                    .WithId(0)
                                    .WithSetorId(_setor.Id)
                                    .Build();

        Assert.Throws<OverflowException>(() => _repository.Create(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Nome}");
    }


    [Fact]
    public void Create_NaoDeveCriarContatoComRamalOverflow()
    {
        var ramalMuitoGrande = new Randomizer().String2(11);
        var contato = ContatoBuilder.Create()
                                    .WithRamal(ramalMuitoGrande)
                                    .WithId(0)
                                    .WithSetorId(_setor.Id)
                                    .Build();

        Assert.Throws<OverflowException>(() => _repository.Create(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Ramal}");
    }


    [Fact]
    public void Create_NaoDeveCriarContatoComEmailOverflow()
    {
        var emailMuitoGrande = new Randomizer().String2(101);
        var contato = ContatoBuilder.Create()
                                    .WithEmail(emailMuitoGrande)
                                    .WithId(0)
                                    .WithSetorId(_setor.Id)
                                    .Build();

        Assert.Throws<OverflowException>(() => _repository.Create(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Email}");
    }


    [Fact]
    public void Create_NaoDeveCriarContatoComCelularOverflow()
    {
        var celularMuitoGrande = new Randomizer().String2(15);
        var contato = ContatoBuilder.Create()
                                    .WithCelular(celularMuitoGrande)
                                    .WithId(0)
                                    .WithSetorId(_setor.Id)
                                    .Build();

        Assert.Throws<OverflowException>(() => _repository.Create(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Celular}");
    }


    [Fact]
    public void Create_NaoDeveCriarSeIdForAtribuido()
    {
        var contato = ContatoBuilder.Create().WithId(1).WithSetorId(_setor.Id).Build();

        Assert.Throws<InvalidOperationException>(() => _repository.Create(contato))
            .WithMessage("Nao e possivel armazenar um objeto que possui ID definido");
    }


    [Fact]
    public void Create_NaoDeveCriarSeNaoExistirSetorRelacionado()
    {
        var contato = ContatoBuilder.Create().WithId(0).WithSetorId(_setor.Id + 1).Build();

        Assert.Throws<InvalidOperationException>(() => _repository.Create(contato))
            .WithMessage($"Setor nao existe na base: {contato.SetorId}");
    }
}
