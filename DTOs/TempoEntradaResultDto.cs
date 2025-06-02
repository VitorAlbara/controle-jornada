using System.Text.Json.Serialization;

namespace controle_jornada.DTOs
{
    internal class TempoEntradaResultDto
    {
        [JsonPropertyName("time_entries")]
        public List<TempoEntradaDto> TempoEntradas { get; set; }
    }
}
