
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    public class ClientIndividuel : Client
    {
        // Déclaration des attributs
        private string nomClient;
        private string prénomClient;


        // Déclaration des propriétés

        private string NomClient
        {
            get
            {
                return nomClient;
            }
            set
            {
                nomClient = value;
            }
        }

        private string PrénomClient
        {
            get
            {
                return prénomClient;
            }
            set
            {
                prénomClient = value;
            }
        }


        // Déclaration des constructeurs de class

        public ClientIndividuel(string[] client)
            : base(client[0])
        {
            NomClient = client[1];
            PrénomClient = client[2];
        }


        // Déclaration des méthodes

        // J'essaye d'implémenter une méthode Afficher utilisant le ToString pour qu'on puisse utiliser la méthode Afficher et avoir la possibilité référer directement            à l'objet pour afficher ses Attributs. (Olivier)
        /*
        * Méthode: Afficher()
        * Description: Affiche NuméroClient[EOL] Nom, Prénom
        */
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return NomClient + ", " + PrénomClient;
        }
    }
}