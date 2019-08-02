using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using MonoFlat;
using System.Data.Entity.Core;
namespace AppSKStream
{
    public partial class Acceuille : Form
    {
        private Gestion_video_skstreamContainer database = new Gestion_video_skstreamContainer();
        private String repertoire_images = Application.StartupPath + @"\Images_fichesvideos", section = "";
        private List<String> urls_telechargements_images = new List<string>(); 
        private int temps = 0, seconde_traitement = 0, minute_traitement = 0, heure_traitement = 0,page_actuelle=1;
        private Boolean premierpassage = true, recuperationencours = false;
        private delegate Task deleguer_gestionmethodetask();
        private deleguer_gestionmethodetask methode_task;

        public Acceuille()
        {
            InitializeComponent();
        }

        private void controle_timers (System.Windows.Forms.Timer[] liste_timers,Boolean[] lancer){
            for (var i = 0; i < liste_timers.Length; i++) {
                if (lancer[i]){
                    liste_timers[i].Start();
                }
                else{
                    liste_timers[i].Stop();
                }
            }
        }

        private void insertion_valeure_texte(Label[] controleslabels, String[] valeures){
            for (var i = 0; i < controleslabels.Length; i++){
                controleslabels[i].Text = valeures[i];
            }
        }

        public void affectation_section(MonoFlat_RadioButton radio,MonoFlat_HeaderLabel label) {
            if (radio.Checked) {
                section = radio.Text.ToLower();
                label.Text = "Récupération des " + section;
                bt_lancementrecuperation.Text ="Lancer la récupération des " + section;
                bt_lancementrecuperation.Enabled = true;
            }
        }
        private String affectation_type_temps(int type_temps,String partie_temps,MonoFlat_Label label) {
         
            String resultat = "";
            int r = 0;
            if (type_temps==60) {
                if (partie_temps == "minute") {
                    r = minute_traitement + 1;
                    resultat = r.ToString();
                } else if (partie_temps=="heure"){
                    r = heure_traitement + 1;
                    minute_traitement = 0;
                    resultat = r.ToString();
                }
            }
            return type_temps == 60 ? resultat : label.Text;
        }
        private String affectation_categorie_videos_connectionsite(String categorie)
        {
            String resultat = "";
            if (categorie == "Films"){
                resultat = "films";
            }
            else if (categorie == "Series"){
                resultat = "series";
            }
            else if (categorie == "Animé"){
                resultat = "mangas";
            }
            return resultat;
        }

        private async Task lancement_chargement() {
            if (!recuperationencours){
                recuperationencours = true;
                methode_task=async() =>await chargement_videos_skstream();
                await methode_task();
            }
        }

