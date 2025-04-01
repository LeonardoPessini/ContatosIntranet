using System.ComponentModel.DataAnnotations;

namespace AgendaDeContatos.Mvc.Models.ViewModel;

public class FilialViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage ="o Nome e obrigatório")]
    public string Nome { get; set; } = null!;

    [MaxLength(40,ErrorMessage ="O tamnho máximo é 40")]
    public string? Cidade { get; set; }

    [Length(maximumLength: 2, minimumLength: 2, ErrorMessage ="O tamnho deve ser exatos 2 caracteres")]
    public string? Estado { get; set; }

    [Length(maximumLength:14,minimumLength:14,ErrorMessage ="O tamanho deve ser exatos 14 caracteres, Sem pontos ou virgulas")]
    public string? Cnpj { get; set; }
}
