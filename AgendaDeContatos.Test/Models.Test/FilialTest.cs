using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;
using Bogus.Extensions.Brazil;

namespace AgendaDeContatos.Test.Models.Test;

public class FilialTest
{
    private readonly int _id;
    private readonly string _nomeDeExibicao;
    private readonly string _cidade;
    private readonly string _estado;
    private readonly string _cnpj;

    public FilialTest()
    {
        var faker = new Faker();

        _id = Random.Shared.Next();
        _nomeDeExibicao = faker.Company.CompanyName();
        _cidade = faker.Address.City();
        _estado = faker.Random.String2(2).ToUpper();
        _cnpj = faker.Company.Cnpj().Replace(".", "").Replace("/", "").Replace("-", "");
    }

    [Fact]
    public void New_DeveCriarFilialFull()
    {
        var filial = new Filial(_nomeDeExibicao)
        {
            Id = _id,
            Cidade = _cidade,
            Estado = _estado,
            Cnpj = _cnpj
        };

        Assert.NotNull(filial);
        Assert.Equal(_id, filial.Id);
        Assert.Equal(_nomeDeExibicao, filial.NomeDeExibicao);
        Assert.Equal(_cidade, filial.Cidade);
        Assert.Equal(_estado, filial.Estado);
        Assert.Equal(_cnpj, filial.Cnpj);
    }


    [Fact]
    public void New_DeveCriarFilialApenasComParametrosNecessarios()
    {
        var filial = new Filial(_nomeDeExibicao);

        Assert.NotNull(filial);
        Assert.Equal(0, filial.Id);
        Assert.Null(filial.Cnpj);
        Assert.Null(filial.Cidade);
        Assert.Null(filial.Estado);
        Assert.Equal(_nomeDeExibicao, filial.NomeDeExibicao);
    }


    private const string cnpjCom15Dgitos = "123456789012345";
    private const string cnpjCom13Digitos = "1234567890123";
    private const string cnpjComCaractereNaoNumerico = "123.567A9-1234";
    [Theory]
    [InlineData(cnpjCom15Dgitos)]
    [InlineData(cnpjCom13Digitos)]
    [InlineData(cnpjComCaractereNaoNumerico)]
    public void Cnpj_NaoDeveSerInvalido(string cnpjInvalido)
    {
        var filial = new Filial(_nomeDeExibicao);

        Assert.Throws<ArgumentException>(() => filial.Cnpj = cnpjInvalido)
            .WithMessage($"Cnpj invalido : {cnpjInvalido}");
    }

    private const string _estadoCom1Digito = "A";
    private const string _estadoCom3Digitos = "ABC";
    [Theory]
    [InlineData(_estadoCom1Digito)]
    [InlineData(_estadoCom3Digitos)]
    public void Estado_NaoDeveSerInvalido(string estadoInvalido)
    {
        var filial = FilialBuilder.Create().Build();

        Assert.Throws<ArgumentException>(() =>
            filial.Estado = estadoInvalido)
            .WithMessage($"Estado invalido : {estadoInvalido}");
    }

    [Fact]
    public void Estado_DeveSerUpper()
    {
        var estadoNotUper = "aa";
        var filial = FilialBuilder.Create().Build();
        
        filial.Estado = estadoNotUper;

        Assert.NotNull(filial.Estado);
        Assert.Equal(estadoNotUper.ToUpper(), filial.Estado);
    }

    [Fact]
    public void Estado_NaoDeveConterNumero()
    {
        var estadoInvalido = "12";
        var filial = FilialBuilder.Create().Build();

        Assert.Throws<ArgumentException>(() =>
            filial.Estado = estadoInvalido)
            .WithMessage($"Estado invalido : {estadoInvalido}");
    }

}
