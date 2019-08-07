using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSKStream.Classes_metier;
using AppSKStream.Helpers;
using AppSKStream.Services.Interfaces;

namespace AppSKStream.Services.Classes
{
    class Service_animer : Iservices_database<Animer>
    {
        public string requete_sql_extraction
        {
            get
            {
                return "Select VideosSet_Animer.titre,acteure,genre,pays,duree,creer_par,categorie,description_film as description,filefullname,nbsaison,nbepisode,annee_lancement from VideosSet_Animer inner join VideosSet_Video_serie on VideosSet_Video_serie.titre=VideosSet_Animer.titre inner join VideosSet on VideosSet_Animer.titre=VideosSet.titre ";
            }
        }
       
        public async Task<bool> delete(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "delete VideosSet_Animer from VideosSet_Animer inner join VideosSet_Video_serie on VideosSet_Animer.Titre=VideosSet_Video_serie.Titre inner join VideosSet on VideosSet_Animer.Titre=VideosSet.Titre ";
            requete += Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<Animer> getelement(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql = Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre"}, new String[] { "VideosSet_Animer.titre"});
            String requete = requete_sql_extraction + conditions_sql;
            Animer resultat = await basedonnees.animer.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Animer>> getelements(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql = Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre"}, new String[] { "VideosSet_Animer.titre"});
            String requete = requete_sql_extraction + conditions_sql;
            List<Animer> resultat = await basedonnees.animer.SqlQuery(requete).ToListAsync();
            return resultat;

        }

        

        public async Task<bool> update(Dictionary<string, string> donnees_modification, Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "update VideosSet_Animer ";
            Boolean premier_passage = true;
            foreach (KeyValuePair<String, String> item in donnees_modification)
            {
                if (!premier_passage)
                {
                    requete += ", ";
                }
                premier_passage = false;
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
            requete += "from VideosSet_Animer inner join VideosSet_Video_serie on VideosSet_Animer.Titre=VideosSet_Video_serie.Titre inner join VideosSet on VideosSet_Animer.Titre=VideosSet.Titre " + Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre =await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> insert(Dictionary<String, Object> dictionnaire_arguments_enregistrement, Boolean using_procedurestocker)
        {
            String requete;
            if (!using_procedurestocker)
            {
                requete = "insert into VideosSet_Animer(Titre) values('" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "')";
            }
            else
            {
                requete = "exec insertion_videosseries_animer '" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["acteure"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["genre"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["pays"]) + "','" + TimeSpan.Parse(dictionnaire_arguments_enregistrement["duree"].ToString()) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["creer_par"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["categorie"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["description"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["filefullname"]) + "'," + int.Parse(dictionnaire_arguments_enregistrement["nbsaison"].ToString()) + "," + int.Parse(dictionnaire_arguments_enregistrement["nbepisode"].ToString()) + "," + int.Parse(dictionnaire_arguments_enregistrement["annee_lancement"].ToString()) + "";
            }
            int nombre = await new Gestion_video_skstreamContainer().Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

    }
}
