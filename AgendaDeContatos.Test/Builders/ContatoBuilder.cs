
using AgendaDeContatos.Mvc.Models;
using Bogus;

namespace AgendaDeContatos.Test.Builders;

internal class ContatoBuilder
{
    private int _id;
    private string _nome;
    private string _email;
    private string _celular;
    private string _ramal;
    private int _setorId;

    private ContatoBuilder()
    {
        var faker = new Faker();
        var random = new Random();

        _id = random.Next();
        _setorId = random.Next();
        _nome = faker.Person.FullName;
        _email = faker.Person.Email;
        _celular = faker.Person.Phone;
        _ramal = faker.Random.String2(4,"1234567890");
    }

    public static ContatoBuilder Create()
    {
        return new ContatoBuilder();
    }

    public Contato Build()
    {
        return new Contato(_nome, _setorId)
        {
            Id = _id,
            Ramal = _ramal,
            Celular = _celular,
            Email = _email
        };
    }

    public ContatoBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public ContatoBuilder WithNome(string nome)
    {
        _nome = nome;
        return this;
    }

    public ContatoBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public ContatoBuilder WithCelular(string celular)
    {
        _celular = celular;
        return this;
    }

    public ContatoBuilder WithRamal(string ramal)
    {
        _ramal = ramal;
        return this;
    }

    public ContatoBuilder WithSetorId(int seotrId)
    {
        _setorId = seotrId;
        return this;
    }
}