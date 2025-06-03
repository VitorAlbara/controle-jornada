namespace controle_jornada.Enums
{
    public enum TamanhoE
    {
        P,
        M,
        G,
        N,
    }

    public static class TamanhoEnum
    {
        public static TamanhoE PegarTamanho(string tamanho)
        {
            return tamanho switch
            {
                "P" => TamanhoE.P,
                "M" => TamanhoE.M,
                "G" => TamanhoE.G,
                _   => TamanhoE.N,
            };
        }
    }
}
