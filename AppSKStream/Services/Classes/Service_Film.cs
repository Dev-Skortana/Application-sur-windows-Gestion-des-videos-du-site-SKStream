using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSKStream.Classes_metier;
using AppSKStream.Helpers;
using AppSKStream.Services.Interfaces;

namespace AppSKStream.Services.Classes
{
    class Service_Film : Iservices_database<Films>
    {
        public string requete_sql_extraction
        {
            get
            {
                return "Select VideosSet_Films.titre,acteure,genre,pays,duree,creer_par,categorie,description_film as description,filefullname,anne_production,cast(date_sortie as date) as date_sortie,lien from VideosSet_Films inner join VideosSet on VideosSet.titre=VideosSet_Films.titre ";
            }
        }

        public async Task<Films> getelement(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql = Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre" }, new String[] { "VideosSet_Films.titre" });
            String requete = requete_sql_extraction + conditions_sql;
            Films resultat = resultat = await basedonnees.film.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Films>> getelements(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql = Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre" }, new String[] { "VideosSet_Films.titre" });
            String requete = requete_sql_extraction + conditions_sql;
            List<Films> resultat = await basedonnees.film.SqlQuery(requete).ToListAsync();
            return resultat;
        }

        public async Task<bool> update(Dictionary<string, string> donnees_modification, Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "update VideosSet_Films ";
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
            requete += "from VideosSet_Films inner join VideosSet on VideosSet_Films.Titre=VideosSet.Titre " + Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre =await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> delete(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "delete VideosSet_Films from VideosSet_Films inner join VideosSet on VideosSet_Films.Titre=VideosSet.Titre ";
            requete += Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> insert(Dictionary<String, Object> dictionnaire_arguments_enregistrement, Boolean using_procedurestocker)
        {
            String requete;
            if (!using_procedurestocker)
            {
                requete = "insert into VideosSet_Films(Titre,Anne_production,Date_sortie,Lien) values('" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "'," + int.Parse(dictionnaire_arguments_enregistrement["annee_production"].ToString()) + ",'" + DateTime.Parse(dictionnaire_arguments_enregistrement["date_sortie"].ToString()) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["lien"]) + "')";
            }
            else
            {
                requete = "exec insertion_videos_films '" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["acteure"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["genre"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["pays"]) + "','" + TimeSpan.Parse(dictionnaire_arguments_enregistrement["duree"].ToString()) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["creer_par"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["categorie"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["description"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["filefullname"]) + "'," + int.Parse(dictionnaire_arguments_enregistrement["annee_production"].ToString()) + ",'" + DateTime.Parse(dictionnaire_arguments_enregistrement["date_sortie"].ToString()) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["lien"]) + "'";
            }
            int nombre = await new Gestion_video_skstreamContainer().Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }
    }
}
