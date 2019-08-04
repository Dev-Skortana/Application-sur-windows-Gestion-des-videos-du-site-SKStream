using AppSKStream.Classes_metier;
using AppSKStream.Helpers;
using AppSKStream.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSKStream;

namespace AppSKStream.Classes_metier
{
    partial class Detail_animer
    {
        private readonly Iservices_database<Detail_animer> data_service_detailanimer;
        private const String requetesql_detailanimer = "Select Sommaire_seriesSet_Detail_animer.Titre_sommaire as titre,Sommaire_seriesSet_Detail_animer.Titre as titre_animer,Sommaire_seriesSet_Detail_animer.saison,Sommaire_seriesSet_Detail_animer.episode,Sommaire_seriesSet.lien from Sommaire_seriesSet_Detail_animer inner join Sommaire_seriesSet on Sommaire_seriesSet_Detail_animer.saison=Sommaire_seriesSet.saison and Sommaire_seriesSet_Detail_animer.episode=Sommaire_seriesSet.episode and Sommaire_seriesSet_Detail_animer.Titre_sommaire=Sommaire_seriesSet.titre inner join VideosSet_Animer on Sommaire_seriesSet_Detail_animer.titre=VideosSet_Animer.titre ";
        public Detail_animer() {

        }
        public Detail_animer(Iservices_database<Detail_animer> data_service)
        {
            this.data_service_detailanimer = data_service;
        }
        public Detail_animer(String titre_sommaire,int saison, int episode, String lien, Animer animer) : base(titre_sommaire,saison, episode, lien)
        {
            this.Animer = animer;
        }
        public Detail_animer(String titre_sommaire,int saison, int episode, String lien) : base(titre_sommaire,saison, episode, lien)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public async Task<Detail_animer> detailanimer_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_detailanimer + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            Detail_animer resultat= await basedonnees.detail_animer.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Detail_animer>> liste_detailanimer_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_detailanimer + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            requete = Methodes_utilitaire.rectification_resultat(requete, new String[] { "VideosSet.titre"}, new String[] { "Sommaire_seriesSet_Detail_animer.Titre_sommaire"});
            List<Detail_animer> resultat=await basedonnees.detail_animer.SqlQuery(requete).ToListAsync();
            return resultat;
        }

        public async Task<Detail_animer> detail_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_detailanimer.getelement(dictionnaire_critere, operateure);
        }

        public async Task<List<Detail_animer>> liste_detailanimer_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_detailanimer.getelements(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> update(Dictionary<string, string> dictionnaire_modification, Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_detailanimer.update(dictionnaire_modification, dictionnaire_critere, operateure);
        }

        public async Task<Boolean> delete(Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_detailanimer.delete(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> insert()
        {
            return await data_service_detailanimer.insert(null,true);
        }
    }
}
