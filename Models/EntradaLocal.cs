﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_jornada.Models
{

        [Table("EntradasLocais")]
        public class EntradaLocal
        {
            [Key]
            public int Id { get; set; }
            public string TarefaId { get; set; }
            public int tarefaUsuarioId { get; set; }
            public Task Tarefa { get; set; }
            public DateOnly DataEntrada { get; set; }
            public int Duracao { get; set; }
        }
}
