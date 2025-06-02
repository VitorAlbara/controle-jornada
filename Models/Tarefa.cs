using controle_jornada.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_jornada.Models
{
    [Table("tarefas")]
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int UsuarioId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TamanhoE Tamanho { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateOnly DataInicial { get; set; }
        public DateOnly DataFinal { get; set; }
        public int Projeto { get; set; }
        public int VersaoId { get; set; }
        public int ProjetoVersaoId { get; set; }
        public Versao Versao { get; set; }

        public ICollection<Entrada> Entradas { get; set; }
        public ICollection<EntradaLocal> EntradasLocais { get; set; }

        public Tarefa() { }
    }
}
