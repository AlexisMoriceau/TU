using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCommande.controleur;
using GestionCommande.model;

namespace GestionCommande.Tests
{
    [TestClass]
    class TestProduit
    {
        [TestMethod]
        public void AjoutProduitOK()
        {
            Controleur controler = new CommandeControleur();
            controler.CreerProduit("Tournevis", 12);
            Assert.AreEqual("Tournevis", controler.GetProduits().Last().Designation);
            Assert.AreEqual(12, controler.GetProduits().Last().Prix);
        }

        [TestMethod]
        public void AjoutClientOK()
        {
            Controleur control = new CommandeControleur();
            control.CreerClient("Moriceau", "Alexis", "alexis.moriceau@epsi.fr");
            Assert.AreEqual("Moriceau", control.GetClients().Last().Nom);
            Assert.AreEqual("Alexis", control.GetClients().Last().Prenom);
            Assert.AreEqual("alexis.moriceau@epsi.fr", control.GetClients().Last().Mail);
        }

        [TestMethod]
        public void AjoutCommandeOK()
        {
            Controleur control = new CommandeControleur();
            Client Clt = new Client();
            Clt.Nom = "Moriceau";
            Clt.Prenom = "Alexis";
            Clt.Mail = "alexis.moriceau@epsi.fr";
            List<LigneCommande> lsc = new List<LigneCommande>();
            lsc.Add(new LigneCommande() { Produit = control.GetProduits().First(), Quantite = 500 });
            control.CreerCommande(Clt, lsc);

            Assert.AreEqual(Clt, control.GetCommandes().Last().Client);
            Assert.AreEqual(lsc, control.GetCommandes().Last().LignesCommande);
        }
    }
}
