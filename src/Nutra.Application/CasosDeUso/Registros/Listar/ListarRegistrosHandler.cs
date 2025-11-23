using MediatR;
using Nutra.Application.DTOs;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosHandler
    : IRequestHandler<ListarRegistrosQuery, Response<List<RegistroResponseDto>>>
{
    private readonly IRegistrosRepository _registros;

    public ListarRegistrosHandler(IRegistrosRepository registros)
    {
        _registros = registros;
    }

    public async Task<Response<List<RegistroResponseDto>>> Handle(
        ListarRegistrosQuery comando,
        CancellationToken cancellationToken)
    {
        var lista = await _registros.ListarRegistros(cancellationToken);

        if (lista == null || lista.Count == 0)
            return Response<List<RegistroResponseDto>>.Erro("Nenhum registro encontrado.");

        var listaDto = lista.Select(r => new RegistroResponseDto
        {
            Id = r.Id,
            Quantidade = r.Quantidade,
            Observacao = r.Observacao,
            IdUsuario = r.IdUsuario,
            IdTipoRegistro = r.IdTipoRegistro,
            NomeUsuario = r.Usuarios?.Nome ?? string.Empty,
            Categoria = r.Tipo != null ? r.Tipo.Categoria.ToString() : string.Empty,
            TipoDetalhe = r.Tipo != null ? r.Tipo.TipoDetalhe.ToString() : string.Empty
        }).ToList();

        return Response<List<RegistroResponseDto>>.Ok(listaDto);
    }
}