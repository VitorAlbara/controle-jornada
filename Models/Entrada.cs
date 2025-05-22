using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_jornada.Models
{
    [Table("entrada")]
    public class Entrada
    {
        [Key]
        public int Id { get; set; }
        public string TarefaId { get; set; }
        public int TarefaUsuarioId { get; set; }
        public Task Tarefa { get; set; }
        public DateOnly DataEntrada { get; set; }
        public int Duracao { get; set; }
    }
}
