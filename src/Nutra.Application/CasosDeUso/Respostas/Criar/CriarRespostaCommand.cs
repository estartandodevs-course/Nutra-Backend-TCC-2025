using MediatR;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Respostas.Criar
{
    public class CriarRespostaCommand : IRequest<Response<List<Domain.Entidades.Respostas>>>
    {
        public int IdUsuario { get; set; }
        public int IdQuestionario { get; set; }
        public List<ItemResposta> Respostas { get; set; }

        public class ItemResposta
        {
            public string Descricao { get; set; }
            public int IdOpcao { get; set; }
            public int IdPergunta { get; set; }
        }
    }
}