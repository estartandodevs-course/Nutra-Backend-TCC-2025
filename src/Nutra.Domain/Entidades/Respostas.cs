namespace Nutra.Domain.Entidades;

public class Respostas : Entity
{
    public string? Descricao { get; set;}
    public int IdUsuario { get; set; }
    public int IdOpcao { get; set; }
    public int IdPergunta { get; set; }
    public int IdQuestionario { get; set; }

    public Usuarios Usuarios { get; set; }
    public Opcoes Opcoes { get; set; }
    public Perguntas Perguntas { get; set; }
    public Questionarios Questionarios { get; set; }
    
    public Respostas(){ }
    
    public Respostas
        (
            string? descricao,
            int idUsuario,
            int idOpcao,
            int idPergunta,
            int idQuestionario)
    {
        Descricao = descricao;
        IdUsuario = idUsuario;
        IdOpcao = idOpcao;
        IdPergunta = idPergunta;
        IdQuestionario = idQuestionario;
    }
}