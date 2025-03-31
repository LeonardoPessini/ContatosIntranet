using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Test.Builders;
using AgendaDeContatos.Test.Utils;
using Bogus;

namespace AgendaDeContatos.Test.Data.Test;

public class CheckCompatibilityContatoTest
{
    private CheckCompatibilityContato _compatibility;
    private ContatoBuilder _contatoBuider;

    public CheckCompatibilityContatoTest()
    {
        _compatibility = new CheckCompatibilityContato();
        _contatoBuider = ContatoBuilder.Create();
    }


    [Fact]
    public void Verify_IsCompatible_ValidaCompatibilidadeOK()
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
    public void Verify_IsCompatible_ValidarNomeIncompativel()
    {
        var nomeMuitoGrande = new Randomizer().String2(51);
        var contato = _contatoBuider.WithNome(nomeMuitoGrande).Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
                                        .WithMessage($"Valor muito grande para ser armazenado : {contato.Nome}");
        Assert.False(_compatibility.IsCompatible(contato));
    }


    [Fact]
    public void Verify_IsCompatible_ValidarRamalIncompativel()
    {
        var ramalMuitoGrande = new Randomizer().String2(11);
        var contato = _contatoBuider.WithRamal(ramalMuitoGrande).Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
                                        .WithMessage($"Valor muito grande para ser armazenado : {contato.Ramal}");
        Assert.False(_compatibility.IsCompatible(contato));
    }


    [Fact]
    public void Verify_IsCompatible_ValidarEmailIncompativel()
    {
        var emailMuitoGrande = new Randomizer().String2(101);
        var contato = _contatoBuider.WithEmail(emailMuitoGrande).Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
                                        .WithMessage($"Valor muito grande para ser armazenado : {contato.Email}");
        Assert.False(_compatibility.IsCompatible(contato));
    }


    [Fact]
    public void Verify_IsCompatible_ValidarCelularIncompativel()
    {
        var celularMuitoGrande = new Randomizer().String2(15);
        var contato = _contatoBuider.WithCelular(celularMuitoGrande).Build();

        Assert.Throws<OverflowException>(() => _compatibility.Verify(contato))
                                        .WithMessage($"Valor muito grande para ser armazenado : {contato.Celular}");
        Assert.False(_compatibility.IsCompatible(contato));
    }
}
