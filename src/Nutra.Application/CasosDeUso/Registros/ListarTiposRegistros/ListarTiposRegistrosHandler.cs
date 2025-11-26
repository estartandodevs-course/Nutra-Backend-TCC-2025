using MediatR;
using System.Net;
using Nutra.Application.DTOs;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Registros.Atualizar;

public class ListarTiposRegistrosHandler :
    IRequestHandler<ListarTiposRegistrosQuery, Response<TiposRegistrosResponseDto>>
{
    private readonly ITipoRegistroRepository _tiposRegistrosRepository;

    public ListarTiposRegistrosHandler(ITipoRegistroRepository tiposRegistrosRepository)
    {
        _tiposRegistrosRepository = tiposRegistrosRepository;
    }

    public async Task<Response<TiposRegistrosResponseDto>> Handle(ListarTiposRegistrosQuery request, CancellationToken cancellationToken)
    {
        if (!request.ValidarDados())
        {
            return Response<TiposRegistrosResponseDto>.Erro(
                string.Join("; ", request.ResultadoValidacao.Errors.Select(e => e.ErrorMessage))
            );
        }

        List<TipoRegistro> registros = await _tiposRegistrosRepository.ObterPorCategoria(request.Categoria, cancellationToken);

        if (registros.Count == 0)
            return Response<TiposRegistrosResponseDto>.Erro("Categoria não possui nenhuma subcategoria cadastrada.");

        TiposRegistrosResponseDto responseDto = new()
        {
            TiposDetalhes = [.. registros.Select(r => new TiposRegistrosResponseDto.CategoriaDetalhe
                {
                    Codigo = (int)r.TipoDetalhe,
                    Descicao = r.TipoDetalhe.ToString()
                })
                .DistinctBy(d => d.Descicao)
                .ToList()
            ]
        };

        return Response<TiposRegistrosResponseDto>.Ok(responseDto);
    }
}
