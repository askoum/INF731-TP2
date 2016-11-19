
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    public abstract class Compte
    {
        // Déclaration des Attributs

        const char CODE_ACTIF = 'A';
        const char CODE_INACTIF = 'I';

        private string[] NuméroClients = new string[2];
        private string typeDeCompte;
        private string caractéristiqueDeCompte;
        private string numéroCompte;
        private char statutCompte;
        private double soldeCompte;


        #region // Déclaration des propriétés

        public string this[int indice]
        {
            get { return NuméroClients[indice]; }

            private set                              // Setter is private, Cannot be changed by child once created
            {
                NuméroClients[indice] = value;
            }
        }

        public string TypeDeCompte
        {
            get { return typeDeCompte; }

            private set                              // Setter is private, Cannot be changed by child once created
            {
                typeDeCompte = value;
            }
        }

        public string CaractéristiqueDeCompte
        {
            get
            {
                return caractéristiqueDeCompte;
            }
            private set                             // Setter is private, Cannot be changed by child once created
            {
                caractéristiqueDeCompte = value;
            }
        }

        public string NuméroCompte
        {
            get { return numéroCompte; }

            private set                             // Setter is private, Cannot be changed by child once created
            {
                numéroCompte = value;
            }
        }

        public char StatutCompte
        {
            get
            {
                return statutCompte;
            }
            protected set                           // Setter is protected, Can be changed by child once created
            {
                statutCompte = value;
            }
        }

        public double SoldeCompte
        {
            get { return soldeCompte; }

            protected set                           // Setter is protected, Can be changed by child once created
            {
                soldeCompte = value;
            }
        }

        #endregion


        #region // Déclaration des constructeurs

        /**
         * Constructeur paramétrique
         *
         * @param numéroDeCompte
         * @param ListeDeClient
         * @param typeDeCompte
         * @param caracteristiqueDeCompte
         * @param statutCompte
         * @param soldeCompte
         */
        public Compte(string[] tableauDesÉléments)
        {
            // Liste des éléments propres à tous les types de compte
            int indice = 0;
            
            NuméroClients[0] = tableauDesÉléments[0];
            TypeDeCompte = tableauDesÉléments[1];
            CaractéristiqueDeCompte = tableauDesÉléments[2];

            if (CaractéristiqueDeCompte == "conjoint")
            {
                NuméroClients[1] = tableauDesÉléments[3];
                indice++;
            }
            
            NuméroCompte = tableauDesÉléments[indice + 3];
            StatutCompte = char.Parse(tableauDesÉléments[indice + 4]);
            SoldeCompte = double.Parse(tableauDesÉléments[indice + 5]);
        }

        //switch (typeDeCompte)
        //{
        //    case "Chèque":
        //        numéroCompte = tableauDesÉléments[i + 3];
        //        statutCompte = char.Parse(tableauDesÉléments[i + 4]);
        //        soldeCompte = double.Parse(tableauDesÉléments[i + 5]);
        //        break;
        //    case "flexible":
        //        modeFacturation = tableauDesÉléments[i + 3];
        //        numéroCompte = tableauDesÉléments[i + 4];
        //        statutCompte = char.Parse(tableauDesÉléments[i + 5]);
        //        soldeCompte = double.Parse(tableauDesÉléments[i + 6]);
        //        montantMarge = double.Parse(tableauDesÉléments[i + 7]);
        //        soldeMarge = double.Parse(tableauDesÉléments[i + 8]);
        //        break;
        //    case "saving":
        //        numéroCompte = tableauDesÉléments[i + 3];
        //        statutCompte = char.Parse(tableauDesÉléments[i + 4]);
        //        soldeCompte = double.Parse(tableauDesÉléments[i + 5]);
        //        break;
        //}
        #endregion


        #region // Déclaration des méthodes

        /**
        * 
        */
        public bool RendreActif()
        {
            if (StatutCompte == CODE_ACTIF)
                return false;
            else
            {
                StatutCompte = CODE_ACTIF;
                return true;
            }
        }

        /**
        * 
        */
        public bool RendreInactif()
        {
            if (StatutCompte == CODE_INACTIF)
                return false;
            else
            {
                StatutCompte = CODE_INACTIF;
                return true;
            }
        }

        /**
        * @return bool (True=Actif, False=Inactif)
        */
        public bool EstActif()
        {
            bool estActif = false;

            if (StatutCompte == CODE_ACTIF)
            {
                estActif = true;
            }
            return estActif;
        }

        public virtual void Afficher()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            if (CaractéristiqueDeCompte == "conjoint")
            {
                return "Numéro de compte: " + NuméroCompte + ", Numéro de Client1: " + NuméroClients[0] + ", Numéro de Client2: " + NuméroClients[1] +", Solde du compte: " + SoldeCompte;
            }
            else
            {
                return "Numéro de compte: " + NuméroCompte + ", Numéro de Client: " + NuméroClients + ", Solde du compte: " + SoldeCompte;
            }
        }


        #region // Virtual Méthodes
        /**
        * @param montant
        */
        public virtual bool Déposer(double montant)
        {
            return true; // To implement
        }

        /**
        * @param montant
        */
        public virtual bool Retirer(double montant, char typeTransaction)
        {
            return true; // To implement
        }

        /**
        * Sera implémenter dans une interface
        * @param 
        */
        public virtual bool AjouterIntérêt()
        {
            return true; // To implement
        }

        /**
        * 
        */
        public virtual double AfficherSolde()
        {
            return SoldeCompte; // To implement
        }

        #endregion

        #endregion
    }
}