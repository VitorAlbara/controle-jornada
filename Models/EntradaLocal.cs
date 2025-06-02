using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_jornada.Models
{

        [Table("entradas_locais")]
        public class EntradaLocal
        {
            [Key]
            public int Id { get; set; }
            public int TarefaId { get; set; }
            public int TarefaUsuarioId { get; set; }
            public Tarefa Tarefa { get; set; }
            public DateOnly DataEntrada { get; set; }
            public int Duracao { get; set; }
        }
}
