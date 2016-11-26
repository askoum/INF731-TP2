﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
///         <auteur> Bassir Diallo <email> albassir02@gmail.com </email></auteur>
///         <auteur> Sory DIANE <email> sorydian2@gmail.com </email></auteur>
///         <auteur> Francoise Askoum Koumtingue <email> askoumk@gmail.com </email></auteur>
///     </auteurs>
/// 
///     <summary>
///         Classe définissant les comptes de type Épargne de la banque.
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
///             <Nom>DéposerAuGuichetAutomatique() </Nom>
///             <Description> Transaction non supporter par compte Épargne
///                           lorsqu'on veut faire un depot au guicher automatique 
///                           elle lance  une exception
///             </Description>
///         </méthode>
///         <méthode>
///             <Nom>RetirerGuichetAutomatique () </Nom>
///             <Description> 	Transaction non supporter par compte Épargne
///                             lorsqu'on  veut faire un retrait au guichet 
///                             automatique ,elle lance une exception
///             </Description>
///         </méthode>
///         <méthode>
///             <Nom> RetirerChèque () </Nom>
///             <Description>Transaction non supporter par compte Épargne 
///                          lorsqu'on veut faire un retrait par cheque
///                          elle lance une exception 
///             </Description>
///         </méthode>
///         <méthode>
///             <Nom>CalculerIntérêts() </Nom>
///             <Description> Calculer l'intérêt basé sur le solde moyen du compte,à appliquer sur le compte  </Description>
///         </méthode>
///         <méthode>
///             <Nom> Afficher () </Nom>
///             <Description>	affiche les informatins du compte </Description>
///         </méthode>
///     </méthodes>
/// </INF731-TP2>

namespace INF731_TP2
{
    #region // Declaration des exceptions
    #endregion

    public class CompteÉpargne : Compte
    {
        #region // Déclaration des attributs 

        public const double TAUX_INTÉRÊT_ANNUEL = 0.0225;
        private double soldeMoyen;

        #endregion


        #region // Déclaration des propriétés
        public double SoldeMoyen { get; private set; }  // Doit être calculer à partir des Transactions
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
        /// <base numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte></base>
        public CompteÉpargne(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte, string numéroCompte, char statutCompte, double soldeCompte)
          : base(numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte)
        {
            if (typeDeCompte != ÉPARGNE)
            {
                throw new TypeCompteInvalideException();
            }
        }

        #endregion


        #region // Déclaration des Methodes

        /// <summary>
        /// Transaction non supporter par compte Épargne
        /// <transaction> DGA </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns> TransactionTypeDeCompteInvalideException </returns>
        public override bool DéposerAuGuichetAutomatique(double montant)
        {
            throw new TransactionTypeDeCompteInvalideException();
        }

        /// <summary>
        /// Transaction non supporter par compte Épargne
        /// <transaction> RGA </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns> TransactionTypeDeCompteInvalideException </returns>
        public override bool RetirerGuichetAutomatique(double montant)
        {
            throw new TransactionTypeDeCompteInvalideException();
        }

        /// <summary>
        /// Transaction non supporter par compte Épargne
        /// <transaction> C </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns> TransactionTypeDeCompteInvalideException </returns>
        public override bool RetirerChèque(double montant)
        {
            throw new TransactionTypeDeCompteInvalideException();
        }

        /// <summary>
        /// Calculer l'intérêt basé sur le solde moyen du compte
        /// </summary>
        /// <returns> Intérêts à appliquer sur le compte. </returns>
        public override double CalculerIntérêts()
        {
            return SoldeMoyen * TAUX_INTÉRÊT_ANNUEL;
        }

        /// <summary>
        /// Afficher les informations de compte
        /// </summary>
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine();
        }

        #endregion
    }
}