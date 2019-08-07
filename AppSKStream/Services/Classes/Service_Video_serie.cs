using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSKStream.Classes_metier;
using AppSKStream.Helpers;
using AppSKStream.Services.Interfaces;

namespace AppSKStream.Services.Classes
{
    class Service_Video_serie : Iservices_database<Video_serie>
    {
        public string requete_sql_extraction
        {
            get
            {
                return "select VideosSet_Video_serie.titre,acteure,genre,pays,duree,creer_par,categorie,description_film as description,filefullname,NBsaison,NBepisode,Annee_lancement from VideosSet inner join VideosSet_Video_serie on VideosSet.titre=VideosSet_Video_serie.titre ";
            }
        }

        public async Task<Video_serie> getelement(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql=Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre" }, new String[] { "VideosSet_Video_serie.titre" });
            String requete = requete_sql_extraction + conditions_sql;
            Video_serie resultat = await basedonnees.video_serie.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Video_serie>> getelements(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql = Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre" }, new String[] { "VideosSet_Video_serie.titre" });
            String requete = requete_sql_extraction + conditions_sql;
            List<Video_serie> resultat = await basedonnees.video_serie.SqlQuery(requete).ToListAsync();
            return resultat;
        }

        public async Task<bool> update(Dictionary<string, string> donnees_modification, Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "update VideosSet_Video_serie inner join VideosSet on VideosSet_Video_serie.Titre=VideosSet.Titre ";
            Boolean premier_passage = true;
            foreach (KeyValuePair<String, String> item in donnees_modification)
            {
                if (!premier_passage)
                {
                    requete += ", ";
                }
                int test;
                if (int.TryParse(item.Value, out test))
                {
                    requete += "set " + item.Key + "=" + item.Value.Replace("'", "''") + " ";
                }
                else
                {
                    requete += "set " + item.Key + "=" + "'" + item.Value.Replace("'", "''") + "' ";
                }
                premier_passage = false;
            }
            requete += "from VideosSet_Video_serie inner join VideosSet on VideosSet_Video_serie.Titre=VideosSet.Titre " + Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }
        
        public async Task<bool> delete(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "delete VideosSet_Video_serie from VideosSet_Video_serie inner join VideosSet on VideosSet_Video_serie.Titre=VideosSet.Titre ";
            requete += Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> insert(Dictionary<String, Object> dictionnaire_arguments_enregistrement, Boolean using_procedurestocker=false)
        {
            String requete;
            requete = "insert into VideosSet_Video_serie(Titre,Annee_lancement,NBsaison,NBepisode) values('" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "'," + int.Parse(dictionnaire_arguments_enregistrement["annee_lancement"].ToString()) + "," + int.Parse(dictionnaire_arguments_enregistrement["nbsaison"].ToString()) + "," + int.Parse(dictionnaire_arguments_enregistrement["nbepisode"].ToString()) + ")";
            int nombre = await new Gestion_video_skstreamContainer().Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }
    }
}
