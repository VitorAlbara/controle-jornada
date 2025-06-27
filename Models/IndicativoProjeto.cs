namespace controle_jornada.Models
{
    public class IndicativoProjeto
    {
        public string Nome { get; set; }
        public string Valor { get; set; }

        public static List<IndicativoProjeto> PegarIndicativosPadroes()
        {
            return new List<IndicativoProjeto>
            {
                new IndicativoProjeto { Nome = "Sustentação", Valor = "Sustentação" },
                new IndicativoProjeto { Nome = "Questor Cloud", Valor = "Questor Cloud" },
                new IndicativoProjeto { Nome = "Questor Negócio", Valor = "Questor Negócio" },
                new IndicativoProjeto { Nome = "Questor Zen 2.0", Valor = "Questor Zen 2.0" },
                new IndicativoProjeto { Nome = "Configurador Inteligente", Valor = "Configurador Inteligente" },
                new IndicativoProjeto { Nome = "Automatização dos Códigos de Ajustes", Valor = "Automatização dos Códigos de Ajustes" },
                new IndicativoProjeto { Nome = "Certificados Digitais", Valor = "Certificados Digitais" },
                new IndicativoProjeto { Nome = "Firma Simples", Valor = "Firma Simples" }
            };
        }
    }
}
