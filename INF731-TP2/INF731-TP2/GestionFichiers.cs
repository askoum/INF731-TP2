using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    public static class GestionFichiers
    {
        #region Déclaration des attributs
        const string CHEMIN_SORTIE = "../../";
        #endregion


        #region Déclaration des propriétés
        #endregion


        #region Déclaration des méthodes
        
        /**
        * Description: Lit une ligne csv et retourne les informations d'un client 
        * @param: string ligne (numéroClient;Nom;Prénom)
        * @retour: string[]{numéroClient,Nom,Prénom}
        */
        private static string[] ParseClientString(string ligne)
        {
            string[] client = ligne.Split(';');
            return client;
        }

        /**
        * Description: Lit un fichier et génère une liste de client 
        * @param: string cheminFichier (Fichier de clients)
        * @retour: Une liste de clients
        */
        public static List<ClientIndividuel> loadClients(String cheminFichier)
        {
            // Le cheminFichier est un paramètre qui contient les deux informations ci-dessous.
            //const string CHEMIN_SORTIE = "../../";
            //const string nomFichier = "listeClients.txt";
            List<ClientIndividuel> mesClients = new List<ClientIndividuel>();

            foreach (var Ligne in File.ReadLines(cheminFichier))
                mesClients.Add(new ClientIndividuel(ParseClientString(Ligne)));  

            return mesClients;
        }

        /**
        * Description: Lit une ligne csv et retourne les informations d'un client 
        * @param: string ligne  ()
        * @param: Banque        (Permet de référencer les objets, méthodes qui existent au niveau de Banque)
        * @retour: Compte       (Retourne un compte)
        */
        private static Compte ParseCompteString(string ligne)
        {
            Compte compte;
            string typeDeCompte;
            string[] tableauDesÉléments = ligne.Split(';');

            typeDeCompte = tableauDesÉléments[1];

            switch (typeDeCompte)
            {
                case "Chèque":
                    return compte = new CompteChèque(tableauDesÉléments);
                    break;
                    //case "Épargne":
                    //    return compte = new CompteSaving(tableauDesÉléments);
                    //    break;
                    //case "Flexible":
                    //    return compte = new CompteFlexible(tableauDesÉléments);
                    //    break;
            }
            return compte = new CompteChèque(tableauDesÉléments);
        }

        /**
        * Description: Lit un fichier et génère une liste de compte 
        * @param: string cheminFichier (Fichier de clients)
        * @retour: Une liste de comptes
        */
        public static List<Compte> loadComptes(String cheminFichier)
        {
            List<Compte> mesComptes = new List<Compte>();

            foreach (var Ligne in File.ReadLines(cheminFichier))
                mesComptes.Add(ParseCompteString(Ligne));

            return mesComptes;
        }


        /**
         * 
         */
        static void LireFichierTransaction()
        {
            // TODO implement here
        }

        /**
         * 
         */
        static void ÉcrireJournalTransaction()
        {
            // TODO implement here
        }

        /**
         * 
         */
        static void EcrireJournalClient()
        {
            // TODO implement here
        }

        /**
         * 
         */
        static void EcrireJournalCompte()
        {
            // TODO implement here
        }
        #endregion
    }
}