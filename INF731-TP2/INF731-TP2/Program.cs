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
            string FichierClient = "../../ListeDeClients.txt";
            List<Client> lesClients;

            lesClients = new List<Client>(GestionFichiers.loadClients(FichierClient));
            foreach (Client c in lesClients)
            {
                c.Afficher();
            }


            string FichierComptes = "../../ListeDeComptes.txt";
            List<Compte> lesComptes;

            lesComptes = new List<Compte>(GestionFichiers.loadComptes(FichierComptes));
            //lesComptes = new List<Compte>(generateComptes());
            foreach (Compte c in lesComptes)
            {
                c.Afficher();
            }


            //Banque Tangerina = new Banque("Tangerina");

            //foreach (Client c in lesClients)
            //{
            //    c.Afficher();
            //}
        }

        static List<Client> generateClients()
        {
            List<Client> lesClients = new List<Client>();
            string[] éléments;

            éléments = new string[] { "10001","LaPrairie","George"};
            lesClients.Add(new ClientIndividuel(éléments));
            éléments = new string[] { "10002", "Contant", "Suzy" };
            lesClients.Add(new ClientIndividuel(éléments));
            éléments = new string[] { "10003", "Dewi", "Marina" };
            lesClients.Add(new ClientIndividuel(éléments));
            éléments = new string[] { "10004", "Arsenault", "Valérie" };
            lesClients.Add(new ClientIndividuel(éléments));
            éléments = new string[] { "10005", "Tremblay", "Jason" };
            lesClients.Add(new ClientIndividuel(éléments));

            return lesClients;
        }

        static List<Compte> generateComptes()
        {
            List<Compte> lesComptes = new List<Compte>();
            string[] éléments;

            éléments = new string[] { "80622 - 123", "chèque", "conjoint", "80999 - 654", "001", "A", "2538,45" };
            lesComptes.Add(new CompteChèque(éléments));
            éléments = new string[] { "80999 - 654", "chèque", "conjoint", "80433 - 258", "002", "A", "3000,98" };
            lesComptes.Add(new CompteChèque(éléments));

            return lesComptes;
        }

    }
}
