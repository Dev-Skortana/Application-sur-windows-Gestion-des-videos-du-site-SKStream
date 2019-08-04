using AppSKStream.Helpers;
using AppSKStream.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSKStream.Classes_metier
{
    partial class Video_serie
    {
        private readonly Iservices_database<Video_serie> data_service_videoserie;
        private const String requetesql_videoserie = "select VideosSet_Video_serie.titre,acteure,genre,pays,duree,creer_par,categorie,description_film as description,filefullname,NBsaison,NBepisode,Annee_lancement from VideosSet inner join VideosSet_Video_serie on VideosSet.titre=VideosSet_Video_serie.titre ";

        public Video_serie() {

        }

        public Video_serie(Iservices_database<Video_serie> data_service) {
            this.data_service_videoserie = data_service;
        }
        public Video_serie(String titre, String acteure, String genre, String pays, TimeSpan duree, String creer_par, String categorie, String description,String filefullname, int nbsaison, int nbepisode, int annelancement) : base(titre, acteure, genre, pays, duree, creer_par, categorie, description,filefullname)
        {
            this.NBsaison = nbsaison; this.NBepisode = nbepisode; this.Annee_lancement = annelancement;
        }

        protected String recuperationliste_detailseries(List<Detail_series> liste) {
            String resultat="";
            int i = 1;
            foreach (Detail_series item in liste)
            {
                resultat += "N" + i + "> " + item.ToString();
                i += 1;
            }
            return resultat;
        }
        protected String recuperationliste_detailanimer(List<Detail_animer> liste)
        {
            String resultat = "";
            int i = 1;
            foreach (Detail_animer item in liste)
            {
                resultat += "N" + i + "> " + item.ToString();
                i += 1;
            }
            return resultat;
        }

        public override String ToString()
        {
            return base.ToString() + String.Format("Cette video a {0} saisons {1} episodes et elle est sortie en l'année {2} ",Methodes_utilitaire.affectation_donneesformater(NBsaison),Methodes_utilitaire.affectation_donneesformater(NBepisode), Methodes_utilitaire.affectation_donneesformater(Annee_lancement.ToString()));
        }

        public  async Task<Video_serie> videoserie_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_videoserie + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            Video_serie resultat = await basedonnees.video_serie.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Video_serie>> liste_videosseries_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete=requetesql_videoserie + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            List<Video_serie> resultat = await basedonnees.video_serie.SqlQuery(requete).ToListAsync();
            return resultat;

        }


        public async Task<Video_serie> videoserie_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_videoserie.getelement(dictionnaire_critere, operateure);
        }

        public async Task<List<Video_serie>> liste_videosseries_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_videoserie.getelements(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> update(Dictionary<string, string> dictionnaire_modification, Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_videoserie.update(dictionnaire_modification, dictionnaire_critere, operateure);
        }

        public async Task<Boolean> delete(Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_videoserie.delete(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> insert()
        {
            return await data_service_videoserie.insert(null,false);
        }
    }
}
