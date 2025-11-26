using MediatR;
using System.Net;
using Nutra.Application.DTOs;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Registros.ListarTiposRegistros;

public class ListarTiposRegistrosHandler :
    IRequestHandler<ListarTiposRegistrosQuery, Response<List<TiposRegistrosResponseDto>>>
{
    private readonly ITipoRegistroRepository _tiposRegistrosRepository;

    public ListarTiposRegistrosHandler(ITipoRegistroRepository tiposRegistrosRepository)
    {
        _tiposRegistrosRepository = tiposRegistrosRepository;
    }

    public async Task<Response<List<TiposRegistrosResponseDto>>> Handle(ListarTiposRegistrosQuery request, CancellationToken cancellationToken)
    {
        if (!request.ValidarDados())
        {
            return Response<List<TiposRegistrosResponseDto>>.Erro(
                string.Join("; ", request.ResultadoValidacao.Errors.Select(e => e.ErrorMessage))
            );
        }

        List<TipoRegistro> registros = await _tiposRegistrosRepository.ObterPorCategoria(request.Categoria, cancellationToken);

        if (registros.Count == 0)
            return Response<List<TiposRegistrosResponseDto>>.Erro("Categoria não possui nenhuma subcategoria cadastrada.");

        List<TiposRegistrosResponseDto> responseDto = [.. registros.Select(r => new TiposRegistrosResponseDto
                {
                    Codigo = (int)r.TipoDetalhe,
                    Descicao = r.TipoDetalhe.ToString()
                })
                .DistinctBy(d => d.Descicao)];

        return Response<List<TiposRegistrosResponseDto>>.Ok(responseDto);
    }
}
