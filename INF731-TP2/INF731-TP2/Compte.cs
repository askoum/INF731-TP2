
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
        private const double MAX_RETRAIT_GA = 500;

        private string[] NuméroClients = new string[2];
        private string typeDeCompte;
        private string caractéristiqueDeCompte;
        private string numéroCompte;
        private char statutCompte;
        private double soldeCompte;




        #region // Déclaration des propriétés
        public int Indice { get; private set; }     // Les classes enfants ont besoin de connaître l'indice du tableauÉléments du constructeur

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
        public Compte(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte,
        string numéroCompte, char statutCompte, double soldeCompte)
        {
            NuméroClients = numéroClient;
            TypeDeCompte = typeDeCompte;
            CaractéristiqueDeCompte = caracteristiqueDeCompte;
            NuméroCompte = numéroCompte;
            StatutCompte = statutCompte;
            SoldeCompte = soldeCompte;
        }
        
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
                return "Numéro de compte: " + NuméroCompte + ", Numéro de Client: " + NuméroClients[0] + ", Solde du compte: " + SoldeCompte;
            }
        }


        #region // Virtual Méthodes
        /**
        * @param montant
        */
        public virtual bool Déposer(double montant)
        {
            return false; // To implement
        }

        /**
        * @param montant
        */
        public virtual bool RetirerComptoir(double montant)
        {
            return false; // To implement
        }

        /**
        * @param montant
        */
        public virtual bool RetirerGuichetAutomatique(double montant)
        {
            // Le retrait doit être un multiple de 5 modulo 0 ou (5 % 0)
            // Le retrait est d'un maximum de 500$

            return false; // To implement
        }

        /**
        * @param montant
        */
        public virtual bool RetirerChèque(double montant)
        {
            return false; // To implement
        }

        /**
        * Sera implémenter dans une interface
        * @param 
        */
        public virtual bool AjouterIntérêt()
        {
            return false; // To implement
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