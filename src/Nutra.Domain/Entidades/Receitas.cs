using Nutra.Domain.Entidades;

namespace Nutra.Domain.Entidades;

public class Receitas : Entity
{
    public string Nome { get; set; } = string.Empty;
    public string Ingredientes { get; set; } = string.Empty;
    public string ModoPreparo { get; set; } = string.Empty;
    public string ImagemBase64 { get; set; } = string.Empty;

    public Receitas(string nome, string ingredientes, string modoPreparo, string imagemBase64)
    {
        Nome = nome;
        Ingredientes = ingredientes;
        ModoPreparo = modoPreparo;
        ImagemBase64 = imagemBase64;

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    // Construtor vazio pro EF
    public Receitas() { }
}
