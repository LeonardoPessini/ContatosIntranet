namespace AgendaDeContatos.Mvc.Models;

public class Filial
{
    public int Id { get; init; }
    public string NomeDeExibicao { get; set; } = null!;
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Cnpj { get; set; }

    private Filial() { }

    public Filial(string nomeDeExibicao)
    {
        NomeDeExibicao = nomeDeExibicao;
    }

    public List<Setor>? Setores { get; set; }
}
