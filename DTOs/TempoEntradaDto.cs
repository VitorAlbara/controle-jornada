using System.Text.Json.Serialization;

namespace controle_jornada.DTOs
{
     public class TempoEntradaDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("hours")]
        public double Horas { get; set; }

        [JsonPropertyName("spent_on")]
        public string GastoEm { get; set; }

        [JsonPropertyName("activity")]
        public AtividadeDto Atividade { get; set; }

        [JsonIgnore]
        public int AtividadeId { get; set; }

        [JsonIgnore]
        public int? ProjetoId { get; set; }

        [JsonPropertyName("issue")]
        public IssueDto Issue { get; set; }

        [JsonIgnore]
        public int? IssueId { get; set; }

        [JsonPropertyName("comments")]
        public string Comentarios { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<CampoCustomizadoDto> CamposCustomizados { get; set; } = new();
    }
}
