using System.Net;
namespace Nutra.Application.CasosDeUso.Usuarios.Criar;

public class CriarUsuariosCommandResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public object? Dados { get; set; }
    public List<string>? MensagensErros { get; set; }

    public static CriarUsuariosCommandResponse Sucesso(HttpStatusCode statusCode, object? dados)
        => new() { StatusCode = statusCode, Dados = dados };

    public static CriarUsuariosCommandResponse ErroValidacao(HttpStatusCode statusCode, List<string> mensagensErros)
        => new() { StatusCode = statusCode, MensagensErros = mensagensErros};
}