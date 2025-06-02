using System.Text.Json.Serialization;

namespace controle_jornada.DTOs
{
    public class IssueDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
