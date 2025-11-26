using System.Net;

namespace Nutra.Application.CasosDeUso.Receitas.Criar;

public class CriarReceitaCommandResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Sucesso { get; set; }
    public object? Dados { get; set; }
    public List<string> MensagensErros { get; set; } = new();

    public static CriarReceitaCommandResponse Ok(HttpStatusCode statusCode, object? dados)
        => new()
        {
            StatusCode = statusCode,
            Sucesso = true,
            Dados = dados
        };

    public static CriarReceitaCommandResponse Erro(HttpStatusCode statusCode, List<string> erros)
        => new()
        {
            StatusCode = statusCode,
            Sucesso = false,
            MensagensErros = erros
        };
}
