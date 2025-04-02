using System.ComponentModel.DataAnnotations;

namespace AgendaDeContatos.Mvc.Models;

public class Setor
{
    public int Id { get; init; }

    [Required(ErrorMessage = "o Nome e obrigatório")]
    public string Nome { get; set; } = null!;

    [Required(ErrorMessage = "Deve ser infromade a filial do setor")]
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
