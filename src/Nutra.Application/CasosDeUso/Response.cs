using System.Net;

namespace Nutra.Application.CasosDeUso;

public class Response<T>
{
    public bool Sucesso { get; set; }
    public T? Dados { get; set; }
    public string? Mensagem { get; set; }

    public static Response<T> Ok(T dados)
        => new() { Sucesso = true, Dados = dados };

    public static Response<T> Ok()
        => new() { Sucesso = true };
    public static Response<T> Erro(string mensagem)
        => new() { Sucesso = false, Mensagem = mensagem };
}
