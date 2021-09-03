namespace BusinessLayer.Modelli
{
    public class Eroe
    {
        public string NomeEroe { get; set; }
        public string Categoria { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public int PuntiAccumulati { get; set; }
        public Arma Arma { get; set; }

        public Eroe()
        {

        }
        public Eroe(string nomeEroe, string categoria, int livello, Arma arma, int puntiVita, int puntiAccumulati)
        {
            NomeEroe = nomeEroe;
            Categoria = categoria;
            Livello = livello;
            PuntiVita = puntiVita;
            PuntiAccumulati = puntiAccumulati;
            Arma = arma;
        }
        public Eroe(string nomeEroe, string categoria, int livello, int puntiVita, int puntiAccumulati)
        {
            NomeEroe = nomeEroe;
            Categoria = categoria;
            Livello = livello;
            PuntiVita = puntiVita;
            PuntiAccumulati = puntiAccumulati;

        }
    }
}
