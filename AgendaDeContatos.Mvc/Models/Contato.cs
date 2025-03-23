namespace AgendaDeContatos.Mvc.Models;

public class Contato
{
    public int Id { get; init; }
    public string Nome { get; set; } = null!;
    public string? Ramal { get; set; }
    public string? Email { get; set; }
    public string? Celular { get; set; }

    public int SetorId { get; set; }
    public Setor Setor { get; set; } = null!;

    private Contato() { }

    public Contato(string nome, int setorId)
    {
        Nome = nome;
        SetorId = setorId;
    }
}
