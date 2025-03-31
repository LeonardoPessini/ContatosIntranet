using AgendaDeContatos.Mvc.Data.Context;
using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Models;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;
using EntityFrameworkCore.Testing.Moq;

namespace AgendaDeContatos.Test.Data.Test;

public class CheckCompatibilitySetorTest
{
    private CheckCompatibilitySetor _compatibility;
    private readonly Randomizer _randomizer;

    public CheckCompatibilitySetorTest()
    {
        _randomizer = new Randomizer();
        _compatibility = new CheckCompatibilitySetor();
    }


    [Fact]
    public void Verify_Iscompatible_ValidarCompatibilidadeOK()
    {
        var nomeAceitavel = _randomizer.String2(40);
        var setorOk = SetorBuilder.Create().WithNome(nomeAceitavel).Build();

        _compatibility.Verify(setorOk);
        Assert.True(_compatibility.IsCompatible(setorOk));
    }


    [Fact]
    public void Verify_LancaExceptionSeIncompativel()
    {
        var nomeMuitoGrande = _randomizer.String2(41);
        var setorComNomeOverflow = SetorBuilder.Create().WithNome(nomeMuitoGrande).Build();

        Assert.Throws<OverflowException>(() =>_compatibility.Verify(setorComNomeOverflow))
                                        .WithMessage($"Valor muito grande para ser armazenado : {setorComNomeOverflow.Nome}");
        Assert.False(_compatibility.IsCompatible(setorComNomeOverflow));
    }
}
