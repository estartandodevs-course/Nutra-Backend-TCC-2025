using MediatR;
using Nutra.Application.DTOs;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosIdHandler 
    : IRequestHandler<ListarRegistrosIdQuery, Response<RegistroResponseDto>>
{
    private readonly IRegistrosRepository _registro;

    public ListarRegistrosIdHandler(IRegistrosRepository registro)
    {
        _registro = registro;
    }

    public async Task<Response<RegistroResponseDto>> Handle(
        ListarRegistrosIdQuery query,
        CancellationToken cancellationToken)
    {
        var registro = await _registro.ListarId(query.Id, cancellationToken);

        if (registro == null)
            return Response<RegistroResponseDto>.Erro("Registro não encontrado.");

        var dto = new RegistroResponseDto
        {
            Id = registro.Id,
            Quantidade = registro.Quantidade,
            Observacao = registro.Observacao ?? string.Empty,
            IdUsuario = registro.IdUsuario,
            IdTipoRegistro = registro.IdTipoRegistro,
            NomeUsuario = registro.Usuarios?.Nome ?? string.Empty,
            Categoria = registro.Tipo?.Categoria.ToString() ?? string.Empty,
            TipoDetalhe = registro.Tipo?.TipoDetalhe.ToString() ?? string.Empty
        };

        return Response<RegistroResponseDto>.Ok(dto);
    }
}