namespace Nutra.Application.DTOs.Progressos;

public class ProgressosListarDTO
{
    public int IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public int IdDesafio { get; set; }
    public string TituloDesafio { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public string TipoDetalhe { get; set; } = string.Empty;
    public int QuantidadeAtual { get; set; } = 0;
    public int QuantidadeMeta { get; set; }
    
}
