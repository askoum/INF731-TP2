using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    public abstract class Client
    {

        #region // Déclaration des attributs

        private string numéroClient;

        #endregion


        #region // Déclaration des propriétés

        private string NuméroClient
        {
            get { return numéroClient; }
            set { numéroClient = value; }
        }

        #endregion


        #region // Déclaration des constructeurs de class

        public Client(string numéroClient)
        {
            NuméroClient = numéroClient;
        }

        #endregion


        #region // Déclaration des méthodes

        // Pourquoi on a besoin de AfficherClient () si on a ToString?
        /*
        * Méthode: Afficher()
        * Description: Affiche NuméroClient[EOL]
        */
        public virtual void Afficher()
        {
            Console.Write(NuméroClient + " - ");
        }

        #endregion
    }
}