using System;
namespace CompteBanqueNS
{
    ///<summary>
    ///Classe demo compte bancaire.
    ///</summary>
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloque = false;
        private CompteBancaire()
        { }
        public CompteBancaire(string nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }
        public string nomClient
        {
            get { return m_nomClient; }
        }
        public double Balance
        {
            get { return m_solde; }
        }
        public void Debiter(double montant)
        {
            if (m_bloque)
            {
                throw new Exception("Compte bloque");
            }
            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("Montant debite doit etre superieur ou egal au solde disponible ");
            }
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant doit etre positif ");
            }
            // Corriger ici en soustrayant le montant du solde
            m_solde -= montant;
        }
        public void Crediter(double montant)
        {
            if (m_bloque)
            {
                throw new Exception("Compte bloque");

            }
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant credite doit etre superieur a zero ");
            }
            m_solde += montant;
        }
        private void BloquerCompte()
        {
            m_bloque = true;
        }
        private void DebloquerCompte()
        {
            m_bloque = false;
        }
        public static void Main()
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);
            cb.Crediter(500000);
            cb.Debiter(400000);
            Console.WriteLine("solde disponible egal a F{0}", cb.Balance);
        }
    }
}

