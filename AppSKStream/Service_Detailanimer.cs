using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSKStream
{
    class Service_Detailanimer : Iservices_database<Detail_animer>
    {
        public string requete_sql_extraction
        {
            get
            {
                return "Select Sommaire_seriesSet_Detail_animer.Titre_sommaire as titre,Sommaire_seriesSet_Detail_animer.Titre as titre_animer,Sommaire_seriesSet_Detail_animer.saison,Sommaire_seriesSet_Detail_animer.episode,Sommaire_seriesSet.lien from Sommaire_seriesSet_Detail_animer inner join Sommaire_seriesSet on Sommaire_seriesSet_Detail_animer.saison=Sommaire_seriesSet.saison and Sommaire_seriesSet_Detail_animer.episode=Sommaire_seriesSet.episode and Sommaire_seriesSet_Detail_animer.Titre_sommaire=Sommaire_seriesSet.titre inner join VideosSet_Animer on Sommaire_seriesSet_Detail_animer.titre=VideosSet_Animer.titre ";
            }
        }

        public async Task<Detail_animer> getelement(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql = Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre", "saison", "episode" }, new String[] { "Sommaire_seriesSet_Detail_animer.Titre_sommaire", "Sommaire_seriesSet_Detail_animer.saison", "Sommaire_seriesSet_Detail_animer.episode" });
            String requete = requete_sql_extraction + conditions_sql;
            Detail_animer resultat = await basedonnees.detail_animer.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Detail_animer>> getelements(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String conditions_sql = Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            conditions_sql = Methodes_utilitaire.rectification_resultat(conditions_sql, new String[] { "titre", "saison", "episode" }, new String[] { "Sommaire_seriesSet_Detail_animer.Titre_sommaire", "Sommaire_seriesSet_Detail_animer.saison", "Sommaire_seriesSet_Detail_animer.episode" });
            String requete = requete_sql_extraction + conditions_sql;
            List<Detail_animer> resultat = await basedonnees.detail_animer.SqlQuery(requete).ToListAsync();
            return resultat;
        }

        public async Task<bool> update(Dictionary<string, string> donnees_modification, Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "update ";
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
            requete += "from Sommaire_seriesSet_Detail_animer inner join Sommaire_seriesSet on Sommaire_seriesSet_Detail_animer.titre_sommaire=Sommaire_seriesSet.Titre and Sommaire_seriesSet_Detail_animer.Saison=Sommaire_seriesSet.Saison and Sommaire_seriesSet_Detail_animer.Episode=Sommaire_seriesSet.Episode inner join VideosSet_Video_serie on Sommaire_seriesSet_Detail_animer.titre_sommaire=VideosSet_Video_serie.Titre inner join VideosSet on Sommaire_seriesSet_Detail_animer.titre_sommaire=VideosSet.Titre " + Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> delete(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "delete Sommaire_seriesSet_Detail_animer.Titre_sommaire as titre,Sommaire_seriesSet_Detail_animer.Titre as titre_animer,Sommaire_seriesSet_Detail_animer.saison,Sommaire_seriesSet_Detail_animer.episode from Sommaire_seriesSet_Detail_animer inner join Sommaire_seriesSet on Sommaire_seriesSet_Detail_animer.titre_sommaire=Sommaire_seriesSet.Titre and Sommaire_seriesSet_Detail_animer.Saison=Sommaire_seriesSet.Saison and Sommaire_seriesSet_Detail_animer.Episode=Sommaire_seriesSet.Episode left join VideosSet_Video_serie on Sommaire_seriesSet_Detail_animer.titre_sommaire=VideosSet_Video_serie.Titre left join VideosSet on Sommaire_seriesSet_Detail_animer.titre_sommaire=VideosSet.Titre "; 
            requete += Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> insert(Dictionary<String, Object> dictionnaire_arguments_enregistrement, Boolean using_procedurestocker)
        {
            String requete;
            if (!using_procedurestocker)
            {
                requete = "insert into Sommaire_seriesSet_Detail_animer(Titre_sommaire,Titre,Saison,Episode) values('" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "'," + int.Parse(dictionnaire_arguments_enregistrement["saison"].ToString()) + "," + int.Parse(dictionnaire_arguments_enregistrement["episode"].ToString()) + ")";
            }
            else
            {
                requete = "exec insertion_animer_sommaireseries_detailanimer '" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "'," + int.Parse(dictionnaire_arguments_enregistrement["saison"].ToString()) + "," + int.Parse(dictionnaire_arguments_enregistrement["episode"].ToString()) + ",'" + Convert.ToString(dictionnaire_arguments_enregistrement["lien"]) + "'";
            }
            int nombre = await new Gestion_video_skstreamContainer().Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }
    }
}
