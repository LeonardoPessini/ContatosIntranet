using AgendaDeContatos.Mvc.Models;
using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContatos.Test.Builders;
internal class FilialBuilder
{
    private int _id;
    private string _nomeDeExibicao;
    private string? _cidade;
    private string? _estado;
    private string? _cnpj;

    private FilialBuilder()
    {
        var faker = new Faker();

        _id = Random.Shared.Next();
        _nomeDeExibicao = faker.Company.CompanyName();
        _cidade = faker.Address.City();
        _estado = faker.Random.String2(2).ToUpper();
        _cnpj = faker.Company.Cnpj().Replace(".", "").Replace("/", "").Replace("-", "");
    }

    internal static FilialBuilder Create()
    {
        return new FilialBuilder();
    }

    internal Filial Build()
    {
        return new Filial(_nomeDeExibicao)
        {
            Id = _id,
            Nome = _nomeDeExibicao,
            Cidade = _cidade,
            Estado = _estado,
            Cnpj = _cnpj
        };
    }

    internal FilialBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    internal FilialBuilder WithNome(string nome)
    {
        _nomeDeExibicao = nome;
        return this;
    }

    internal FilialBuilder WithCidade(string cidade)
    {
        _cidade = cidade;
        return this;
    }

    internal FilialBuilder WithEstado(string estado)
    {
        _estado = estado;
        return this;
    }

    internal FilialBuilder WithCnpj(string cnpj)
    {
        _cnpj = cnpj;
        return this;
    }
}
