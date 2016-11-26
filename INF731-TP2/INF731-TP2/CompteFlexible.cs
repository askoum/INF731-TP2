﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
///     </auteurs>
/// 
///     <summary>
///         Classe définissant les comptes de type Flexible de la banque.
///     </summary>
///     
///     <méthodes>
///         <méthode> 
///             <Nom> ParseCSV(string ligne) </Nom>
///             <Description> Lit une ligne csv et créer un Array de string </Description>
///         </méthode>
///         <méthode>
///             <Nom> loadClients(String cheminFichier) </Nom>
///             <Description> </Description>
///         </méthode>
///         <méthode>
///             <Nom>  EstDécouvert ()</Nom>
///             <Description> Retourne true si le compte est à découvert </Description>
///         </méthode>
///         <méthode>
///             <Nom> VirementMarge ()</Nom>
///             <Description> Virement d'un montant sur la marge du compte </Description>
///         </méthode>
///         <méthode>
///             <Nom> CalculerIntérêts() </Nom>
///             <Description> Calcul les intérêts à partir du solde le plus bas mensuel</Description>
///         </méthode>
///         <méthode>
///             <Nom>  Afficher () </Nom>
///             <Description>  Affiche les informations du compte </Description>
///         </méthode>
///     </méthodes>
/// </INF731-TP2>

namespace INF731_TP2
{
    #region // Déclaration des classes d'exception
    public class ModeFacturationInvalide : Exception { }
    #endregion

    public class CompteFlexible : Compte
    {
        #region // Déclaration des Attributs
		
        public static readonly string[] ModeFacturationValide = { FORFAIT, PIÈCE };

        public const double TAUX_INTÉRÊT_ANNUEL = 0.00125;
        public const double MARGE_CRÉDIT_MIN = 3000;
        public const double INTÉRÊT_CRÉDIT_ANNUEL = 7.95;
        public const double FRAIS_PIÉCE = 0.60;
        public const double FRAIS_FORFAIT_FIXE = 9;

        private double montantMarge = 3000;
        private string modeFacturation;

        #endregion


        #region // Déclaration des propriétés

        public double SoldeMarge { get; private set; }

        public double MontantMarge
        {
            get { return montantMarge; }
            private set { montantMarge = value; }
        }
        
        public double MargeDisponible
        {
            get { return MontantMarge - SoldeMarge; }
        }
        /// <summary>
        /// Peut contenir FORFAIT ou PIÈCE
        /// </summary>
        public string ModeFacturation
        {
            get { return modeFacturation; }

            set
            {
                if (ModeFacturationValide.Contains<string>(value))
                {
                    modeFacturation = value;
                }
                else
                {
                    throw new ModeFacturationInvalide();
                }
            }
        }
        
        #endregion


        #region // Déclaration des constructeurs

        /// <summary>
        /// Constructeur paramétrique
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <param name="typeDeCompte"></param>
        /// <param name="caracteristiqueDeCompte"></param>
        /// <param name="numéroCompte"></param>
        /// <param name="statutCompte"></param>
        /// <param name="soldeCompte"></param>
        /// <param name="modeFacturation"></param>
        /// <param name="montantMarge"></param>
        /// <param name="soldeMarge"></param>
        /// <base numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte></base>
        public CompteFlexible(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte,
                            string numéroCompte, char statutCompte, double soldeCompte, string modeFacturation, double montantMarge, double soldeMarge)
                    : base(numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte)
                {
            if (typeDeCompte == FLEXIBLE)
            {
                ModeFacturation = modeFacturation;
                MontantMarge = montantMarge;
                SoldeMarge = soldeMarge;                
            }
            else
            {
                throw new TypeCompteInvalideException();
            }
        }

        #endregion


        #region // Déclaration des méthodes

        /// <summary>
        /// Retirer un montant du solde ou de la marge du compte
        /// </summary>
        /// <param name="montant"></param>
        /// <returns> 
        /// <return> True si le montant a été retiré. </return>
        /// <return> False si le montant n'a pas été retiré. </return> 
        /// </returns>
        public override bool Retirer(double montant)
        {
            if (montant <= SoldeCompte)
            {
                if (base.Retirer(montant))
                    return true;
                else
                    return false;
            }
            else if (montant <= (SoldeCompte + MargeDisponible))
            {
                if (Retirer(SoldeCompte))
                {
                    SoldeMarge += (montant - SoldeCompte);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Virement sur marge du compte
        /// </summary>
        /// <param name="montant"></param>
        /// <returns>
        /// <return> True si le montant a été viré sur la marge. </return>
        /// <return> False si le montant n'a pas été viré sur la marge. </return>
        /// </returns>
        public bool VirementMarge(double montant)
        {
            if (EstActif())
            {
                if (montant <= MargeDisponible)
                {
                    if (Retirer(montant))
                    {
                        SoldeMarge += montant;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (Retirer(MontantMarge - SoldeMarge))
                    {
                        SoldeMarge += (MontantMarge - SoldeMarge);
                        return true;
                    }
                    else
                        return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// Calculer les intérêts à partir du solde le plus bas mensuel
        /// </summary>
        /// <returns></returns>
        public override double CalculerIntérêts()
        {
            return SoldePlusBas * TAUX_INTÉRÊT_ANNUEL;
        }

        
        /// <summary>
        /// Afficher les informations du compte
        /// </summary>
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine(", Mode de Facturation: " + ModeFacturation + ", Montant Marge: " + MontantMarge + ", Solde Marge: " + SoldeMarge + ", Solde Plus Bas: " + SoldePlusBas);
        }
		
        #endregion
    }
}
