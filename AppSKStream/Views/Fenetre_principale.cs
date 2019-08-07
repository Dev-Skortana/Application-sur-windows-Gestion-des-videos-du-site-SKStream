using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using AppSKStream.Services.Interfaces;
using AppSKStream.Services.Classes;
using MonoFlat;
using AppSKStream.Classes_metier;
using AppSKStream.Helpers;

namespace AppSKStream.Views
{
    public partial class Fenetre_principale : Form
    {
        private INotificationchargemetfrom_database notification;
        private String categorievideo,type_recherche;
        private const String BOUTON_TEXT_RECHERCHEMULTIPLE = "Afficher les enregistrements de l'onglet ",FORMAT_DUREE=@"HH:mm:ss", FORMAT_DATE= @"dd/MM/yyyy",RECHERCHE_SIMPLE= "recherche simple", RECHERCHE_MULTIPLE= "recherche multiple";
        public delegate Task methodetask();

        public Fenetre_principale()
        {
           InitializeComponent();
           notification = new Notification_changementfrom_database_image(animation__chargementfrom_database);
        }

        public Fenetre_principale(String typevideo):this()
        {
            this.categorievideo = typevideo;
        }

        public async Task procedure_signalement_chargement(methodetask methode)
        {
            
            notification.signalement_chargement();
            await methode().ConfigureAwait(true);
            notification.arret_signalement_chargement();
        }

        private void definition_text_bouton_recherchemultiple(Control bouton,String libelle_onglet_actuelle,Char separateur_gauche='[',Char separateur_droite=']')
        {
            if (char.IsWhiteSpace(separateur_gauche) || char.IsWhiteSpace(separateur_droite))
            {
                separateur_gauche = '[';
                separateur_droite = ']';
            }
            bouton.Text = BOUTON_TEXT_RECHERCHEMULTIPLE + separateur_gauche + libelle_onglet_actuelle + separateur_droite;
        }

        private void verification_redirection_ongletoption(TabControl tabcontrolitems, TabControl tabcontroloptions, TabPage tabpageitems, MonoFlat_Panel panel_aactiver)
        {
            tabcontrolitems.SelectedTab = tabpageitems;
            tabcontroloptions.SelectedIndex = tabcontrolitems.SelectedIndex;
            MonoFlat_Panel[] panels_options = new MonoFlat_Panel[] { panel_option_videos, panel_option_videosseries, panel_option_films, panel_option_series, panel_option_animer, panel_option_detailanimer, panel_option_detailseries };
            panel_aactiver.Enabled = true;
            foreach (MonoFlat_Panel panel in panels_options) {
                if (panel.Name != panel_aactiver.Name) {
                    panel.Enabled = false;
                }
            }
        }

