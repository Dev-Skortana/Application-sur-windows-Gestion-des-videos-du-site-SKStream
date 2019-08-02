using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AppSKStream
{
   partial class Films
   {
        private readonly Iservices_database<Films> data_service_film;
       protected const String nom_domaine_siteskstream = "http://www.skstream.bz/";
        private const String requetesql_film = "Select VideosSet_Films.titre,acteure,genre,pays,duree,creer_par,categorie,description_film as description,filefullname,anne_production,cast(date_sortie as date) as date_sortie,lien from VideosSet_Films inner join VideosSet on VideosSet.titre=VideosSet_Films.titre ";
       public Films()
       {
            
       }
        public Films(Iservices_database<Films> data_service)
        {
            this.data_service_film = data_service;
        }
       public Films(String titre, String acteure, String genre, String pays, TimeSpan duree, String creer_par, String description,String filefullname, int annee_production, DateTime date_sortie, String lien, String categorie = "film") : base(titre, acteure, genre, pays, duree, creer_par, categorie, description,filefullname)
       {
            this.Anne_production = annee_production; this.Date_sortie =date_sortie; this.Lien = nom_domaine_siteskstream + "" + lien;
       }
        public override string ToString()
        {
            return base.ToString() + String.Format("elle a été produite en {0} sa date de sortie est le {1}.",Methodes_utilitaire.affectation_donneesformater(Anne_production),Methodes_utilitaire.affectation_donneesformater(Date_sortie));
        }

        public async Task<Films> film_selon_criteres(String[] champs_criteres, String[] valeures_criteres, String operateure = "=") {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_film + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            Films resultat =resultat =await basedonnees.film.SqlQuery(requete).SingleAsync();
            return resultat;
        }
        
        public async Task<List<Films>> liste_films_selon_criteres(String[] champs_criteres, String[] valeures_criteres,String operateure="=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requetesql_film + Methodes_utilitaire.creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
            List<Films> resultat =await basedonnees.film.SqlQuery(requete).ToListAsync();
            return resultat;
            
        }

        public async Task<Films> film_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_film.getelement(dictionnaire_critere, operateure);
        }

        public async Task<List<Films>> liste_films_selon_criteres(Dictionary<String, String> dictionnaire_critere, String operateure = "=")
        {
            return await data_service_film.getelements(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> update(Dictionary<string, string> dictionnaire_modification, Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_film.update(dictionnaire_modification, dictionnaire_critere, operateure);
        }

        public async Task<Boolean> delete(Dictionary<string, string> dictionnaire_critere, string operateure = "=")
        {
            return await data_service_film.delete(dictionnaire_critere, operateure);
        }

        public async Task<Boolean> insert()
        {
            return await data_service_film.insert(null, true);
        }

    }
}