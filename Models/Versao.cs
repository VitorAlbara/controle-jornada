using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_jornada.Models
{
    [Table("versoes")]
    public class Versao
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataVencimento { get; set; }
        public Projeto Projeto { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
