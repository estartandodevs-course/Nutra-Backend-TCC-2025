using MediatR;
using System.Net;
using Nutra.Application.DTOs;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Registros.Atualizar;

public class AtualizarRegistrosCommandHandler :
    IRequestHandler<AtualizarRegistrosCommand, Response<RegistroResponseDto>>
{
    private readonly IUsuarioRepository _usuario;
    private readonly IRegistrosRepository _registro;
    private readonly ITipoRegistroRepository _tipoRegistro;


    public AtualizarRegistrosCommandHandler(IUsuarioRepository usuario, IRegistrosRepository registro, 
        ITipoRegistroRepository tipoRegistro)
    {
        _usuario = usuario;
        _registro = registro;
        _tipoRegistro = tipoRegistro;
    }

    public async Task<Response<RegistroResponseDto>> Handle(AtualizarRegistrosCommand comando,
        CancellationToken cancellationToken)
    {
        if (comando == null)
                return Response<RegistroResponseDto>.Erro("Comando inválido");

            var registro = await _registro.ListarId(comando.Id, cancellationToken);
            if (registro == null)
                return Response<RegistroResponseDto>.Erro($"Registro com Id {comando.Id} não encontrado");

            var usuario = await _usuario.ListarId(registro.IdUsuario, cancellationToken);
            if (usuario == null)
                return Response<RegistroResponseDto>.Erro($"Usuário com Id {registro.IdUsuario} não encontrado");

            registro.Quantidade = comando.Quantidade ?? registro.Quantidade;
            registro.Observacao = comando.Observacao ?? registro.Observacao;

            TipoRegistro? tipoRegistroNovo = null;

            if (comando.TipoDetalhe.HasValue)
            {
                // procura o tipo atual do registro
                var tipoRegistroAtual =
                    await _tipoRegistro.ObterPorId(registro.IdTipoRegistro, cancellationToken);
                if (tipoRegistroAtual == null)
                    return Response<RegistroResponseDto>.Erro(
                        $"TipoRegistro atual com Id {registro.IdTipoRegistro} não encontrado");

                // Buscar o novo tipo dentro da mesma categoria
                tipoRegistroNovo = await _tipoRegistro.ObterPorCategoriaETipo(
                    categoria: tipoRegistroAtual.Categoria,
                    tipoEspecifico: comando.TipoDetalhe.Value,
                    cancellationToken);

                if (tipoRegistroNovo == null)
                    return Response<RegistroResponseDto>.Erro(
                        $"Tipo de detalhe '{comando.TipoDetalhe}' não encontrado para categoria '{tipoRegistroAtual.Categoria}'");

                // impedir que usuario troque as categoriass, ele só pode atualizar o tipo especifico
                if (tipoRegistroNovo.Categoria != tipoRegistroAtual.Categoria)
                    return Response<RegistroResponseDto>.Erro(
                        $"Não é permitido alterar de categoria '{tipoRegistroAtual.Categoria}' para '{tipoRegistroNovo.Categoria}'");

                registro.IdTipoRegistro = tipoRegistroNovo.Id;
            }

            await _registro.AtualizarRegistros(registro, usuario.Id, cancellationToken);

            var dto = new RegistroResponseDto
            {
                Id = registro.Id,
                Quantidade = registro.Quantidade,
                Observacao = registro.Observacao ?? string.Empty,
                IdUsuario = registro.IdUsuario,
                IdTipoRegistro = registro.IdTipoRegistro,
                NomeUsuario = usuario.Nome ?? string.Empty,
                Categoria = tipoRegistroNovo?.Categoria.ToString() ?? string.Empty,
                TipoDetalhe = tipoRegistroNovo?.TipoDetalhe.ToString()
                              ?? comando.TipoDetalhe?.ToString()
                              ?? string.Empty
            };

            return Response<RegistroResponseDto>.Ok(dto);
        }
    }
