using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSKStream
{
    class Service_Video : Iservices_database<Videos>
    {
        public string requete_sql_extraction
        {
            get
            {
                return "select titre,acteure,genre,pays,duree,creer_par,categorie,description_film as description,filefullname from VideosSet ";
            }
        }

        public async Task<Videos> getelement(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requete_sql_extraction + Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            Videos resultat = await basedonnees.VideosSet.SqlQuery(requete).SingleAsync();
            return resultat;
        }

        public async Task<List<Videos>> getelements(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = requete_sql_extraction + Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(),donnees_critere.Values.ToArray(), operateure);
            List<Videos> resultat = await basedonnees.VideosSet.SqlQuery(requete).ToListAsync();
            return resultat;
        }

        public async Task<bool> update(Dictionary<string, string> donnees_modification, Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "update VideosSet ";
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
                    requete += "set " + item.Key + "=" + item.Value.Replace("'","''") + " ";
                }
                else
                {
                    requete += "set " + item.Key + "=" + "'" + item.Value.Replace("'", "''") + "' ";
                }
                premier_passage = false;
            }
            requete += Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> delete(Dictionary<string, string> donnees_critere, string operateure = "=")
        {
            Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
            String requete = "delete VideosSet from VideosSet ";
            requete += Methodes_utilitaire.creationclause_conditionrequete(donnees_critere.Keys.ToArray(), donnees_critere.Values.ToArray(), operateure);
            int nombre = await basedonnees.Database.ExecuteSqlCommandAsync(requete);
            return nombre != 0 ? true : false;
        }

        public async Task<bool> insert(Dictionary<String, Object> dictionnaire_arguments_enregistrement, Boolean using_procedurestocker=false)
        { 
           String requete;  
           requete ="insert into VideosSet(Titre,Genre,Pays,Duree,Creer_par,Categorie,Description,Filefullname) values('" + Convert.ToString(dictionnaire_arguments_enregistrement["titre"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["Genre"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["pays"]) + "','" + TimeSpan.Parse(dictionnaire_arguments_enregistrement["duree"].ToString()) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["creer_par"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["categorie"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["description"]) + "','" + Convert.ToString(dictionnaire_arguments_enregistrement["filefullname"]) + "')";
           int nombre=await new Gestion_video_skstreamContainer().Database.ExecuteSqlCommandAsync(requete);
           return nombre != 0 ? true : false;
        }
    }
}
