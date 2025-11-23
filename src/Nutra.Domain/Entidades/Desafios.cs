namespace Nutra.Domain.Entidades;

public class Desafios : Entity
{
    public string Titulo { get; set;}
    public string? Descricao { get; set; }
    public int QuantidadeMeta { get; set; }
    public int XpRecompensa { get; set; }
    public int PontuacaoNecessaria { get; set;}
    public int Progresso { get; set; }
    public bool Ativo { get; set; } = false;
    public int IdTipoRegistro { get; set;}
    
    public TipoRegistro TipoRegistro { get; set;}
    
    public Desafios(){ }

    public Desafios
        (
            string titulo,
            string? descricao,
            int pontuacaoNecessaria, 
            int xpRecompensa,
            int progresso, 
            int quantidadeMeta, 
            int idTipoRegistro
          
            
        )
    {
        Titulo = titulo;
        Descricao = descricao;
        PontuacaoNecessaria = pontuacaoNecessaria;
        XpRecompensa = xpRecompensa;
        Progresso = progresso;
        QuantidadeMeta = quantidadeMeta;
        IdTipoRegistro = idTipoRegistro;


    }
}