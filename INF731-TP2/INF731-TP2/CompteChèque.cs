using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INF731_TP2
{
	public class CompteChèque : Compte
	{
        #region // Déclaration des attributs

        private const double FRAIS_PAR_CHÈQUE = 0.50;
		private const double MINIMUM_SOLDE = 1000;
		private const double TAUX_INTÉRÊT_ANNUEL = 0.5;
		private double soldePlusBas;
		private double leTauxIntérêtAnnuel;

        #endregion


        #region // Déclaration des propriétés

        public double SoldePlusBas 
		{
			get 
			{ 
				return soldePlusBas;
			}

	        private set
			{
				soldePlusBas=value;
			}
		}

		public double LeTauxIntérêtAnnuel
			{
				get 
				{ 
					return leTauxIntérêtAnnuel;
				}
			
				private set
				{
				   leTauxIntérêtAnnuel=value;
				}
			}

        #endregion


        #region // Déclaration des constructeurs

        // Renvoit tout les paramètres au parent
        public CompteChèque(string[] tableauDesÉléments) 
            : base(tableauDesÉléments)
        {
            //if (base.tableauDesÉléments[1] != "Chèque")
            //    throw new Exception();                      /// Create a more suitable exception
        }

        #endregion


        #region // Déclaration des méthodes

        /*
        * Méthode: Déposer
        * @param double montant
        */
        public override bool Déposer(double montant)
        {
            base.SoldeCompte += montant;
            Console.WriteLine("Opération bien effectuée");
            return true;
        }

        /*
         * Méthode: Retirer
         * @param double montant
         */
        public override bool Retirer(double montant, char typeTransaction)
        {
	        double frais;
			if (SoldeCompte >= montant)
		        {
			        SoldeCompte -= montant;
			        Console.WriteLine("Opération bien effectuée");
                    return true;
		        }
		        else
		        {
			        // Throw new exception
			        Console.WriteLine("Solde insuffisant");
                    return false;
		        }

	        if (typeTransaction == 'C')
	        {
		        if (SoldeCompte < MINIMUM_SOLDE)
		        {
			        frais = montant + FRAIS_PAR_CHÈQUE;
			        SoldeCompte -= frais;
                    return true;
		        }
	        }
        }

        /*
        * Méthode: AjouterIntérêt
        * @param 
        */
        public override bool AjouterIntérêt()
        {
            return true; // To implement
        }
            
        /*
         * Méthode: AjouterIntérêtsAnnuel
         * @param 
         */
        public bool AjouterIntérêtsAnnuel()
        {
	        double intérêts = soldePlusBas * TAUX_INTÉRÊT_ANNUEL;
	        soldePlusBas += intérêts;
            return true;
        }

        /*
         * Méthode: ToString
         * @param double montant
         */
        public override double AfficherSolde()
        {
            return SoldeCompte;
        }

        /*
        * Méthode: Afficher()
        * @param 
        */
        public override void Afficher()
        {
            base.Afficher();
        }

        /*
        * Méthode: ToString
        * @param
        */


        
        #endregion
    }
}