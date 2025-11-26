using MediatR;
using Nutra.Application.DTOs.Progressos;
using Nutra.Domain.Repository;
namespace Nutra.Application.CasosDeUso.Progressos.Listar;

public class ObterPorUsuarioHandler : IRequestHandler<ObterPorUsuarioQuery, Response<List<ProgressosListarDTO>>>
{
    //preciso receber o id do usuario,
    //consultar a tabela progressos e procurar por Id usuario lá dentro,
    //criar uma lista com todos os progressos do usuario,
    //filtra a lista para conter apenas os progressos ativos e não concluidos
    //retorna a lista
    private readonly IProgressosRepository _progressosRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    public ObterPorUsuarioHandler(IProgressosRepository progressosRepository, IUsuarioRepository usuarioRepository)
    {
        _progressosRepository = progressosRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Response<List<ProgressosListarDTO>>> Handle(ObterPorUsuarioQuery query,
        CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ListarId(query.IdUsuario, cancellationToken);
        if (usuario == null)
            return Response<List<ProgressosListarDTO>>.Erro("Nenhum usuario encontrado.");

        var progressos = await _progressosRepository.ObterPorUsuario(usuario.Id, cancellationToken);
        if (progressos == null)
            return Response<List<ProgressosListarDTO>>.Erro(
                "Não foi encontrado nenhum processo vinculado a esse usuario");
        
        var listaProgressosDto = progressos.Select(r => new ProgressosListarDTO
        {
            IdUsuario = r.IdUsuario,
            NomeUsuario = r.Usuario?.Nome ?? string.Empty,

            IdDesafio = r.IdDesafio,

            TituloDesafio = r.Desafio?.Titulo ?? string.Empty,

            Categoria = r.Desafio?.TipoRegistro?.Categoria.ToString() ?? string.Empty,

            TipoDetalhe = r.Desafio?.TipoRegistro?.TipoDetalhe.ToString() ?? string.Empty,

            QuantidadeAtual = r.QuantidadeAtual,

            QuantidadeMeta = r.Desafio?.QuantidadeMeta ?? 0
        }).ToList();


        return Response<List<ProgressosListarDTO>>.Ok(listaProgressosDto);
    }
}