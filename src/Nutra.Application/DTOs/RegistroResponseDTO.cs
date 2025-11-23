using System.Text.Json.Serialization;

namespace Nutra.Application.DTOs;

public class RegistroResponseDto
{
    public string NomeUsuario { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string? Observacao { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public string TipoDetalhe { get; set; } = string.Empty;
    
    [JsonIgnore]
    public int Id { get; set; }
    
    [JsonIgnore] 
    public int IdUsuario { get; set; }
    
    [JsonIgnore]
    public int IdTipoRegistro { get; set; }


}