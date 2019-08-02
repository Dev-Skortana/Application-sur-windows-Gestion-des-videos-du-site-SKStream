using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSKStream
{
    partial class Sommaire_series
    {
        protected const String nom_domaine_siteskstream = "http://www.skstream.bz/";
        public Sommaire_series() {

        }
        public Sommaire_series(String titre,int saison, int episode, String lien)
        {
            this.Titre=titre; this.Saison = saison; this.Episode = episode; this.Lien = nom_domaine_siteskstream + "" + lien;
        }

        public override string ToString()
        {
            return String.Format("Saison {0} episode {1} le lien qui permet de y acceder [{2}] ",Methodes_utilitaire.affectation_donneesformater(this.Saison), Methodes_utilitaire.affectation_donneesformater(this.Episode), Methodes_utilitaire.affectation_donneesformater(this.Lien));
        }
    }
}
