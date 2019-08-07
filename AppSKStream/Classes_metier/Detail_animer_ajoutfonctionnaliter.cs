using AppSKStream.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSKStream.Classes_metier
{
    partial class Detail_animer
    {
        private readonly Iservices_database<Detail_animer> data_service_detailanimer;
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
