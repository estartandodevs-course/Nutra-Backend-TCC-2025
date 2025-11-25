using MediatR;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Respostas.Criar
{
    public class CriarRespostaCommandHandler
        : IRequestHandler<CriarRespostaCommand, Response<List<Domain.Entidades.Respostas>>>
    {
        private readonly IRespostasRepository _respostasRepository;
        private readonly IRegrasDesafiosRepository _regrasDesafiosRepository;
        private readonly IProgressosRepository _progressosRepository;
        private readonly IValidacaoRepository _validacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CriarRespostaCommandHandler(
            IRespostasRepository respostasRepository,
            IValidacaoRepository validacaoRepository,
            IUsuarioRepository usuarioRepository,
            IProgressosRepository progressosRepository,
            IRegrasDesafiosRepository regrasDesafiosRepository)
        {
            _respostasRepository = respostasRepository;
            _validacaoRepository = validacaoRepository;
            _usuarioRepository = usuarioRepository;
            _progressosRepository = progressosRepository;
            _regrasDesafiosRepository = regrasDesafiosRepository;
        }

        public async Task<Response<List<Domain.Entidades.Respostas>>> Handle(
            CriarRespostaCommand comando,
            CancellationToken ct)
        {
            // validações
            var erro = await ValidarDados(comando, ct);
            if (erro != null) return erro;

            // monta entidades
            var respostas = comando.Respostas.Select(item => new Domain.Entidades.Respostas(
                item.Descricao,
                comando.IdUsuario,
                item.IdOpcao,
                item.IdPergunta,
                comando.IdQuestionario
            )).ToList();

            await _respostasRepository.CriarResposta(respostas, ct);

            await AdicionarDesafios(comando, ct);

            return Response<List<Domain.Entidades.Respostas>>.Ok(respostas);
        }

        private async Task<Response<List<Domain.Entidades.Respostas>>?> ValidarDados(
            CriarRespostaCommand comando,
            CancellationToken ct)
        {
            // validar usuário
            var usuario = await _usuarioRepository.ListarId(comando.IdUsuario, ct);
            if (usuario == null)
                return Response<List<Domain.Entidades.Respostas>>.Erro("Usuário não encontrado.");

            // validar questionário
            if (!await _validacaoRepository.ExisteQuestionario(comando.IdQuestionario, ct))
                return Response<List<Domain.Entidades.Respostas>>.Erro("Questionário inválido.");

            // verificar se já respondeu
            if (await _validacaoRepository.ExistemRespostas(comando.IdUsuario, ct))
                return Response<List<Domain.Entidades.Respostas>>.Erro("Usuário já respondeu o questionário.");

            // validar lista de respostas
            if (comando.Respostas == null || !comando.Respostas.Any())
                return Response<List<Domain.Entidades.Respostas>>.Erro("Nenhuma resposta enviada.");

            var perguntasIds = comando.Respostas.Select(r => r.IdPergunta).ToList();
            var opcoesIds = comando.Respostas.Select(r => r.IdOpcao).ToList();

            if (perguntasIds.Count != perguntasIds.Distinct().Count())
                return Response<List<Domain.Entidades.Respostas>>.Erro("Mais de uma resposta para a mesma pergunta.");

            if (perguntasIds.Any(id => id <= 0))
                return Response<List<Domain.Entidades.Respostas>>.Erro("ID de pergunta inválido.");

            if (opcoesIds.Any(id => id <= 0))
                return Response<List<Domain.Entidades.Respostas>>.Erro("ID de opção inválido.");

            if (!await _validacaoRepository.ExistemPerguntas(comando.IdQuestionario, perguntasIds, ct))
                return Response<List<Domain.Entidades.Respostas>>.Erro("Uma ou mais perguntas não encontradas.");

            if (!await _validacaoRepository.ExistemOpcoes(perguntasIds, opcoesIds, ct))
                return Response<List<Domain.Entidades.Respostas>>.Erro("Uma ou mais opções inválidas.");

            return null;
        }

        private async Task AdicionarDesafios(CriarRespostaCommand comando, CancellationToken ct)
        {
            List<CriarRespostaCommand.ItemResposta> respostas = comando.Respostas;

            var idsOpcoes = respostas.Select(r => r.IdOpcao).ToList();

            var todasRegras = new List<RegrasDesafios>();
            foreach (var idOpcao in idsOpcoes)
            {
                var regras = await _regrasDesafiosRepository.ObterPorIdOpcao(idOpcao, ct);
                todasRegras.AddRange(regras);
            }

            var desafiosComContagem = todasRegras
                .GroupBy(r => r.IdDesafio)
                .Select(g => new
                {
                    IdDesafio = g.Key,
                    Contagem = g.Count()
                })
                .ToList();

            var idsDesafiosValidos = todasRegras
                .Select(r => r.IdDesafio)
                .Distinct()
                .ToList();

            foreach (var idDesafio in idsDesafiosValidos)
            {
                var progresso = new Progressos(comando.IdUsuario, idDesafio)
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                };

                await _progressosRepository.AdicionarAsync(progresso.IdUsuario, progresso.IdDesafio, progresso.QuantidadeAtual, ct);
            }
        }
    }
}
