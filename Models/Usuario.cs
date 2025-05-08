namespace controle_jornada.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public string ChaveApi { get; set; } = string.Empty;
        public int ProjetoId { get; set; }
    }
}
