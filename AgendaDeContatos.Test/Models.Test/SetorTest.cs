using AgendaDeContatos.Mvc.Models;
using Bogus;

namespace AgendaDeContatos.Test.Models.Test;
public class SetorTest
{
    private readonly int _id;
    private readonly string _nome;
    private readonly int _filialId;

    public SetorTest()
    {
        var faker = new Faker();
        var random = new Random();

        _id = random.Next();
        _nome = faker.Commerce.Department();
        _filialId = random.Next();
    }

    [Fact]
    public void New_DeveCriarSetor()
    {
        var setor = new Setor(_nome, _filialId)
        {
            Id = _id,
        };

        Assert.NotNull(setor);
        Assert.Equal(_id, setor.Id);
        Assert.Equal(_nome,setor.Nome);
        Assert.Equal(_filialId, setor.FilialId);
    }

    [Fact]
    public void New_DeveCriarSetorApenasComParametrosNecessarios()
    {
        var setor = new Setor(_nome, _filialId);

        Assert.NotNull(setor);
        Assert.Equal(0, setor.Id);
        Assert.Equal(_nome, setor.Nome);
        Assert.Equal(_filialId, setor.FilialId);
    }
}
