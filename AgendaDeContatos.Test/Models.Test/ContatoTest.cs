using AgendaDeContatos.Mvc.Models;
using Bogus;

namespace AgendaDeContatos.Test.Models.Test;

public class ContatoTest
{
    private readonly int _id;
    private readonly string _name;
    private readonly string _email;
    private readonly string _ramal;
    private readonly string _celular;
    private readonly int _setorId;

    public ContatoTest()
    {
        var faker = new Faker();
        var random = new Random();

        _id = random.Next();
        _name = faker.Person.FullName;
        _email = faker.Person.Email;
        _ramal = new Randomizer().AlphaNumeric(random.Next(4, 11));
        _celular = faker.Person.Phone;
        _setorId = random.Next();
    }

    [Fact]
    public void New_DeveCriarContato()
    {
        var contato = new Contato(_name,_setorId)
        {
            Email = _email,
            Ramal = _ramal,
            Celular = _celular,
            Id = _id
        };

        Assert.NotNull( contato );
        Assert.Equal(_id, contato.Id );
        Assert.Equal(_name, contato.Nome );
        Assert.Equal(_email, contato.Email );
        Assert.Equal(_ramal, contato.Ramal );
        Assert.Equal(_celular,contato.Celular );
        Assert.Equal(_setorId, contato.SetorId );
    }

    [Fact]
    public void New_DeveCriarContatoApenasComPArametrosNecessarios()
    {
        var contato = new Contato(_name, _setorId);

        Assert.NotNull(contato);
        Assert.Equal(0, contato.Id);
        Assert.Equal(_name, contato.Nome);
        Assert.Null(contato.Email);
        Assert.Null(contato.Ramal);
        Assert.Null(contato.Celular);
        Assert.Equal(_setorId, contato.SetorId);
    }

}
