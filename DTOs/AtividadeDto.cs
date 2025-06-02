using System.Text.Json.Serialization;

namespace controle_jornada.DTOs
{
    public class AtividadeDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}
