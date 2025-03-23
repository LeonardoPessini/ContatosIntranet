using AgendaDeContatos.Mvc.Models;
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
        _estado = faker.Address.State();
        _cnpj = faker.Company.Cnpj();
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
}
