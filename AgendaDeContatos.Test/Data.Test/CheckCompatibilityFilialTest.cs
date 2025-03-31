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
    private Filial _filialComNomeOverflow;
    private Filial _filialComCidadeOverflow;
    private Filial _filialOk;
    
    public CheckCompatibilityFilialTest()
    {
        var randomizer = new Randomizer();
        var nomeExibicaoMuitoGrande = randomizer.String2(31);
        var nomeCidadeMuitoGrande = randomizer.String2(41);
        var nomeAceitavel = randomizer.String2(30);
        var cidadeAceitavel = randomizer.String2(40);
        _compatibility = new CheckCompatibilityFilial();

        _filialComNomeOverflow = FilialBuilder.Create().WithNome(nomeExibicaoMuitoGrande).Build();
        _filialComCidadeOverflow = FilialBuilder.Create().WithCidade(nomeCidadeMuitoGrande).Build();
        _filialOk = FilialBuilder.Create().WithNome(nomeAceitavel).WithCidade(cidadeAceitavel).Build();
    }

    [Fact]
    public void IsCompatible_RetornarTrueNaCompatibilidade()
    {
        Assert.True(_compatibility.IsCompatible(_filialOk));
    }

    [Fact]
    public void Verify_NaoLancaExceptionNaCompatibilidade()
    {
        _compatibility.Verify(_filialOk);
    }

    [Fact]
    public void Verify_NomeDeExibicao_LancarExceptionNaIncompatibilidade()
    {
        Assert.Throws<OverflowException>(() =>
            _compatibility.Verify(_filialComNomeOverflow))
            .WithMessage($"Valor muito grande para ser armazenado : {_filialComNomeOverflow.NomeDeExibicao}");
    }

    [Fact]
    public void IsCompatible_NomeDeExibicao_RetornarFalseNaIncompatibilidade()
    {
        Assert.False(_compatibility.IsCompatible( _filialComNomeOverflow));
    }

    [Fact]
    public void Verify_Cidade_LancarExceptionNaIncompatibilidade()
    {
        Assert.Throws<OverflowException>(() =>
            _compatibility.Verify(_filialComCidadeOverflow))
            .WithMessage($"Valor muito grande para ser armazenado : {_filialComCidadeOverflow.Cidade}");
    }

    [Fact]
    public void IsCompatible_Cidade_RetornarFalseNaIncompatibilidade()
    {
        Assert.False(_compatibility.IsCompatible(_filialComCidadeOverflow));
    }
}
