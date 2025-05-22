using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_jornada.Models
{
        [Table("app_versao")]
        public class AppVersao
        {
            [Key]
            public Guid Id { get; set; } = new Guid();
            public string Nome { get; set; }
        }
    }
