//// Entry point name must be "Solution"
//using System;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

///**
// * 
// */
//namespace INF731_TP2
//{
//    public class CompteFlexible : Compte
//    {
//        // Déclaration des Attributs

//        private const double TAUX_INTÉRÊT_ANNUEL = 1.25;
//        private const double MARGE_CRÉDIT_MIN = 3000;
//        private const double INTÉRÊT_CRÉDIT_ANNUEL = 7.95;
//        private const double FRAIS_PIÉCE = 0.60;
//        private const double FRAIS_FORFAIT_FIXE = 9;

//        private double montantMarge = 3000;
//        private double soldeMarge;
//        private string modeFacturation;
//        private double soldePlusBas;


//        // Déclaration des propriétés

//        public double MontantMarge
//        {
//            get { return montantMarge; }
//            set { montantMarge = value; }
//        }

//        public double SoldeMarge
//        {
//            get { return soldeMarge; }
//            set { soldeMarge = value; }
//        }

//        public string ModeFacturation
//        {
//            get { return modeFacturation; }
//            set { modeFacturation = value; }
//        }

//        public double SoldePlusBas
//        {
//            get { return soldePlusBas; }
//            set { soldePlusBas = value; }
//        }


//        // Déclaration des constructeurs

//        /**
//         * Constructeur paramétrique
//         *
//         * @param numéroDeCompte
//         * @param ListeDeClient
//         * @param typeDeCompte
//         * @param caracteristiqueDeCompte
//         * @param statutCompte
//         * @param soldeCompte
//         * @param montantMarge
//         * @param soldeMarge
//         * @param modeFacturation
//         * @param soldePlusBas
//         */

//        public CompteFlexible(string[] tableauDesÉléments) 
//            : base(tableauDesÉléments)
//        {
//            MontantMarge = double.Parse(tableauDesÉléments[base.Indice + 7]);
//            SoldeMarge = double.Parse(tableauDesÉléments[base.Indice + 8]);
//            double montantMarge; double soldeMarge; string modeFacturation;
            
//        }


//        // Déclaration des méthodes

//        /**
//         * Description: 
//         * @param montant
//         * @return 
//         */

//        solde = 1000;
//        marge = 3000;
//        retrait = 1500;
        
//        retrait - solde = 500;
//        marge - retrait = 2500 sur 3000;
        
//        Si soldeMarge<montantMarge Alors, SoldeCompte == 0


//        public double montantdécouvert(double montantRetrait, double montantDisponible)
//        {
//            double montantMarge;

//            if (montantRetrait > montantDisponible)
//            {
//                montantMarge = Abs(montantDisponible - montantRetrait);
//            }
//            return montantMarge;
//        }

//        public void ajouterSolde(double soldeMarge, double decouvert)
//        {

//        }
//        public override bool Retirer(double retrait)
//        {




//            retrait
//            montantMarge
//            montantdécouvert










//            montantDisponible = SoldeCompte


//            if (soldeCompte >= montant)
//            {
//                soldeCompte -= montant;
//                return true;
//            }
//            else if (soldeMarge < montantMarge && (montantMarge - soldeMarge) <= montant)
//            {
//                montantDisponible = montantMarge - soldeMarge
//                retrait(montantRetrait, montantDisponible)


//                soldeMarge -= montant;
//                return true;
//            }
//            else (soldeMarge -
//            {
//                soldeMarge -= montant;
//            }
//            else if (solde <
//            {
//            }
//        }

//        /**
//         * Description: 
//         * @param montant
//         * @return 
//         */

//        public override bool Déposer(double montant)
//        {

//            if (soldeCompte >= montant)
//            {
//                soldeCompte += montant;
//                return true;
//            }
//            else
//                return false;
//        }

//        public void AjouterIntérêtsAnnuel()
//        {
//            double intérêts = soldePlusBas * TAUX_INTÉRÊT_ANNUEL;
//            soldePlusBas += intérêts;
//        }
//    }
//}