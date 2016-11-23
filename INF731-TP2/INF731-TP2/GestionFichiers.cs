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
    #region // Déclaration des classes d'exception
    public class listeClientsVide : Exception { }
    public class listeComptesVide : Exception { }
    #endregion

    public static class GestionFichiers
    {
        #region Déclaration des attributs
        const string CHEMIN_SORTIE = "../../";
        #endregion


        #region Déclaration des propriétés
        #endregion


        #region Déclaration des méthodes
      
        /// <summary>
        /// Lit une ligne csv et retourne les informations d'un client(numéroClient;Nom;Prénom)
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns></returns>
        private static string[] ParseCSV(string ligne)
        {
            // rajouter trim 
            string[] tableauÉléments = ligne.Split(';');
            return tableauÉléments;
        }
   
        /// <summary>
        /// Lit un fichier et génère une liste de client 
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public static List<Client> loadClients(String cheminFichier)
        {
            string[] attributs;
            List<Client> listeClients = new List<Client>();

            foreach (var Ligne in File.ReadLines(cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                listeClients.Add(new ClientIndividuel(attributs[0].Trim(), attributs[1].Trim(), attributs[2].Trim()));
            }

            if (listeClients.Count == 0)
            {
                throw new listeClientsVide();
            }
            else
            {
                return listeClients;
            }   
        }
   
        /// <summary>
        /// Lit une ligne csv et retourne les informations d'un client 
        /// </summary>
        /// <param name="tableauDesÉléments"></param>
        /// <returns></returns>
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

        
        /// <summary>
        /// Lit un fichier et génère une liste de compte 
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public static List<Compte> loadComptes(String cheminFichier)
        {
            string[] attributs;
            List<Compte> listeComptes = new List<Compte>();

            foreach (var Ligne in File.ReadLines(cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                listeComptes.Add(CréerCompte(attributs));
            }

            if (listeComptes.Count == 0)
            {
                throw new listeComptesVide();
            }
            else
            {
                return listeComptes;
            }
        }


       /// <summary>
       /// Lire le fichier de transaction
       /// </summary>
       /// <param name="cheminFichier"></param>
        static void LireFichierTransaction(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

       /// <summary>
       /// Ecrire le journal de transaction
       /// </summary>
       /// <param name="cheminFichier"></param>
        static void ÉcrireJournalTransaction(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

       /// <summary>
       /// Ecrire le journal de Client
       /// </summary>
       /// <param name="cheminFichier"></param>
        static void EcrireJournalClient(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

      /// <summary>
      /// Ecrire dans le journal de compte
      /// </summary>
      /// <param name="cheminFichier"></param>
        static void EcrireJournalCompte(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }
        #endregion
    }
}
 