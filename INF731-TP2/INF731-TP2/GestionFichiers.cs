﻿using System;
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
        private static string[] ParseCSV(string ligne)
        {
            // rajouter trim 
            string[] tableauÉléments = ligne.Split(';');
            return tableauÉléments;
        }

        /**
        * Description: Lit un fichier et génère une liste de client 
        * @param: string cheminFichier (Fichier de clients)
        * @retour: Une liste de clients
        */
        public static List<Client> loadClients(String cheminFichier)
        {
            string[] attributs;
            List<Client> listClients = new List<Client>();

            foreach (var Ligne in File.ReadLines(cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                listClients.Add(new ClientIndividuel(attributs[0].Trim(), attributs[1].Trim(), attributs[2].Trim()));
            }
            return listClients;
        }

        /**
        * Description: Lit une ligne csv et retourne les informations d'un client 
        * @param: string ligne  ()
        * @param: Banque        (Permet de référencer les objets, méthodes qui existent au niveau de Banque)
        * @retour: Compte       (Retourne un compte)
        */
        private static Compte CréerCompte(string[] tableauDesÉléments)
        {
            string[] numéroClients = new string[2];
            string typeDeCompte;
            string caractéristiqueDeCompte;
            string numéroCompte;
            char statutCompte;
            double soldeCompte;

            int indice = 0;

            numéroClients[0] = tableauDesÉléments[0];
            typeDeCompte = tableauDesÉléments[1].ToLower();
            caractéristiqueDeCompte = tableauDesÉléments[2].ToLower();

            if (caractéristiqueDeCompte == "conjoint")
            {
                numéroClients[1] = tableauDesÉléments[3];
                indice++;
            }

            switch (typeDeCompte)
            {
                case "chèque":
                    numéroCompte = tableauDesÉléments[indice + 3];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 4].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 5]);

                    return new CompteChèque(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte);

                case "épargne":
                    numéroCompte = tableauDesÉléments[indice + 3];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 4].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 5]);

                    return new CompteÉpargne(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte);

                case "flexible":
                    string modeFacturation = tableauDesÉléments[indice + 3].ToLower();
                    numéroCompte = tableauDesÉléments[indice + 4];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 5].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 6]);
                    double montantMarge = double.Parse(tableauDesÉléments[indice + 7]);
                    double soldeMarge = double.Parse(tableauDesÉléments[indice + 8]);

                    return new CompteFlexible(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte, modeFacturation, montantMarge, soldeMarge);

                default:
                    return new CompteChèque(new string[2] { "Default", "Default" }, "Default", "Default", "Default", 'E', 0);
            }
        }

        /**
        * Description: Lit un fichier et génère une liste de compte 
        * @param: string cheminFichier (Fichier de clients)
        * @retour: Une liste de comptes
        */
        public static List<Compte> loadComptes(String cheminFichier)
        {
            string[] attributs;
            List<Compte> listeComptes = new List<Compte>();

            foreach (var Ligne in File.ReadLines(cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                listeComptes.Add(CréerCompte(attributs));
            }
            return listeComptes;
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