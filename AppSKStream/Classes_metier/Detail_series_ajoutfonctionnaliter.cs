using AppSKStream.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSKStream.Classes_metier
{
    partial class Detail_series
    {
        private readonly Iservices_database<Detail_series> data_service_detailserie;
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
