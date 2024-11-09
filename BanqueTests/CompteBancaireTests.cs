using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompteBanqueNS;
using static System.Net.Mime.MediaTypeNames;

namespace BanqueTests

{
    [TestClass]
    public class CompteBancaireTests
    {

        [TestMethod]
        public void VerifierDebitCompteCorrect()
        {
            // ouvrir un compte 
            double soldeInitial = 500000;
            double montantDebit = 400000;
            double soldeAttendu = 100000;
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);
            
            compte.Debiter(montantDebit);
            
            double soldeObtenu = compte.Balance;
            Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte debite incorrectement");
        }
        // Méthode de test pour vérifier qu’un débit supérieur au solde lève une exception
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debiter_MontantSuperieurAuSolde_LeveArgumentOutOfRangeException()
        {
            
            double soldeInitial = 100.0;
            double montantADebiter = 150.0;
            CompteBancaire compte = new CompteBancaire("Test Client", soldeInitial);

            
            compte.Debiter(montantADebiter);

            
        }
        //Méthode de test pour vérifier qu’un débit négatif lève une exception
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debiter_MontantNegatif_LeveArgumentOutOfRangeException()
        {
            
            double soldeInitial = 100.0;
            double montantADebiter = -10.0;
            CompteBancaire compte = new CompteBancaire("Test Client", soldeInitial);

         
            compte.Debiter(montantADebiter);

            
        }

        [TestMethod]
        public void Debiter_MontantValide_SoldeMisAJour()
        {
           
            double soldeInitial = 100.0;
            double montantADebiter = 50.0;
            CompteBancaire compte = new CompteBancaire("Test Client", soldeInitial);
            double soldeAttendu = soldeInitial - montantADebiter;

            
            compte.Debiter(montantADebiter);

            
            Assert.AreEqual(soldeAttendu, compte.Balance, "Le solde du compte n'a pas été mis à jour correctement après le débit.");
        }
    }
}