        private async Task chargement_videos_skstream(int derniere_page =1)
        {
            WebClient web = new WebClient();
            if (page_actuelle <= derniere_page)
            { 
                StreamReader lecture = new StreamReader(web.OpenRead(Methodes_utilitaire.nom_domaine + section + "/page/" + page_actuelle), Encoding.UTF8);
                String fichiercode_listevideos = lecture.ReadToEnd();
                MatchCollection liste_videos = Regex.Matches(fichiercode_listevideos, "<a class=\"unfilm\" (href|HREF)=\"(.+)\">");
                Dictionary<String, Match> dictionnaire_regex = new Dictionary<string, Match>();
                Dictionary<String, MatchCollection> dictionnaire_regexmultiple = new Dictionary<string, MatchCollection>();
                foreach (Match item in liste_videos)
                {
                    lecture = new StreamReader(web.OpenRead(Methodes_utilitaire.nom_domaine + item.Groups[2].Value), Encoding.UTF8);
                    fichiercode_listevideos = lecture.ReadToEnd().Trim();
                    dictionnaire_regex.Add("titre", Regex.Match(fichiercode_listevideos, "<strong>Titre original.+</strong>(.+)<"));
                    dictionnaire_regex.Add("acteures", Regex.Match(fichiercode_listevideos, "<strong>Acteurs.+</strong>\n*(<a.+>.+</a>(, )*)+</p>"));
                    dictionnaire_regex.Add("genre", Regex.Match(fichiercode_listevideos, "<strong>Genre.+</strong>\n*(<a.+>.+</a>(, )*)+</p>"));
                    dictionnaire_regex.Add("pays", Regex.Match(fichiercode_listevideos, "<strong>Nationalité.+</strong>\n*(<a.+>.+</a>(, )*)+</p>"));
                    dictionnaire_regex.Add("duree", Regex.Match(Methodes_utilitaire.rectification_resultat(fichiercode_listevideos, new String[] { "\r", "\n" }, new String[] { "", "" }), "<strong>Durée.+</strong>([0-9a-z ]+)</p>"));
                    dictionnaire_regex.Add("creerpar", Regex.Match(fichiercode_listevideos, "<strong>(Réalisateur|Créateur).+</strong>\n*(<a.+>.+</a>(, )*)+</p>"));
 /* Revoir regex */dictionnaire_regex.Add("description", Regex.Match(fichiercode_listevideos.Replace("\r", "").Replace("\n", ""), "<div class=\"more-info\"><h3>.+</h3><p>(<strong>.+</strong>)*([^<]+)</p>"));
                                       dictionnaire_regex.Add("url_image", Regex.Match(fichiercode_listevideos, "<div class=\"movie-info\">\n*<div class=\"thumb\">\n*<img src=\"([^\"]+)\".+>", RegexOptions.IgnoreCase));
                    if (section == "series" || section == "mangas")
                    {
                        dictionnaire_regex.Add("nbsaison", Regex.Match(Methodes_utilitaire.rectification_resultat(fichiercode_listevideos, new String[] { "\r", "\n" }, new String[] { "", "" }), "<p><strong>Nombre de saison[ ]+:[ ]+</strong>([0-9]+)</p>"));
                        dictionnaire_regex.Add("nbepisode", Regex.Match(Methodes_utilitaire.rectification_resultat(fichiercode_listevideos, new String[] { "\r", "\n" }, new String[] { "", "" }), "<p><strong>Nombre d'épisode[ ]+:[ ]+</strong>([0-9]+)</p>"));
                        dictionnaire_regex.Add("anneelancement", Regex.Match(Methodes_utilitaire.rectification_resultat(fichiercode_listevideos, new String[] { "\r", "\n" }, new String[] { "", "" }), "<p><strong>Année de lancement[ ]+:[ ]+</strong><a.+>([0-9]+)</a></p>"));
                        dictionnaire_regexmultiple.Add("saison_episode_lien", Regex.Matches(fichiercode_listevideos, "<a class=\"[^\"]+\" href=\"([^\"]+)\" title=\".+Saison ([0-9]+).+\">\n*<span class=\".+vostfr\"></span>\n*<span class=\".+\">([0-9 ]+)</span>"));
                        if (section == "series")
                        {
                            methode_task = async () => await creation_videos_enregistrementbasedonnees(fichiercode_listevideos, dictionnaire_regex, dictionnaire_regexmultiple, new Series(), null, new List<Detail_series>().Cast<Sommaire_series>().ToList());
                        }
                        else
                        {
                            methode_task = async () => await creation_videos_enregistrementbasedonnees(fichiercode_listevideos, dictionnaire_regex, dictionnaire_regexmultiple, new Animer(), null, new List<Detail_animer>().Cast<Sommaire_series>().ToList());
                        }
                    }
                    else
                    {
                        dictionnaire_regex.Add("anneeproduction", Regex.Match(fichiercode_listevideos, "<p><strong>Année de production.+</strong><a.+>([0-9]+)</a></p>"));
                        dictionnaire_regex.Add("datesortie", Regex.Match(fichiercode_listevideos, "<p><strong>Date de sortie.+</strong> ([0-9-]+)</p>"));
                        methode_task = async () => await creation_videos_enregistrementbasedonnees(fichiercode_listevideos, dictionnaire_regex, null, new Films(), item.Groups[2].Value, null);
                    }
                    Task tache=Task.Run(()=>methode_task());
                    page_actuelle++;
                    await tache;
                    dictionnaire_regex.Clear();
                    dictionnaire_regexmultiple.Clear();
                    methode_task = null;
                    methode_task = async () => await chargement_videos_skstream();         
                    tache =Task.Run(()=>methode_task());
                    
                }
            }
            else {
                Action<List<String>> methode_telechargement = (liste_donnees) =>
                {
                    foreach (String item in liste_donnees)
                    {
                        if (item.ToUpper().IndexOf(@"/images/empty.jpg".ToUpper())<=-1) {
                            web.DownloadFile(@item, repertoire_images + @"\" + item.Substring(item.LastIndexOf(@"/") + 1));
                        }
                    }
                };
                if (Directory.Exists(repertoire_images))
                {
                    Boolean url_checked = true;
                    List<String> urls_images_trie =new List<string>();
                    urls_telechargements_images.ForEach((url)=> { Directory.GetFiles(repertoire_images).ToList().ForEach((file) => { if (file.Substring(file.LastIndexOf(@"\") + 1).ToUpper() == url.Substring(url.LastIndexOf(@"/") + 1).ToUpper()) { url_checked = false; } }); if(url_checked==true) { urls_images_trie.Add(url);} url_checked = true; });
                    methode_telechargement(urls_images_trie);
                }
                else
                {
                    Directory.CreateDirectory(repertoire_images);
                    methode_telechargement(urls_telechargements_images);
                }
                urls_telechargements_images.Clear();
            }
        }
        

        private async Task creation_videos_enregistrementbasedonnees(String fichiercode_video, Dictionary<String, Match> expression_reguliere, Dictionary<String, MatchCollection> expression_reguliere_resultatmultiple, Videos objet_categorie,String lienfilm, List<Sommaire_series> liste_detail)
        {
            urls_telechargements_images.Add(expression_reguliere["url_image"].Groups[1].Value);
            try
            {
                if (liste_detail != null)
                {
                    Action insertion_detail = null;
                    if (objet_categorie as Series != null)
                    {
                        objet_categorie = new Series(expression_reguliere["titre"].Groups[1].Value, expression_reguliere["acteures"].Groups[1].Value, expression_reguliere["genre"].Groups[1].Value, expression_reguliere["pays"].Groups[1].Value, new Series().formatage_duree(expression_reguliere["duree"].Groups[1].Value), expression_reguliere["creerpar"].Groups[2].Value, expression_reguliere["description"].Groups[2].Value, expression_reguliere["url_image"].Groups[1].Value, int.Parse(expression_reguliere["nbsaison"].Groups[1].Value), int.Parse(expression_reguliere["nbepisode"].Groups[1].Value), int.Parse(expression_reguliere["anneelancement"].Groups[1].Value));
                        (objet_categorie as Series).Detail_series = return_listeobjetfille(expression_reguliere_resultatmultiple["saison_episode_lien"], expression_reguliere_resultatmultiple["saison_episode_lien"].Count, (Series)objet_categorie).Cast<Detail_series>().ToList();
                        database.insertion_videos_videosseries_series(objet_categorie.Titre, objet_categorie.Acteure, objet_categorie.Genre, objet_categorie.Pays, objet_categorie.Duree, objet_categorie.Creer_par, objet_categorie.Categorie, objet_categorie.Description, objet_categorie.Filefullname, int.Parse((objet_categorie as Series).NBsaison.ToString()), int.Parse((objet_categorie as Series).NBepisode.ToString()), int.Parse((objet_categorie as Series).Annee_lancement.ToString()));
                        insertion_detail = () =>
                        {
                            foreach (Detail_series item in (objet_categorie as Series).Detail_series)
                            {
                                database.insertion_series_sommaireseries_detailseries(objet_categorie.Titre,
                                    int.Parse(item.Saison.ToString()), int.Parse(item.Episode.ToString()), item.Lien);
                            }
                        };
                    }
                    else
                    {
                        objet_categorie = new Animer(expression_reguliere["titre"].Groups[1].Value, expression_reguliere["acteures"].Groups[1].Value, expression_reguliere["genre"].Groups[1].Value, expression_reguliere["pays"].Groups[1].Value, new Animer().formatage_duree(expression_reguliere["duree"].Groups[1].Value), expression_reguliere["creerpar"].Groups[2].Value, expression_reguliere["description"].Groups[2].Value, expression_reguliere["url_image"].Groups[1].Value, int.Parse(expression_reguliere["nbsaison"].Groups[1].Value), int.Parse(expression_reguliere["nbepisode"].Groups[1].Value), int.Parse(expression_reguliere["anneelancement"].Groups[1].Value));
                        (objet_categorie as Animer).Detail_animer = return_listeobjetfille(expression_reguliere_resultatmultiple["saison_episode_lien"], expression_reguliere_resultatmultiple["saison_episode_lien"].Count, (Animer)objet_categorie).Cast<Detail_animer>().ToList();
                        database.insertion_videos_videosseries_animer(objet_categorie.Titre, objet_categorie.Acteure, objet_categorie.Genre, objet_categorie.Pays, objet_categorie.Duree, objet_categorie.Creer_par, objet_categorie.Categorie, objet_categorie.Description, objet_categorie.Filefullname, int.Parse((objet_categorie as Animer).NBsaison.ToString()), int.Parse((objet_categorie as Animer).NBepisode.ToString()), int.Parse((objet_categorie as Animer).Annee_lancement.ToString()));
                        insertion_detail = () =>
                        {
                            foreach (Detail_animer item in (objet_categorie as Animer).Detail_animer)
                            {
                                database.insertion_animer_sommaireseries_detailanimer(objet_categorie.Titre,
                                    int.Parse(item.Saison.ToString()), int.Parse(item.Episode.ToString()), item.Lien);
                            }
                        };
                    }
                    insertion_detail();
                }
                else
                {
                    objet_categorie = new Films(expression_reguliere["titre"].Groups[1].Value, expression_reguliere["acteures"].Groups[1].Value, expression_reguliere["genre"].Groups[1].Value, expression_reguliere["pays"].Groups[1].Value, new Films().formatage_duree(expression_reguliere["duree"].Groups[1].Value), expression_reguliere["creerpar"].Groups[2].Value, expression_reguliere["description"].Groups[2].Value, expression_reguliere["url_image"].Groups[1].Value, int.Parse(expression_reguliere["anneeproduction"].Groups[1].Value), DateTime.Parse(Methodes_utilitaire.return_datesortie_formater_tostring(expression_reguliere["datesortie"].Groups[1].Value)), lienfilm);
                    database.insertion_videos_films(objet_categorie.Titre, objet_categorie.Acteure, objet_categorie.Genre, objet_categorie.Pays, objet_categorie.Duree, objet_categorie.Creer_par, objet_categorie.Categorie, objet_categorie.Description, objet_categorie.Filefullname, int.Parse((objet_categorie as Films).Anne_production.ToString()), (objet_categorie as Films).Date_sortie, (objet_categorie as Films).Lien);
                }
            }
            /* a revoir */
            catch (EntityCommandExecutionException exception_command_entity)
            {
                page_actuelle++;
                Task.Run(()=>lancement_chargement());
            }
        }

        private List<Sommaire_series> return_listeobjetfille(MatchCollection resultats_saisons_episodes_liens, int capaciter, Video_serie serie){
            List<Sommaire_series> resultats = new List<Sommaire_series>();
            if (serie as Series != null){
                for (var i = 0; i < capaciter; i++){
                    resultats.Add(new Detail_series((serie as Series).Titre, int.Parse(resultats_saisons_episodes_liens[i].Groups[2].Value), int.Parse(resultats_saisons_episodes_liens[i].Groups[3].Value), resultats_saisons_episodes_liens[i].Groups[1].Value, (Series)serie));
                }
            }
            else{
                for (var i = 0; i < capaciter; i++){
                    resultats.Add(new Detail_animer((serie as Animer).Titre, int.Parse(resultats_saisons_episodes_liens[i].Groups[2].Value), int.Parse(resultats_saisons_episodes_liens[i].Groups[3].Value), resultats_saisons_episodes_liens[i].Groups[1].Value, (Animer)serie));
                }
            }
            return resultats;
        }
 
        public void bt_fenetreprincipale_click(object sender,EventArgs e) {
            if (!recuperationencours){
                Minigestionnnaviguationformulaire.passage_formulaire_controlepardefault(this, new Fenetre_principale());
            }
        }

        private async void bt_lancementrecuperation_Click(object sender, EventArgs e){
            controle_timers(new System.Windows.Forms.Timer[] { timer_animation, duree_traitement, timer_redirection }, new Boolean[] { true, true, false });
            Task lancement = Task.Run(lancement_chargement);
            await lancement;
            controle_timers(new System.Windows.Forms.Timer[] { timer_animation, duree_traitement, timer_redirection }, new Boolean[] { false, false, true });
        }

        private void radiobutton_categorie_CheckedChanged(object sender){
            affectation_section(sender as MonoFlat_RadioButton,label_nom_section_recuperation);
        }


        private void formulaire_keydown(Object sender, KeyEventArgs e){
            Minigestionnnaviguationformulaire.sortie_formulaire(this, e, new Fenetre_principale());
        }

        private void timer_animation_Tick(object sender, EventArgs e){
            temps++;
            String caractere = "";
            if ((temps > 3)){
                temps = 1;
            }
            for (var i = 1; i <= temps; i++){
                caractere += ".";
            }
            label_nom_section_recuperation.Text = "Récupération des " + section + caractere;
        }

        private void timer_redirection_Tick(object sender, EventArgs e){
            if ((premierpassage)){
                temps = 4;
                premierpassage = false;
            }
            temps--;
            label_statistique.Text="Redirection dans " + temps;
            if ((temps == 0))
            {
                Minigestionnnaviguationformulaire.passage_formulaire_controlepardefault(this, new Fenetre_principale(section));
            }
        }

        private void duree_traitement_Tick(object sender, EventArgs e){   
            seconde_traitement++;
            if (seconde_traitement==60) {
                minute_traitement++;     
                if (minute_traitement==60) {
                    heure_traitement++;
                    minute_traitement = 0;
                }
                seconde_traitement = 0;
            }
            insertion_valeure_texte(new Label[] { label_valeure_seconde,label_valeure_minute , label_valeure_heure }, new String[] { seconde_traitement.ToString(), minute_traitement.ToString(), heure_traitement.ToString() });
        }
    }
}
