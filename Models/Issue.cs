using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_jornada.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Assunto { get; set; } = "Sem título";
        public string Descricao { get; set; } = "Sem descrição.";
        public int ProjetoId { get; set; } = 0;
        public DateOnly? DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }
        public string Tamanho { get; set; } = "N/A";
        public int VersaoFixa { get; set; } = 0;
        public string Status { get; set; } = "Desconhecido";
    }
}
