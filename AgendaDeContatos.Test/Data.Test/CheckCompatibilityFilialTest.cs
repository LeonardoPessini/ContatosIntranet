using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;
using EntityFrameworkCore.Testing.Moq;

namespace AgendaDeContatos.Test.Data.Test;

public class CheckCompatibilityFilialTest
{
    private CheckCompatibilityFilial _compatibility;
    private readonly Randomizer _randomizer;


    public CheckCompatibilityFilialTest()
    {
        _randomizer = new Randomizer();
        _compatibility = new CheckCompatibilityFilial();
    }


    [Fact]
    public void Verify_IsCompatible_ValidaCompatibilidadeOK()
    {
        var nomeAceitavel = _randomizer.String2(30);
        var cidadeAceitavel = _randomizer.String2(40);

        var filialOk = FilialBuilder.Create()
                                    .WithNome(nomeAceitavel)
                                    .WithCidade(cidadeAceitavel)
                                    .Build();
        _compatibility.Verify(filialOk);
        Assert.True(_compatibility.IsCompatible(filialOk));
    }


    [Fact]
    public void Verify_IsCompatible_ValidarNomeDeExibicaoIncompativel()
    {
        var nomeExibicaoMuitoGrande = _randomizer.String2(31);
        var filialComNomeOverflow = FilialBuilder.Create().WithNome(nomeExibicaoMuitoGrande).Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(filialComNomeOverflow))
                                        .WithMessage($"Valor muito grande para ser armazenado : {filialComNomeOverflow.Nome}");
        Assert.False(_compatibility.IsCompatible(filialComNomeOverflow));
    }


    [Fact]
    public void Verify_IsCompatible_ValidarCidadeIncompativel()
    {
        var nomeCidadeMuitoGrande = _randomizer.String2(41);
        var filialComCidadeOverflow = FilialBuilder.Create().WithCidade(nomeCidadeMuitoGrande).Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(filialComCidadeOverflow))
                                        .WithMessage($"Valor muito grande para ser armazenado : {filialComCidadeOverflow.Cidade}");
        Assert.False(_compatibility.IsCompatible(filialComCidadeOverflow));
    }
}
