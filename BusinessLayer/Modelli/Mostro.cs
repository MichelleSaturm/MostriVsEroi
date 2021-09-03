namespace BusinessLayer.Modelli
{
    public class Mostro
    {
        public string NomeMostro { get; set; }
        public string Categoria { get; set; }
        public Arma Arma { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }

        public Mostro(string nomeMostro, string categoria, Arma arma, int livello, int puntiVita)
        {
            NomeMostro = nomeMostro;
            Categoria = categoria;
            Arma = arma;
            Livello = livello;
            PuntiVita = puntiVita;
        }
    }
}
