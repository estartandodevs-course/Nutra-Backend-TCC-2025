using System.Text.Json.Serialization;
using Nutra.Domain.Enums;

namespace Nutra.Application.DTOs;

public class TiposRegistrosResponseDto
{
    public required List<CategoriaDetalhe> TiposDetalhes { get; set; }
    public class CategoriaDetalhe {
        public int Codigo { get; set; }
        public string Descicao { get; set; }
    }
}