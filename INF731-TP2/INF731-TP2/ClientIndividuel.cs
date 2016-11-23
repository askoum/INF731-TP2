
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
        #region // Déclaration des attributs

        /// <summary>
        /// Declaration des differents attributs
        /// </summary>
        public string NomClient { get; private set; }
        public string PrénomClient { get; private set; }
        #endregion


        #region // Déclaration des propriétés
        #endregion


        #region // Déclaration des constructeurs de class

        /// <summary>
        /// Declaration du constructeur de la classe 
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <param name="nom"></param>
        /// <param name="prénom"></param>
        
        public ClientIndividuel(string numéroClient, string nom, string prénom)
            : base(numéroClient)
        {
            NomClient = nom;
            PrénomClient = prénom;
        }

        #endregion


        #region // Déclaration des méthodes
     
        /// <summary>
        /// Afficher les informations du client a savoir: le numero,le nom et prenom du client
        /// </summary>
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine(NomClient + ", " + PrénomClient);
        }

        #endregion
    }
}