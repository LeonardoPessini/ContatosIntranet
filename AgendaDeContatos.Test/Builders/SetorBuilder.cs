using AgendaDeContatos.Mvc.Models;
using Bogus;

namespace AgendaDeContatos.Test.Builders;

internal class SetorBuilder
{
    private int _id;
    private string _nome;
    private int _filialId;

    private SetorBuilder()
    {
        var random = new Random();

        _id = random.Next();
        _filialId = random.Next();
        _nome = new Faker().Company.CompanyName();
    }

    public static SetorBuilder Create()
    {
        return new SetorBuilder();
    }

    public Setor Build()
    {
        return new Setor(_nome, _filialId) { Id = _id };
    }

    public SetorBuilder WithId(int id)
    {
        _id = id; 
        return this;
    }

    public SetorBuilder WithNome(string nome)
    {
        _nome = nome;
        return this;
    }

    public SetorBuilder WithFilialId(int id)
    {
        _filialId = id;
        return this;
    }
}
