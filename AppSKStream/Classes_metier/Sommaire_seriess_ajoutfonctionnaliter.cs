using AppSKStream.Helpers;
using System;

namespace AppSKStream.Classes_metier
{
    partial class Sommaire_series
    {
        public Sommaire_series() {

        }
        public Sommaire_series(String titre,int saison, int episode, String lien)
        {
            this.Titre=titre; this.Saison = saison; this.Episode = episode; this.Lien = Methodes_utilitaire.nom_domaine + "" + lien;
        }

        public override string ToString()
        {
            return String.Format("Saison {0} episode {1} le lien qui permet de y acceder [{2}] ",Methodes_utilitaire.affectation_donneesformater(this.Saison), Methodes_utilitaire.affectation_donneesformater(this.Episode), Methodes_utilitaire.affectation_donneesformater(this.Lien));
        }
    }
}
