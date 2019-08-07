using AppSKStream.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSKStream.Classes_metier
{
    partial class Series
    {
        private readonly Iservices_database<Series> data_service_serie;
        public Series(Iservices_database<Series> data_service)
        {
            this.data_service_serie = data_service;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Series(String titre, String acteure, String genre, String pays, TimeSpan duree, String creer_par, String description,String filefullname, int nbsaison, int nbepisode, int anneelancement, String categorie = "serie") : base(titre, acteure, genre, pays, duree, creer_par, categorie, description,filefullname, nbsaison, nbepisode, anneelancement)
        {
            this.Detail_series = new HashSet<Detail_series>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Series(String titre, String acteure, String genre, String pays, TimeSpan duree, String creer_par, String description,String filefullname, int nbsaison, int nbepisode, int anneelancement, ICollection<Detail_series> detail_series, String categorie = "serie") : base(titre, acteure, genre, pays, duree, creer_par, categorie, description,filefullname, nbsaison, nbepisode, anneelancement)
        {
            this.Detail_series = new HashSet<Detail_series>(detail_series);
        }
        public override string ToString()
        {
            String resultat = base.ToString() + recuperationliste_detailseries(this.Detail_series.ToList());
            return resultat;
        }

        public async Task<Series> serie_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_serie.getelement(dictionnaire_critere, operateure);
        }

        public async Task<List<Series>> liste_series_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_serie.getelements(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> update(Dictionary<string, string> dictionnaire_modification, Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_serie.update(dictionnaire_modification, dictionnaire_critere, operateure);
        }

        public async Task<Boolean> delete(Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_serie.delete(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> insert()
        {
            return await data_service_serie.insert(null,true);
        }
    }
}
