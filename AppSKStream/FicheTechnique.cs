using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AppSKStream
{
    public partial class FicheTechnique : Form
    {
        private readonly String image_erreur_chemincomplet;
        private List<Videos> liste_videos = null;
        private Videos video = null;
        private int ligne_naviguation = 0;

        public FicheTechnique()
        {
            InitializeComponent();
            image_erreur_chemincomplet = Application.StartupPath + @"\Images error\image_erreur.jpg";
        }

        public FicheTechnique(List<Videos> liste_videos, Videos video) :this()
        {
            this.liste_videos = liste_videos.OrderBy((item) => item.Categorie).ToList();
            this.video = video;            
        }

        private void changementetat_naviguation()
        {
            if (ligne_naviguation > liste_videos.Count - 1)
            {
                ligne_naviguation = 0;
            }
            else if (ligne_naviguation < 0)
            {
                ligne_naviguation = liste_videos.Count - 1;
            }
            verifie_image(liste_videos[ligne_naviguation].Filefullname);
            text_description.Text = liste_videos[ligne_naviguation].Description;
        }

        private void verifie_image(String chemin_fichier)
        {
            if (File.Exists(chemin_fichier))
            {
                picture_image.Image = Image.FromFile(chemin_fichier);
            }
            else
            {
                picture_image.Image = Image.FromFile(image_erreur_chemincomplet);
            }
        }

        private void changement_style_zone_exit(BorderStyle style) {
            panel_exit.BorderStyle = style;
            label_exit.BorderStyle = style;
            if (style == BorderStyle.Fixed3D) {
                label_exit.ForeColor = Color.DarkRed;
            } else if (style == BorderStyle.FixedSingle) {
                label_exit.ForeColor = Color.Black;
            }
        }
        private void FicheTechnique_Load(object sender, EventArgs e)
        {
            int iterateur = 0;
            liste_videos.ForEach((item)=> {
                if (item.Titre.ToUpper()==video?.Titre.ToUpper()){
                    ligne_naviguation = iterateur;
                }
                iterateur++;
            });
            text_description.Text = liste_videos[ligne_naviguation].Description;
            verifie_image(liste_videos[ligne_naviguation].Filefullname);
        }

        private void bt_precedent_Click(object sender, EventArgs e)
        {
            ligne_naviguation -= 1;
            changementetat_naviguation();
        }

        private void bt_suivant_Click(object sender, EventArgs e)
        {
            ligne_naviguation += 1;
            changementetat_naviguation();
        }

        private void enter_zone_exit(Object sender,EventArgs e)
        {
            changement_style_zone_exit(BorderStyle.Fixed3D);
        }

        private void leave_zone_exit(Object sender,EventArgs e){
            changement_style_zone_exit(BorderStyle.FixedSingle);
        }

        private void formulaire_KeyDown(object sender, KeyEventArgs e)
        {
            Minigestionnnaviguationformulaire.sortie_formulaire(this,e,new Fenetre_principale());
            if (e.KeyCode==Keys.Right || e.KeyCode==Keys.Left){
                if (e.KeyCode == Keys.Right){
                    ligne_naviguation++;
                }
                else{
                    ligne_naviguation--;
                }
                changementetat_naviguation();
            }
        }

        private void click_zone_exit(Object sender, EventArgs e)
        {
            this.Close();
        }
    } 
}