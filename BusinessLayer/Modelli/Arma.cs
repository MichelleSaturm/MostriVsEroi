using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Modelli
{
    public class Arma
    {
        public string NomeArma { get; set; }
        public int PuntiDanno { get; set; }

        public Arma(string nome, int punti)
        {
            NomeArma = nome;
            PuntiDanno = punti;
        }

    }
}
