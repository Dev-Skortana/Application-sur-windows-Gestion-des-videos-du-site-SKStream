using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSKStream
{
    partial class Detail_series
    {
        private readonly Iservices_database<Detail_series> data_service_detailserie;
        private const String requetesql_detailserie = "Select Sommaire_seriesSet_Detail_series.titre_sommaire as titre,Sommaire_seriesSet_Detail_series.Titre as titre_serie,Sommaire_seriesSet_Detail_series.saison,Sommaire_seriesSet_Detail_series.episode,Sommaire_seriesSet.lien from Sommaire_seriesSet_Detail_series inner join Sommaire_seriesSet on Sommaire_seriesSet_Detail_series.saison=Sommaire_seriesSet.saison and Sommaire_seriesSet_Detail_series.episode=Sommaire_seriesSet.episode and Sommaire_seriesSet_Detail_series.Titre_sommaire=Sommaire_seriesSet.Titre inner join VideosSet_Series on Sommaire_seriesSet_Detail_series.titre=VideosSet_Series.titre ";
        public Detail_series() {

        }
        public Detail_series(Iservices_database<Detail_series> data_service)
        {
            this.data_service_detailserie = data_service;
        }
        public Detail_series(String titre_sommaire,int saison, int episode, String lien, Series serie) : base(titre_sommaire,saison, episode, lien)
        {
            this.Series = serie;
        }
        public Detail_series(String titre_sommaire,int saison, int episode, String lien) : base(titre_sommaire,saison, episode, lien)
        {
        }
        
        public override string ToString()
        {
            return base.ToString();
        }

        public async Task<Detail_series> detailseries_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_detailserie + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            Detail_series resultat =await basedonnees.detail_series.SqlQuery(requete).SingleAsync();       
            return resultat;
        }

        public async Task<List<Detail_series>> liste_detailseries_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_detailserie + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            requete = requete = Methodes_utilitaire.rectification_resultat(requete, new String[] { "VideosSet.titre", "Sommaire_seriesSet.saison", "Sommaire_seriesSet.episode" }, new String[] { "Sommaire_seriesSet_Detail_series.Titre_sommaire", "Sommaire_seriesSet_Detail_series.saison", "Sommaire_seriesSet_Detail_series.episode" });
            List<Detail_series> resultat=await basedonnees.detail_series.SqlQuery(requete).ToListAsync();
            return resultat;
        }

        public async Task<Detail_series> detailserie_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_detailserie.getelement(dictionnaire_critere, operateure);
        }

        public async Task<List<Detail_series>> liste_detailseries_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_detailserie.getelements(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> update(Dictionary<string, string> dictionnaire_modification, Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_detailserie.update(dictionnaire_modification, dictionnaire_critere, operateure);
        }

        public async Task<Boolean> delete(Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_detailserie.delete(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> insert()
        {
            return await data_service_detailserie.insert(null,true);
        }

    }
}
