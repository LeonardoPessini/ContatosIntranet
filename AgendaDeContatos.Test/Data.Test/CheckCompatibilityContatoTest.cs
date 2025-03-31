using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;

namespace AgendaDeContatos.Test.Data.Test;

public class CheckCompatibilityContatoTest
{
    private CheckCompatibilityContato _compatibility;

    public CheckCompatibilityContatoTest()
    {
        _compatibility = new CheckCompatibilityContato();
    }

    [Fact]
    public void Verify_IsCompatible_NaoLancaExceptionSeCompativel()
    {
        var randomizer = new Randomizer();
        var nomeOk = randomizer.String2(50);
        var ramalOk = randomizer.String2(10);
        var celularOk = randomizer.String2(14);
        var emailOk = randomizer.String2(100);

        var contato = ContatoBuilder.Create()
                                    .WithNome(nomeOk)
                                    .WithRamal(ramalOk)
                                    .WithEmail(emailOk)
                                    .WithCelular(celularOk)
                                    .Build();

        _compatibility.Verify(contato);
        Assert.True(_compatibility.IsCompatible(contato));
    }

    [Fact]
    public void Verify_IsCompatible_LancaExceptionSeNomeIncompativel()
    {
        var nomeMuitoGrande = new Randomizer().String2(51);
        var contato = ContatoBuilder.Create()
                                    .WithNome(nomeMuitoGrande)
                                    .Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Nome}");

        Assert.False(_compatibility.IsCompatible(contato));
    }

    [Fact]
    public void Verify_IsCompatible_LancaExceptionSeRamalIncompativel()
    {
        var ramalMuitoGrande = new Randomizer().String2(11);
        var contato = ContatoBuilder.Create()
                                    .WithRamal(ramalMuitoGrande)
                                    .Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Ramal}");

        Assert.False(_compatibility.IsCompatible(contato));
    }

    [Fact]
    public void Verify_IsCompatible_LancaExceptionSeEmailIncompativel()
    {
        var emailMuitoGrande = new Randomizer().String2(101);
        var contato = ContatoBuilder.Create()
                                    .WithEmail(emailMuitoGrande)
                                    .Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Email}");

        Assert.False(_compatibility.IsCompatible(contato));
    }

    [Fact]
    public void Verify_IsCompatible_LancaExceptionSeCelularIncompativel()
    {
        var celularMuitoGrande = new Randomizer().String2(15);
        var contato = ContatoBuilder.Create()
                                    .WithCelular(celularMuitoGrande)
                                    .Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
            .WithMessage($"Valor muito grande para ser armazenado : {contato.Celular}");

        Assert.False(_compatibility.IsCompatible(contato));
    }
}
