using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_jornada.Models
{
    [Table("projetos")]
    public class Projeto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Versao> Versoes { get; set; }
    }
}
