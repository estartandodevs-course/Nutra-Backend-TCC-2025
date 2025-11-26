using System.Text.Json.Serialization;
using Nutra.Domain.Enums;

namespace Nutra.Application.DTOs;

public class TiposRegistrosResponseDto
{
    public required int Codigo { get; set; }
    public required string Descicao { get; set; }
}