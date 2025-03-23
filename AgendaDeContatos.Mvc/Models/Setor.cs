namespace AgendaDeContatos.Mvc.Models;

public class Setor
{
    public int Id { get; init; }
    public string Nome { get; set; } = null!;

    public int FilialId { get; set; }
    public Filial Filial { get; set; } = null!;

    private Setor() { }

    public Setor(string nome, int filialId)
    {
        Nome = nome;
        FilialId = filialId;
    }
    public List<Contato>? Contatos { get; set; }
}
