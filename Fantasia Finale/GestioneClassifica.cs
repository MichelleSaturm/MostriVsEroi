using BusinessLayer.Modelli;
using Services;
using System;
using System.Collections.Generic;

namespace Fantasia_Finale
{
    class GestioneClassifica
    {
        //CLASSIFICA GLOBALE (TOP 10)
        internal static void ClassificaGlobale()
        {
            Console.Clear();
            Console.WriteLine("==== CLASSIFICA GLOBALE (TOP 10) ====");
            Console.WriteLine();

            Dictionary<Eroe, string> classifica = EroeServices.RecuperaClassifica();

            Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-20}{4,-5}{5,-5}{6,-5}", "N°", "Username", "Nome Eroe", "Classe", "LV", "HP", "EXP");
            Console.WriteLine(new String('-', 80));
            int count = 1;
            foreach (var c in classifica)
            {
                Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-20}{4,-5}{5,-5}{6,-5}", count, c.Value, c.Key.NomeEroe.ToUpper(), c.Key.Categoria, c.Key.Livello, c.Key.PuntiVita, c.Key.PuntiAccumulati); ;
                count++;
            }
            Console.WriteLine(new String('-', 80));
            Console.WriteLine();
            Console.WriteLine("Premi un tasto per tornare al menù.");
            Console.ReadLine();
        }
    }
}
