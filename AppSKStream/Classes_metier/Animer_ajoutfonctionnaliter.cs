using AppSKStream.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSKStream.Classes_metier
{
    partial class Animer
    {
        private readonly Iservices_database<Animer> data_service_animer;
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
