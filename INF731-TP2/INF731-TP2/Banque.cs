
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

///**
// * 
// */
//namespace INF731_TP2
//{
//    public class Banque
//    {
//        #region // Déclaration des attributs

//        private static string nomBanque;
//        List<Client> ListeDeClients { get; set; } // Propriété automatique
//        List<Compte> ListeDeComptes { get; set; } // Propriété automatique

//        #endregion


//        #region // Déclaration des propriétés

//        public string NomBanque
//        {
//            get { return nomBanque; }
//            private set { nomBanque = value; }
//        }

//        public Client this[int indice]
//        {
//            get { return ListeDeClients[indice]; }
//            private set { ListeDeClients[indice] = value; }
//        }

//        public Compte this[int indice]
//        {
//            get { return ListeDeComptes[indice]; }
//            private set { ListeDeComptes[indice] = value; }
//        }

//        #endregion


//        #region // Déclaration des constructeurs de class

//        public Banque(string nomBanque, string fichierClient, string fichierCompte)
//        {
//            NomBanque = nomBanque;
//            List<Client> ListeDeClients = new List<Client>(GestionFichiers.loadClients(fichierClient));
//            List<Compte> ListeDeComptes = new List<Compte>(GestionFichiers.loadComptes(fichierCompte));
//        }

//        #endregion


//        #region // Déclaration des méthodes

//        /**
//         * 
//         */
//        //public void CréerClient(string numéroClient, string nom, string prénom)
//        //{
//        //    ListeDeClients.Add(new ClientIndividuel("10001", "LaPrairie", "George"));
//        //}

//        /**
//         * 
//         */
//        public void CréerCompte()
//        {
//            // TODO implement here
//        }

//        /**
//         * 
//         */
//        public void FermerCompte()
//        {
//            // TODO implement here
//        }

//        // Retourner un clien en fonction de son numéro de client
//        public Client TrouverClient(string numéroClient)
//        {
//            return ListeClients.Find(client => client.NuméroClient == numéroClient);

//        }

//        #endregion
//    }
//}