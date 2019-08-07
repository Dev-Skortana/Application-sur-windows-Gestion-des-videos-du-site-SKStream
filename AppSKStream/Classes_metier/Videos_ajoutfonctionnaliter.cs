using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using AppSKStream.Services.Interfaces;
using AppSKStream.Helpers;

namespace AppSKStream.Classes_metier
{
    partial class Videos
    {
        private readonly Iservices_database<Videos> data_service_video;
        public Videos() {

        }

        public Videos(Iservices_database<Videos> service_video)
        {
            this.data_service_video = service_video;
        }

        public Videos(String titre, String acteure, String genre, String pays, TimeSpan duree, String creer_par, String categorie, String Description,String filefullname)
        {
            this.Titre = titre; this.Acteure = formatage_listeelement(acteure); this.Genre = formatage_listeelement(genre); this.Pays = formatage_listeelement(pays); this.Duree=duree; this.Creer_par = formatage_listeelement(creer_par); this.Categorie = categorie; this.Description = Description;this.Filefullname =Application.StartupPath + @"\Images_fichesvideos\" + filefullname.Substring(filefullname.LastIndexOf(@"/")+1);
        }

        public TimeSpan formatage_duree(String duree)
        {
            String var_duree = duree.ToString();
            var_duree = var_duree.IndexOf("h") > -1 ? var_duree.Substring(0, var_duree.IndexOf("h")) + "" + var_duree.Substring(var_duree.IndexOf("h")) : "0h" + var_duree.Substring(0);
            var_duree = var_duree.IndexOf("m") > -1 ? var_duree.Substring(0, var_duree.IndexOf("m") + 1) : var_duree.Substring(0, var_duree.IndexOf("h") + 1) + "0m";
            var_duree += "0";
            var_duree = Methodes_utilitaire.rectification_resultat(var_duree, new String[] { "h", "m", " " }, new String[] { ":", ":", "" });
            String[] parties_temps = var_duree.Split(':');
            return new TimeSpan(int.Parse(parties_temps[0]), int.Parse(parties_temps[1]), int.Parse(parties_temps[2]));
        }

        protected String formatage_listeelement(String donnees)
        {
            donnees = Methodes_utilitaire.rectification_resultat(donnees,new String[]{"\n","\r","</a>",">"},new String[]{"","","",">" + Environment.NewLine});
            donnees = Regex.Replace(donnees, "<a href=\".+\"( title=\".+\")*>" + Environment.NewLine, "");
            donnees = donnees.Replace(", ",",");
            String result = donnees;
            return result;
        }
        public override string ToString()
        {
            return String.Format("Cette video a pour titre {0} elle dure {1} elle a comme acteure {2} elle a été produite par {3} ses pays de production sont {4} elle entre dans ces genres {5} cette fait partie de la catégorie {6} et enfin son synopsi {7} ",Methodes_utilitaire.affectation_donneesformater(this.Titre),Methodes_utilitaire.affectation_donneesformater(this.Duree),Methodes_utilitaire.affectation_donneesformater(this.Acteure),Methodes_utilitaire.affectation_donneesformater(this.Creer_par),Methodes_utilitaire.affectation_donneesformater(this.Pays),Methodes_utilitaire.affectation_donneesformater(this.Genre),Methodes_utilitaire.affectation_donneesformater(this.Categorie),Methodes_utilitaire.affectation_donneesformater(this.Description));
        }

        public async Task<Videos> video_selon_criteres(Dictionary<String,String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_video.getelement(dictionnaire_critere,operateure);
        }

        public async Task<List<Videos>> liste_videos_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_video.getelements(dictionnaire_critere,operateure);
        }

        public async Task<Boolean> update(Dictionary<string, string> dictionnaire_modification, Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_video.update(dictionnaire_modification,dictionnaire_critere,operateure);
        }

        public async Task<Boolean> delete(Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_video.delete(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> insert()
        {
            return await data_service_video.insert(null,false);
        }
    }
}
