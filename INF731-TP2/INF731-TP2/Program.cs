using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF731_TP2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Génération de la banque avec des comptes et clients
            Banque Tangerine = new Banque("Tangerine");

            string FichierClient = "../../ListeDeClients.txt";
            GestionFichiers.loadClients(Tangerine, FichierClient);
            foreach (Client c in Tangerine.ListeDeClients)
            {
                c.Afficher();
            }


            string FichierComptes = "../../ListeDeComptes.txt";
            GestionFichiers.loadComptes(Tangerine, FichierComptes);
            foreach (Compte c in Tangerine.ListeDeComptes)
            {
                c.Afficher();
            }


            // Test des méthodes de class
            // CompteChèque.Retirer()
        }
    }
}
