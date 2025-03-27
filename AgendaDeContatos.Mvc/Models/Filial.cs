namespace AgendaDeContatos.Mvc.Models;

public class Filial
{
    public int Id { get; init; }
    public string NomeDeExibicao { get; set; } = null!;
    public string? Cidade { get; set; }

    private string? _estado;
    public string? Estado { 
        get => _estado;
        set{
            if (value == null)
            {
                _estado = value;
                return;
            }

            if (value.Length != 2 || char.IsDigit(value[0]) || char.IsDigit(value[1]))
                throw new ArgumentException($"Estado invalido : {value}");

            _estado = value.ToUpper();
        }    
    }

    private string? _cnpj;
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

    private Filial() { }

    public Filial(string nomeDeExibicao)
    {
        NomeDeExibicao = nomeDeExibicao;
    }

    public List<Setor>? Setores { get; set; }
}
