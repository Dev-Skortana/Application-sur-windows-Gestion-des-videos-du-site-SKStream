using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AppSKStream
{
    public static class Methodes_utilitaire
    {
        public const String nom_domaine = @"https://www.skstream.bz/";
        public static String return_datesortie_formater_tostring(String donnees) {
            DateTime date_resultat;
            String resultat = DateTime.TryParse(donnees,out date_resultat)==false || Regex.Match(donnees, "^0{2,3}[0-9]+").Success ? "9000/01/01" :donnees;
            return resultat;
        }
        public static String rectification_resultat(String cible, String[] listeanciennevaleur, String[] listenouvellevaleur)
        {
            for (var i = 0; i < listeanciennevaleur.Length; i++)
            {
                cible = cible.Replace(listeanciennevaleur[i], listenouvellevaleur[i]);
            }
            return cible;
        }

        public static Object affectation_donneesformater(Object donnees)
        {
            Object resultat=null;
            if (donnees.GetType().Equals(typeof(String))) {
                resultat = String.IsNullOrEmpty(donnees.ToString())==false ? donnees : "Information indisponible";
            } else if (donnees.GetType().Equals(typeof(int)) || donnees.GetType().Equals(typeof(long))) {
                resultat = String.IsNullOrEmpty(donnees.ToString())==false ? donnees : 0;
            } else if (donnees.GetType().Equals(typeof(TimeSpan))) {
                resultat = String.IsNullOrEmpty(donnees.ToString())==false ? donnees : new TimeSpan(0, 0, 0);
            } else if (donnees.GetType().Equals(typeof(DateTime))) {
                resultat = String.IsNullOrEmpty(donnees.ToString())==false && donnees.ToString().Substring(0,donnees.ToString().IndexOf(' '))!= "01/01/9000" ? (Object)donnees.ToString().Substring(0, donnees.ToString().IndexOf(' ')) : "XX/XX/XXXX";
            }
           
            return resultat;
        }
        /* Codes ci dessous a éditer pour pouvoir appliquer une condition pour chaque champ selon l'opérateure de la condition */
        public static String creationclause_conditionrequete(String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        {
            for(var i=0;i<valeures_criteres.Length;i++)
            {
                valeures_criteres[i] = valeures_criteres[i].Replace("'", "''");
            }
            String resultat = "";
            if (champs_criteres.Length>0) {
                resultat = "where ";
                for (var i = 0; i < champs_criteres.Length; i++)
                {
                    if (i != 0)
                    {
                        resultat += "and ";
                    }
                    champs_criteres[i] = rectification_resultat(champs_criteres[i], new String[] {"creerpar", "categories", "anneelancement", "anneeproduction", "datesortie" }, new String[] {"creer_par", "categorie", "annee_lancement", "anne_production", "date_sortie" });
                    if (champs_criteres[i] == "date_sortie" || champs_criteres[i]=="duree"){
                        resultat +=champs_criteres[i].ToUpper()=="date_sortie".ToUpper() ? "CAST(" + champs_criteres[i] + " as date)='" + valeures_criteres[i] + "' " : "CAST(" + champs_criteres[i] + " as time(7))='" + valeures_criteres[i] + "' ";
                    }
                    else{
                        resultat +=operateure.Contains("=") ? "CAST(" + champs_criteres[i] + " as varchar(500))='" + valeures_criteres[i] + "' " : "CAST(" + champs_criteres[i] + " as varchar(500)) like '%" + valeures_criteres[i] + "%' ";
                    }
                }
            }
            return resultat;
        }

        //public static async Task<Boolean> modification(String nomtable_cleprimaire, String nomtable_cleetrangere,String nomchamprelation,String secondenomtable_cleetrangere, String[] champ_modification, String[] valeure_modification, String[] champ_critere, String[] valeure_critere, String operateure = "=")
        //{
        //    Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
        //    String requete = "update " + nomtable_cleetrangere + " inner join " + nomtable_cleprimaire + " on " + nomtable_cleprimaire + "." + nomchamprelation + "=" + nomtable_cleetrangere + "." + nomchamprelation + " " + secondenomtable_cleetrangere!=null ? "inner join " + secondenomtable_cleetrangere + " on " + nomtable_cleprimaire + "." + nomchamprelation + "=" + secondenomtable_cleetrangere + "." + nomchamprelation + " ": "";
        //    for (var i = 0; i < champ_modification.Length; i++)
        //    {
        //        if (i != 0)
        //        {
        //            requete += ", ";
        //        }
        //        requete += "set" + champ_modification[i] + "=" + champ_modification[i]=="annee_production" || champ_modification[i]=="saison" || champ_modification[i] == "episode" || champ_modification[i] == "annee_lancement" || champ_modification[i] == "nbsaison" || champ_modification[i] == "nbepisode" ? valeure_modification[i] + " " : "'" + valeure_modification[i] + "' ";
        //    }
        //    requete += creationclause_conditionrequete(champ_critere, valeure_critere, operateure);
        //    int nombre= basedonnees.Database.ExecuteSqlCommand(requete);
        //    return nombre != 0 ? true : false;
        //}

        //public static async Task<Boolean> suppression(String nomtable_cleprimaire, String nomtable_cleetrangere,String  nomchamprelation,String secondenomtable_cleetrangere, String[] champs_criteres, String[] valeures_criteres, String operateure = "=")
        //{
        //    Gestion_video_skstreamContainer basedonnees = new Gestion_video_skstreamContainer();
        //    String requete = "delete from " + nomtable_cleetrangere + " inner join " + nomtable_cleprimaire + " on " + nomtable_cleprimaire + "." + nomchamprelation + "=" + nomtable_cleetrangere + "." + nomchamprelation + " " + secondenomtable_cleetrangere != null ? "inner join " + secondenomtable_cleetrangere + " on " + nomtable_cleprimaire + "." + nomchamprelation + "=" + secondenomtable_cleetrangere + "." + nomchamprelation + " " : "";
        //    requete += creationclause_conditionrequete(champs_criteres, valeures_criteres, operateure);
        //    int nombre=basedonnees.Database.ExecuteSqlCommand(requete);
        //    return nombre != 0 ? true : false;
        //}

    }

}
