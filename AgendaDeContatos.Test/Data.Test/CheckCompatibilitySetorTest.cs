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
    private Setor _setorComNomeOverflow;
    private Setor _setorOk;

    public CheckCompatibilitySetorTest()
    {
        var randomizer = new Randomizer();
        var nomeMuitoGrande = randomizer.String2(41);
        var nomeAceitavel = randomizer.String2(40);
        _compatibility = new CheckCompatibilitySetor();

        _setorComNomeOverflow = SetorBuilder.Create().WithNome(nomeMuitoGrande).Build();
        _setorOk = SetorBuilder.Create().WithNome(nomeAceitavel).Build();
    }

    [Fact]
    public void Iscompatible_Nome_DeveRetornarTrueSeCompativel()
    {
        Assert.True(_compatibility.IsCompatible(_setorOk));
    }

    [Fact]
    public void Verify_Nome_NaoLancaExceptionSeCompativel()
    {
        _compatibility.Verify(_setorOk);
    }

    [Fact]
    public void Verify_LancaExceptionSeIncompativel()
    {
        Assert.Throws<OverflowException>(() =>
            _compatibility.Verify(_setorComNomeOverflow))
            .WithMessage($"Valor muito grande para ser armazenado : {_setorComNomeOverflow.Nome}");
    }

    [Fact]
    public void IsCompatible_RetornaFalseSeIncompativel()
    {
        Assert.False(_compatibility.IsCompatible(_setorComNomeOverflow));
    }
}
