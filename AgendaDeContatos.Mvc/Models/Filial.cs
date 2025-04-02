using System.ComponentModel.DataAnnotations;

namespace AgendaDeContatos.Mvc.Models;

public class Filial
{
    public int Id { get; init; }

    [Required(ErrorMessage = "o Nome e obrigatório")]
    public string Nome { get; set; } = null!;

    [MaxLength(40, ErrorMessage = "O tamnho máximo é 40")]
    public string? Cidade { get; set; }

    private string? _estado;

    [Length(maximumLength: 2, minimumLength: 2, ErrorMessage = "O tamnho deve ser exatos 2 caracteres")]
    public string? Estado { 
        get => _estado;
        set{
            if (value == null){
                _estado = value;
                return;
            }

            if (value.Length != 2 || char.IsDigit(value[0]) || char.IsDigit(value[1]))
                throw new ArgumentException($"Estado invalido : {value}");

            _estado = value.ToUpper();
        }    
    }

    private string? _cnpj;

    [Length(maximumLength: 14, minimumLength: 14, ErrorMessage = "O tamanho deve ser exatos 14 caracteres, Sem pontos ou virgulas")]
    public string? Cnpj { 
        get => _cnpj; 
        set {
            if(value == null){
                _cnpj = value;
                return;
            }

            if (value.Length != 14)
                throw new ArgumentException($"Cnpj invalido : {value}");

            var charArray = value.ToCharArray();
            foreach(var itemChar in charArray)
                if (!char.IsDigit(itemChar))
                    throw new ArgumentException($"Cnpj invalido : {value}");

            _cnpj = value;
        }
    }

    public Filial() { }

    public Filial(string nomeDeExibicao)
    {
        Nome = nomeDeExibicao;
    }

    public List<Setor>? Setores { get; set; }
}
