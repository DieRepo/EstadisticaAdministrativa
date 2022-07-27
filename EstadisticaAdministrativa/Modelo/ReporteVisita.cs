namespace EstadisticaAdministrativa.Modelo
{
    public class ReporteVisita
    {
        private string nombreTipo;
        private string nH;
        private string nM;
        private string p;
        private string m;
        private string dH;
        private string dM;

        public string NombreTipo { get => nombreTipo; set => nombreTipo = value; }
        public string NH { get => nH; set => nH = value; }
        public string NM { get => nM; set => nM = value; }
        public string P { get => p; set => p = value; }
        public string M { get => m; set => m = value; }
        public string DH { get => dH; set => dH = value; }
        public string DM { get => dM; set => dM = value; }
    }
}