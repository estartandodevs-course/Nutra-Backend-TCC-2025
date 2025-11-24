using MediatR;

namespace Nutra.Application.CasosDeUso.Receitas.Criar;

public class CriarReceitaCommand : IRequest<CriarReceitaCommandResponse>
{
    public string Nome { get; set; } = string.Empty;
    public string Ingredientes { get; set; } = string.Empty;
    public string ModoPreparo { get; set; } = string.Empty;
    public string ImagemBase64 { get; set; } = string.Empty;

    public CriarReceitaCommand(string nome, string ingredientes, string modoPreparo, string imagemBase64)
    {
        Nome = nome;
        Ingredientes = ingredientes;
        ModoPreparo = modoPreparo;
        ImagemBase64 = imagemBase64;
    }
}
