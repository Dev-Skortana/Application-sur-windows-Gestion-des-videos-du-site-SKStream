using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSKStream
{
    partial class Animer
    {
        private readonly Iservices_database<Animer> data_service_animer;
        private const String requetesql_animer = "Select VideosSet_Animer.titre,acteure,genre,pays,duree,creer_par,categorie,description_film as description,filefullname,nbsaison,nbepisode,annee_lancement from VideosSet_Animer inner join VideosSet_Video_serie on VideosSet_Video_serie.titre=VideosSet_Animer.titre inner join VideosSet on VideosSet_Animer.titre=VideosSet.titre ";
        public Animer(Iservices_database<Animer> data_service)
        {
            this.data_service_animer = data_service;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animer(String titre, String acteure, String genre, String pays, TimeSpan duree, String creer_par, String description,String filefullname, int nbsaison, int nbepisode, int anneelancement, ICollection<Detail_animer> detail_animer, String categorie = "animer") : base(titre, acteure, genre, pays, duree, creer_par, categorie, description,filefullname,nbsaison,nbepisode,anneelancement) {
            this.Detail_animer = new HashSet<Detail_animer>(detail_animer);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animer(String titre, String acteure, String genre, String pays, TimeSpan duree, String creer_par, String description,String filefullname, int nbsaison, int nbepisode, int anneelancement, String categorie = "animer") : base(titre, acteure, genre, pays, duree, creer_par, categorie, description,filefullname, nbsaison, nbepisode, anneelancement){
            this.Detail_animer = new HashSet<Detail_animer>();
        }
        public override string ToString()
        {
            String resultat = base.ToString() + recuperationliste_detailanimer(this.Detail_animer.ToList());
            return resultat;
        }


        /*A voir */
        public async Task<Animer> animer_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_animer + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            Animer resultat =await basedonnees.animer.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Animer>> liste_animer_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_animer + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            List<Animer> resultat =await basedonnees.animer.SqlQuery(requete).ToListAsync();
            return resultat;
        }

        public async Task<Animer> animer_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_animer.getelement(dictionnaire_critere, operateure);
        }

        public async Task<List<Animer>> liste_animer_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_animer.getelements(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> update(Dictionary<string, string> dictionnaire_modification, Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_animer.update(dictionnaire_modification, dictionnaire_critere, operateure);
        }

        public async Task<Boolean> delete(Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_animer.delete(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> insert()
        {
            return await data_service_animer.insert(null,true);
        }
    }
}