        private async Task traitement_affichageby_selected(String nom_table,Dictionary<String,String> dictionaire_critere, String nom_operateure = "=")
        {
            if (nom_table.ToUpper() == "videos".ToUpper())
            {
                dg_consultation_videos.DataSource = (from item in await new Videos(new Service_Video()).liste_videos_selon_criteres(dictionaire_critere, nom_operateure) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteure = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genre = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Vidéos = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Categorie = Methodes_utilitaire.affectation_donneesformater(item.Categorie) }).ToList();           
                get_count_allrows_ofdatagrid(dg_consultation_videos);
            }
            else if (nom_table.ToUpper() == "videosseries".ToUpper())
            {
                dg_consultation_videosseries.DataSource = (from item in await new Video_serie(new Service_Video_serie()).liste_videosseries_selon_criteres(dictionaire_critere, nom_operateure) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteures = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genres = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Videosseries = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), NBsaison = Methodes_utilitaire.affectation_donneesformater(item.NBsaison), NBepisode = Methodes_utilitaire.affectation_donneesformater(item.NBepisode), Annee_lancement = Methodes_utilitaire.affectation_donneesformater(item.Annee_lancement), Categorie = Methodes_utilitaire.affectation_donneesformater(item.Categorie) }).ToList();
            }
            else if (nom_table.ToUpper() == "films".ToUpper())
            {
                dg_consultation_films.DataSource = (from item in await new Films(new Service_Film()).liste_films_selon_criteres(dictionaire_critere, nom_operateure) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteures = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genres = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Films = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Annee_Production = Methodes_utilitaire.affectation_donneesformater(item.Anne_production), Date_Sortie = Methodes_utilitaire.affectation_donneesformater(item.Date_sortie), Lien = Methodes_utilitaire.affectation_donneesformater(item.Lien) }).ToList();
            }
            else if (nom_table.ToUpper() == "series".ToUpper())
            {
               dg_consultation_series.DataSource = (from item in await new Series(new Service_serie()).liste_series_selon_criteres(dictionaire_critere, nom_operateure) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteures = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genres = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Series = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Nombre_Saison = Methodes_utilitaire.affectation_donneesformater(item.NBsaison), Nombre_Episode = Methodes_utilitaire.affectation_donneesformater(item.NBepisode), Annee_Lancement = Methodes_utilitaire.affectation_donneesformater(item.Annee_lancement) }).ToList();
            }
            else if (nom_table.ToUpper() == "animer".ToUpper())
            {
                dg_consultation_animer.DataSource = (from item in await new Animer(new Service_animer()).liste_animer_selon_criteres(dictionaire_critere, nom_operateure) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteures = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genres = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Animer = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Nombre_Saison = Methodes_utilitaire.affectation_donneesformater(item.NBsaison), Nombre_Episode = Methodes_utilitaire.affectation_donneesformater(item.NBepisode), Annee_Lancement = Methodes_utilitaire.affectation_donneesformater(item.Annee_lancement) }).ToList();
            }
            else if (nom_table.ToUpper() == "detailseries".ToUpper())
            {
                dg_consultation_detailseries.DataSource = (from item in await new Detail_series(new Service_Detailserie()).liste_detailseries_selon_criteres(dictionaire_critere, nom_operateure) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Saison = Methodes_utilitaire.affectation_donneesformater(item.Saison), Episode = Methodes_utilitaire.affectation_donneesformater(item.Episode), Lien = Methodes_utilitaire.affectation_donneesformater(item.Lien) }).ToList();
            }
            else if (nom_table.ToUpper() == "detailanimer".ToUpper())
            {
                dg_consultation_detailanimer.DataSource = (from item in await new Detail_animer(new Service_Detailanimer()).liste_detailanimer_selon_criteres(dictionaire_critere, nom_operateure) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Saison = Methodes_utilitaire.affectation_donneesformater(item.Saison), Episode = Methodes_utilitaire.affectation_donneesformater(item.Episode), Lien = Methodes_utilitaire.affectation_donneesformater(item.Lien) }).ToList();
            }
        }
       
        private DataGridView return_datagrid(String nomrecherchetabpage){
            DataGridView resultat = null;
            DataGridView[] pages = new DataGridView[] { dg_consultation_videos, dg_consultation_videosseries, dg_consultation_films, dg_consultation_series, dg_consultation_animer, dg_consultation_detailseries, dg_consultation_detailanimer };
            resultat = (from el in pages where el.Name.Split('_')[2].ToUpper() == nomrecherchetabpage.Split('_')[1].ToUpper() select el).First();
            return resultat;
        }


        private void delete_donneesdatagrid_selected(String nameselectedtabpage) {
            DataGridView datagrid = return_datagrid(nameselectedtabpage);
            datagrid.DataSource = null;
        }

        private void delete_donneesdatagrid_all() {
            DataGridView[] liste_datagridview = new DataGridView[] { dg_consultation_videos,dg_consultation_videosseries, dg_consultation_films , dg_consultation_series, dg_consultation_animer, dg_consultation_detailseries, dg_consultation_detailanimer };
            foreach (DataGridView item in liste_datagridview)
            {
                item.DataSource = null;
            }
        }
       
        private async Task select_donnees_for_datagrid_allresult_formluncher()
        {
            if (categorievideo != null)
            {
                dg_consultation_videos.DataSource = (from item in await new Videos(new Service_Video()).liste_videos_selon_criteres(new Dictionary<String, String>() { }) orderby item.Titre select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteure = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genre = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Vidéos = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Categorie = Methodes_utilitaire.affectation_donneesformater(item.Categorie) }).ToList();
                if (categorievideo.Contains("films"))
                {
                    dg_consultation_films.DataSource = (from item in await new Films(new Service_Film()).liste_films_selon_criteres(new Dictionary<String, String>() { }) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteures = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genres = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Film = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Annee_Production = Methodes_utilitaire.affectation_donneesformater(item.Anne_production), Date_Sortie = Methodes_utilitaire.affectation_donneesformater(item.Date_sortie), Lien = Methodes_utilitaire.affectation_donneesformater(item.Lien) }).ToList();
                    verification_redirection_ongletoption(listepage_items, listepage_options, onglet_films, panel_option_films);
                }
                else
                {
                    dg_consultation_videosseries.DataSource = (from item in await new Video_serie(new Service_Video_serie()).liste_videosseries_selon_criteres(new Dictionary<String, String>() { }) orderby item.Titre select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteure = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genre = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Vidéosérie = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Categorie = Methodes_utilitaire.affectation_donneesformater(item.Categorie), Nombre_Saison = Methodes_utilitaire.affectation_donneesformater(item.NBsaison), Nombre_Episode = Methodes_utilitaire.affectation_donneesformater(item.NBepisode), Annee_Lancement = Methodes_utilitaire.affectation_donneesformater(item.Annee_lancement) }).ToList();
                    if (categorievideo.Contains("series"))
                    {
                        dg_consultation_series.DataSource = (from item in await new Series(new Service_serie()).liste_series_selon_criteres(new Dictionary<String, String>() { }) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteures = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genres = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Serie = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Nombre_Saison = Methodes_utilitaire.affectation_donneesformater(item.NBsaison), Nombre_Episode = Methodes_utilitaire.affectation_donneesformater(item.NBepisode), Annee_Lancement = Methodes_utilitaire.affectation_donneesformater(item.Annee_lancement) }).ToList();
                        dg_consultation_detailseries.DataSource = (from item in await new Detail_series(new Service_Detailserie()).liste_detailseries_selon_criteres(new Dictionary<String, String>() { }) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Saison = Methodes_utilitaire.affectation_donneesformater(item.Saison), Episode = Methodes_utilitaire.affectation_donneesformater(item.Episode), Lien = Methodes_utilitaire.affectation_donneesformater(item.Lien) }).ToList();
                        verification_redirection_ongletoption(listepage_items, listepage_options, onglet_series, panel_option_series);
                    }
                    else
                    {
                        dg_consultation_animer.DataSource = (from item in await new Animer(new Service_animer()).liste_animer_selon_criteres(new Dictionary<String, String>() { }) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Acteure = Methodes_utilitaire.affectation_donneesformater(item.Acteure), Genres = Methodes_utilitaire.affectation_donneesformater(item.Genre), Pays = Methodes_utilitaire.affectation_donneesformater(item.Pays), Duree_Animer = Methodes_utilitaire.affectation_donneesformater(item.Duree), Realisateures = Methodes_utilitaire.affectation_donneesformater(item.Creer_par), Nombre_Saison = Methodes_utilitaire.affectation_donneesformater(item.NBsaison), Nombre_Episode = Methodes_utilitaire.affectation_donneesformater(item.NBepisode), Annee_Lancement = Methodes_utilitaire.affectation_donneesformater(item.Annee_lancement) }).ToList();
                        dg_consultation_detailanimer.DataSource = (from item in await new Detail_animer(new Service_Detailanimer()).liste_detailanimer_selon_criteres(new Dictionary<String, String>() { }) orderby item.Titre ascending select new { Titre = Methodes_utilitaire.affectation_donneesformater(item.Titre), Saison = Methodes_utilitaire.affectation_donneesformater(item.Saison), Episode = Methodes_utilitaire.affectation_donneesformater(item.Episode), Lien = Methodes_utilitaire.affectation_donneesformater(item.Lien) }).ToList();
                        verification_redirection_ongletoption(listepage_items, listepage_options, onglet_animer, panel_option_animer);
                    }
                }
            }
        }

        private async Task select_donnees_for_datagrid_allormultipleresult() {
            if (type_recherche.ToUpper()==RECHERCHE_MULTIPLE.ToUpper()){
                String item_nom_ongletactuelleactive = bt_affichage.Text;
                List<TabControl> liste_tabcontrole = new List<TabControl> { listepage_controle_videos, listepage_controle_videosseries, listepage_controle_films, listepage_controle_series, listepage_controle_animer, listepage_controle_detailanimer, listepage_controle_detailseries };
                TabControl tabcontrole_active = (TabControl)(from item in liste_tabcontrole where item.Name.Split('_')[2].ToUpper() == item_nom_ongletactuelleactive.Split('[')[1].Split(']')[0].Split('_')[1].ToUpper() select item).FirstOrDefault();
                List<Control> liste_controle_saisie = new List<Control>();
                for (int i = 0; i < tabcontrole_active.TabPages.Count; i++)
                {
                    liste_controle_saisie.Add((Control)(from panel in tabcontrole_active.TabPages[i].Controls.Cast<Object>().ToList() where panel as MonoFlat_Panel != null select (from textbox in (panel as MonoFlat_Panel).Controls.Cast<Object>().ToList() where textbox as TextBox != null || textbox as DateTimePicker != null || textbox as NumericUpDown != null || textbox as MaskedTextBox != null select textbox as Control).First()).First());
                }
                List<Control> liste_controlesaisie_active = (from item in liste_controle_saisie where (item as TextBox != null && !String.IsNullOrEmpty((item as TextBox).Text)) || (item as DateTimePicker != null && (item as DateTimePicker).CustomFormat != " ") || (item as NumericUpDown != null && (item as NumericUpDown).Value != 0) || (item as MaskedTextBox != null && !String.IsNullOrWhiteSpace((item as MaskedTextBox).Text.Replace(":", ""))) select item).DefaultIfEmpty().ToList<Control>();
                List<String> valeurs_controle = liste_controlesaisie_active[0] != null ? (from item in liste_controlesaisie_active select item as DateTimePicker != null && (item as DateTimePicker).Name.Split('_')[1].ToUpper() != "duree".ToUpper() ? (item as DateTimePicker).Value.ToString("dd/mm/yyyy") : (item as DateTimePicker != null && (item as DateTimePicker).Name.Split('_')[1].ToUpper() == "duree".ToUpper() ? (item as DateTimePicker).Value.ToString("HH:mm:ss") : (item as Control).Text)).ToList<String>() : new List<string>();
                List<String> champs = liste_controlesaisie_active[0] != null ? (from item in liste_controlesaisie_active select item.Name.Split('_')[1]).ToList<String>() : new List<string>();                       
                Dictionary<String, String> dictionnaire_critere = new Dictionary<string, string>();
                if (liste_controlesaisie_active[0] != null)
                {
                    for (var i = 0; i < champs.Count; i++) { dictionnaire_critere.Add(champs[i], valeurs_controle[i]); }
                }
                 await traitement_affichageby_selected(item_nom_ongletactuelleactive.Split('[')[1].Split('_')[1].Split(']')[0],dictionnaire_critere, "like").ConfigureAwait(true);
            }
        }

        private async Task select_donnees_for_datagridmultipleresultat(Object sender,String nom_table,String nom_champ){
            if (sender as DateTimePicker != null && (sender as DateTimePicker).CustomFormat == " "){
                (sender as DateTimePicker).CustomFormat = (sender as Control).Name.Split('_')[1].ToUpper() == "duree".ToUpper() ? FORMAT_DUREE: FORMAT_DATE;
            }
            if (type_recherche.ToUpper() == RECHERCHE_SIMPLE.ToUpper())
            {
                await traitement_affichageby_selected(nom_table, new Dictionary<string, string>(){{nom_champ ,sender as DateTimePicker != null && (sender as DateTimePicker).Name.Split('_')[1].ToUpper() != "duree".ToUpper() ? (sender as DateTimePicker).Value.ToString("yyyy/MM/dd") : (sender as NumericUpDown != null ? (sender as NumericUpDown).Value.ToString() : (sender as Control).Text)}},"like").ConfigureAwait(true);
            }
        }
        private void get_count_allrows_ofdatagrid(DataGridView data)
        {
            String count_enregistrement =$"{data.RowCount.ToString()} ";
            if (data.RowCount==0)
            {
                count_enregistrement=$"Aucun enregistrement";
            }else if (data.RowCount==1)
            {
                count_enregistrement += $"Enregistrement";
            }
            else
            {
                count_enregistrement += $"Enregistrements";
            }
            count_allrows_ofdatagridview.Text = count_enregistrement;
        }
        

        private async void Fenetre_principale_Load(object sender, EventArgs e)
        {
            cb_typerecherche.SelectedIndex = 0;
            procedure_signalement_chargement(select_donnees_for_datagrid_allresult_formluncher);
            definition_text_bouton_recherchemultiple(bt_affichage, listepage_items.SelectedTab.Name);
        }

        private void listepage_items_Selecting(object sender, TabControlCancelEventArgs e)
        {
            verification_redirection_ongletoption(listepage_items, listepage_options, e.TabPage, listepage_options.TabPages.Cast<TabPage>().ToList().Find((item) => item.Name.Split('_')[2].ToUpper() == listepage_items.SelectedTab.Name.Split('_')[1].ToUpper()).Controls.Cast<Control>().ToList().Find((item) => item as MonoFlat_ThemeContainer != null).Controls.Cast<Control>().ToList().Find((item) => item.Name.Substring(0, item.Name.LastIndexOf('_')) == "panel_option") as MonoFlat_Panel);
            definition_text_bouton_recherchemultiple(bt_affichage, e.TabPage.Name);
        }

        private void rénitialiserLesListesToolStripMenuItem_Click(object sender, EventArgs e)
        {
                delete_donneesdatagrid_all();
        }

        private void rénitialiserLaListeSelectionnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
                delete_donneesdatagrid_selected(listepage_items.SelectedTab.Name);
        }

        private async void voirLaFicheDeLonglerSelectionnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView datagrid = return_datagrid(listepage_items.SelectedTab.Name);
            if ((datagrid.DataSource!=null) && (datagrid.RowCount>0))
            { 
                List<Videos> videos =(from item in await new Videos(new Service_Video()).liste_videos_selon_criteres(new Dictionary<String,String>()) orderby item.Titre ascending select item).ToList();
                Videos video_selected = (from item in await new Videos(new Service_Video()).liste_videos_selon_criteres(new Dictionary<String,String>()) where item.Titre == datagrid?.CurrentRow?.Cells[0]?.Value.ToString() select item).FirstOrDefault();
                new FicheTechnique(videos, video_selected).ShowDialog();
            }
        }

        private void ckb_options_CheckedChanged(object sender)
        {         
            MonoFlat_CheckBox checkbox = (MonoFlat_CheckBox)sender;
            if (checkbox.Checked){
                if (type_recherche.ToUpper() == RECHERCHE_SIMPLE.ToUpper()){
                    GroupBox groupebox_checkbox = (from item in listepage_options.SelectedTab.Controls.Cast<Object>().ToList() where item as MonoFlat_ThemeContainer != null select (from sousitem in (item as MonoFlat_ThemeContainer).Controls.Cast<Object>().ToList() where sousitem as MonoFlat_Panel != null select (from soussousitem in (sousitem as MonoFlat_Panel).Controls.Cast<Object>().ToList() where soussousitem as GroupBox != null && (soussousitem as GroupBox).Name.Substring(0, (soussousitem as GroupBox).Name.LastIndexOf('_')).ToUpper() == "gb_recherchemultiple".ToUpper() select soussousitem as GroupBox).First()).First()).First();
                    List<MonoFlat_CheckBox> liste_checkbox = (from item in groupebox_checkbox.Controls.Cast<Object>().ToList() where item as MonoFlat_CheckBox != null select item as MonoFlat_CheckBox).ToList();
                    liste_checkbox.Remove(checkbox);
                    liste_checkbox.ForEach((item) => { item.Checked = false; });
                }
                String nom_tabcontrole = checkbox.Name.Split('_')[2];
                String nom_recherche = checkbox.Name.Split('_')[1];
                TabControl[] liste_tabcontroles = new TabControl[] { listepage_controle_videos, listepage_controle_videosseries, listepage_controle_films, listepage_controle_series, listepage_controle_animer, listepage_controle_detailanimer, listepage_controle_detailseries };
                var tabcontrole = (from el in liste_tabcontroles.Cast<Object>().ToList() where (el as TabControl).Name.Split('_')[2].ToUpper()==nom_tabcontrole.ToUpper() select el as TabControl).First();
                var tabpage = (from el in tabcontrole.TabPages.Cast<Object>().ToList() where (el as TabPage).Name.Split('_')[2].ToUpper()==nom_recherche.ToUpper() select el as TabPage).First();
                tabcontrole.SelectedTab = tabpage;
                Control saisie = tabcontrole.SelectedTab.Controls.Find("text_" + tabcontrole.SelectedTab.Name.Split('_')[2] + "_" + tabcontrole.SelectedTab.Name.Split('_')[3] ,true).First();
                saisie.Focus();
            }
        }
        private async void bt_affichage_click(Object sender, EventArgs e)
        {
            if (type_recherche.ToUpper() == RECHERCHE_MULTIPLE.ToUpper())
            {
               procedure_signalement_chargement(select_donnees_for_datagrid_allormultipleresult);
            }
        }

        private async void text_recherche_simple_TextChanged(Object sender,EventArgs e) {
            if (type_recherche.ToUpper() == RECHERCHE_SIMPLE.ToUpper())
            {
                procedure_signalement_chargement(()=>select_donnees_for_datagridmultipleresultat(sender, (sender as Control).Name.Split('_')[2], (sender as Control).Name.Split('_')[1]));
            }
        }

        private async void keydown_formulaire(Object sender,KeyEventArgs e) {
            Minigestionnnaviguationformulaire.sortie_formulaire(this,e,new Acceuille());
            if (e.KeyCode==Keys.F1) {
                cb_typerecherche.SelectedIndex = 0;
            } else if (e.KeyCode==Keys.F2) {
                cb_typerecherche.SelectedIndex = 1;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) {
                delete_donneesdatagrid_all();
            } else if (e.KeyCode == Keys.Delete) {
                delete_donneesdatagrid_selected(listepage_items.SelectedTab.Name);
            } else if (e.KeyCode == Keys.Enter && type_recherche.ToUpper()==RECHERCHE_MULTIPLE.ToUpper()) {
                procedure_signalement_chargement((methodetask)select_donnees_for_datagrid_allormultipleresult);
            } else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) {
                Control objetsaisie =
                    (from item in listepage_options.SelectedTab.Controls.Cast<Object>().ToList()
                        where item as MonoFlat_ThemeContainer != null
                        select (from sousitem in (item as MonoFlat_ThemeContainer).Controls.Cast<Object>().ToList()
                            where sousitem as MonoFlat_Panel != null
                            select (from soussousitem in (sousitem as MonoFlat_Panel).Controls.Cast<Object>().ToList() where soussousitem as GroupBox != null && (soussousitem as GroupBox).Name.StartsWith("gb_saisie") select (from soussoussousitem in (soussousitem as GroupBox).Controls.Cast<Object>().ToList() where soussoussousitem as TabControl != null select (from soussoussoussousitem in (soussoussousitem as TabControl).SelectedTab.Controls.Cast<Object>().ToList() where soussoussoussousitem as MonoFlat_Panel != null select (from soussoussoussoussousitem in (soussoussoussousitem as MonoFlat_Panel).Controls.Cast<Object>().ToList() where (soussoussoussoussousitem as Control).Name.StartsWith("text") select soussoussoussoussousitem as Control).First()).First()).First()).First()).First()).First();
                if (!objetsaisie.Focused)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        listepage_items.SelectedIndex = listepage_items.SelectedIndex > 0 ? listepage_items.SelectedIndex - 1 : listepage_items.TabPages.Count - 1;
                    }
                    else
                    {
                        listepage_items.SelectedIndex = listepage_items.SelectedIndex < listepage_items.TabCount - 1 ? listepage_items.SelectedIndex + 1 : 0;
                    }
                }
            }
        }

        private void bt_remisezero_datetime_Click(object sender, EventArgs e)
        {
            Control button = (sender as Control);
            DateTimePicker objet_datetimepiker = (from item in listepage_options.SelectedTab.Controls.Cast<Object>().ToList() where item as MonoFlat_ThemeContainer != null select (from sousitem in (item as MonoFlat_ThemeContainer).Controls.Cast<Object>().ToList() where sousitem as MonoFlat_Panel != null select (from soussousitem in (sousitem as MonoFlat_Panel).Controls.Cast<Object>().ToList() where soussousitem as GroupBox != null && (soussousitem as GroupBox).Name.Substring(0, (soussousitem as GroupBox).Name.LastIndexOf('_')).ToUpper() == "gb_saisie".ToUpper() select (from soussoussousitem in (soussousitem as GroupBox).Controls.Cast<Object>().ToList() where soussoussousitem as TabControl != null select (from soussoussoussousitem in (soussoussousitem as TabControl).SelectedTab.Controls.Cast<Object>().ToList() where soussoussoussousitem as MonoFlat_Panel != null select (from soussoussoussoussousitem in (soussoussoussousitem as MonoFlat_Panel).Controls.Cast<Object>().ToList() where soussoussoussoussousitem as DateTimePicker != null select soussoussoussoussousitem as DateTimePicker).First()).First()).First()).First()).First()).First();
            if (objet_datetimepiker.Name.Split('_')[1].ToUpper() == "duree".ToUpper() && button.Text.ToUpper()=="Remettre une valeur".ToUpper())
            {
                objet_datetimepiker.CustomFormat = FORMAT_DUREE;
                button.Text = "Remettre à zéro";
            }
            else{
                objet_datetimepiker.CustomFormat = " ";
                button.Text = objet_datetimepiker.Name.Split('_')[1].ToUpper() == "duree".ToUpper() ? "Remettre une valeur" : button.Text;
            }
        }

        private void datagridview_rowselected(Object sender, DataGridViewCellMouseEventArgs e)
        {
            String nom_table = bt_affichage.Text.Split('[')[1].Split('_')[1].Split(']')[0];
            String url_selected = (from control_tabcontrol in listepage_items.Controls.Cast<Object>().ToList() where (control_tabcontrol as TabPage != null && (control_tabcontrol as TabPage).Name.Split('_')[1].ToUpper() == nom_table.ToUpper()) select (from themecontenaire in (control_tabcontrol as TabPage).Controls.Cast<Object>().ToList() where themecontenaire as MonoFlat_ThemeContainer != null select (from datagrid in (themecontenaire as MonoFlat_ThemeContainer).Controls.Cast<Object>().ToList() where (datagrid as DataGridView != null && (datagrid as DataGridView).Name.Split('_')[2].ToUpper() == nom_table.ToUpper()) select (datagrid as DataGridView).CurrentRow.Cells["Lien"].Value.ToString()).First()).First()).First();
            new Task(()=> {
                String arguments_lignecmd = Process.GetProcessesByName("chrome").Length > 0 ? "\"" + url_selected + "\"" : "--new-window \"" + url_selected + "\"";
                Process.Start("chrome", arguments_lignecmd);
            }).Start();
        }

        private void ChargementvideostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "En quitter ce formulaire vous allez étre rediriger vers la page de chargement des videos voulez-vous vraiment continuer ?", "Message de confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Minigestionnnaviguationformulaire.passage_formulaire_controlepardefault(this, new Acceuille());
            }
        }

        private void datagrid_clear_row_selected(object sender, DataGridViewRowsAddedEventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }

        private void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = (sender as ComboBox);
            if (combobox.SelectedItem.ToString().ToUpper() == "Recherche simple [F1]".ToUpper())
            {
                type_recherche = RECHERCHE_SIMPLE;
            }
            else if (combobox.SelectedItem.ToString().ToUpper()== "Recherche multiple [F2]".ToUpper())
            {
                type_recherche = RECHERCHE_MULTIPLE;
            }
            bt_affichage.Enabled = (type_recherche.ToUpper() != RECHERCHE_SIMPLE.ToUpper());
        }

        private async void deleteall_rows_database(Object sender,EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment supprimer toutes les videos ?\n\n\n [Attention !!! cette action est irreversible]","Suppression de toutes les videos",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2)==System.Windows.Forms.DialogResult.Yes)
            {
                Boolean reponse_delete=await new Videos(new Service_Video()).delete(new Dictionary<string, string>());
                if (reponse_delete)
                {
                    await new Gestion_video_skstreamContainer().Database.ExecuteSqlCommandAsync("delete from Sommaire_seriesSet");
                    delete_donneesdatagrid_all();
                }
                MessageBox.Show(reponse_delete ? "L'action a été exécuter avec succées" : "L'action na pas pu étre  exécuter avec succées", "Réponse");
            }
        }

        private void bt_exit_clicked(Object sender, EventArgs e)
        {
            Application.Exit();
        } 
    }
}
