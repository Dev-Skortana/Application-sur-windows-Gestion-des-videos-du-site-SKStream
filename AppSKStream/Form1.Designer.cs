﻿namespace AppSKStream
{
    partial class Acceuille
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceuille));
            this.timer_animation = new System.Windows.Forms.Timer(this.components);
            this.timer_redirection = new System.Windows.Forms.Timer(this.components);
            this.duree_traitement = new System.Windows.Forms.Timer(this.components);
            this.Theme_acceuille = new MonoFlat.MonoFlat_ThemeContainer();
            this.label_valeure_minute = new MonoFlat.MonoFlat_Label();
            this.label_etiquette_minute = new MonoFlat.MonoFlat_Label();
            this.label_etiquette_heure = new MonoFlat.MonoFlat_Label();
            this.label_valeure_seconde = new MonoFlat.MonoFlat_Label();
            this.label_valeure_heure = new MonoFlat.MonoFlat_Label();
            this.label_etiquette_Seconde = new MonoFlat.MonoFlat_Label();
            this.bt_lancementrecuperation = new MonoFlat.MonoFlat_Button();
            this.bt_fenetreprincipale = new MonoFlat.MonoFlat_Button();
            this.label_statistique = new MonoFlat.MonoFlat_HeaderLabel();
            this.label_nom_section_recuperation = new MonoFlat.MonoFlat_HeaderLabel();
            this.Panel_option = new MonoFlat.MonoFlat_Panel();
            this.label_option = new MonoFlat.MonoFlat_HeaderLabel();
            this.radio_films = new MonoFlat.MonoFlat_RadioButton();
            this.radio_series = new MonoFlat.MonoFlat_RadioButton();
            this.radio_anime = new MonoFlat.MonoFlat_RadioButton();
            this.monoFlat_ControlBox1 = new MonoFlat.MonoFlat_ControlBox();
            this.Theme_acceuille.SuspendLayout();
            this.Panel_option.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_animation
            // 
            this.timer_animation.Interval = 1000;
            this.timer_animation.Tick += new System.EventHandler(this.timer_animation_Tick);
            // 
            // timer_redirection
            // 
            this.timer_redirection.Interval = 1000;
            this.timer_redirection.Tick += new System.EventHandler(this.timer_redirection_Tick);
            // 
            // duree_traitement
            // 
            this.duree_traitement.Interval = 1000;
            this.duree_traitement.Tick += new System.EventHandler(this.duree_traitement_Tick);
            // 
            // Theme_acceuille
            // 
            this.Theme_acceuille.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.Theme_acceuille.Controls.Add(this.label_valeure_minute);
            this.Theme_acceuille.Controls.Add(this.label_etiquette_minute);
            this.Theme_acceuille.Controls.Add(this.label_etiquette_heure);
            this.Theme_acceuille.Controls.Add(this.label_valeure_seconde);
            this.Theme_acceuille.Controls.Add(this.label_valeure_heure);
            this.Theme_acceuille.Controls.Add(this.label_etiquette_Seconde);
            this.Theme_acceuille.Controls.Add(this.bt_lancementrecuperation);
            this.Theme_acceuille.Controls.Add(this.bt_fenetreprincipale);
            this.Theme_acceuille.Controls.Add(this.label_statistique);
            this.Theme_acceuille.Controls.Add(this.label_nom_section_recuperation);
            this.Theme_acceuille.Controls.Add(this.Panel_option);
            this.Theme_acceuille.Controls.Add(this.monoFlat_ControlBox1);
            this.Theme_acceuille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Theme_acceuille.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Theme_acceuille.Location = new System.Drawing.Point(0, 0);
            this.Theme_acceuille.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Theme_acceuille.Name = "Theme_acceuille";
            this.Theme_acceuille.Padding = new System.Windows.Forms.Padding(13, 86, 13, 11);
            this.Theme_acceuille.RoundCorners = true;
            this.Theme_acceuille.Sizable = true;
            this.Theme_acceuille.Size = new System.Drawing.Size(989, 612);
            this.Theme_acceuille.SmartBounds = true;
            this.Theme_acceuille.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Theme_acceuille.TabIndex = 0;
            this.Theme_acceuille.Text = "Gestion des vidéos du site SKStream";
            // 
            // label_valeure_minute
            // 
            this.label_valeure_minute.AutoSize = true;
            this.label_valeure_minute.BackColor = System.Drawing.Color.Transparent;
            this.label_valeure_minute.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_valeure_minute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.label_valeure_minute.Location = new System.Drawing.Point(509, 438);
            this.label_valeure_minute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_valeure_minute.Name = "label_valeure_minute";
            this.label_valeure_minute.Size = new System.Drawing.Size(0, 20);
            this.label_valeure_minute.TabIndex = 19;
            // 
            // label_etiquette_minute
            // 
            this.label_etiquette_minute.AutoSize = true;
            this.label_etiquette_minute.BackColor = System.Drawing.Color.Transparent;
            this.label_etiquette_minute.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_etiquette_minute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.label_etiquette_minute.Location = new System.Drawing.Point(471, 411);
            this.label_etiquette_minute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_etiquette_minute.Name = "label_etiquette_minute";
            this.label_etiquette_minute.Size = new System.Drawing.Size(77, 20);
            this.label_etiquette_minute.TabIndex = 18;
            this.label_etiquette_minute.Text = "Minutes(s)";
            // 
            // label_etiquette_heure
            // 
            this.label_etiquette_heure.AutoSize = true;
            this.label_etiquette_heure.BackColor = System.Drawing.Color.Transparent;
            this.label_etiquette_heure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_etiquette_heure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.label_etiquette_heure.Location = new System.Drawing.Point(643, 411);
            this.label_etiquette_heure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_etiquette_heure.Name = "label_etiquette_heure";
            this.label_etiquette_heure.Size = new System.Drawing.Size(65, 20);
            this.label_etiquette_heure.TabIndex = 17;
            this.label_etiquette_heure.Text = "Heure(s)";
            // 
            // label_valeure_seconde
            // 
            this.label_valeure_seconde.AutoSize = true;
            this.label_valeure_seconde.BackColor = System.Drawing.Color.Transparent;
            this.label_valeure_seconde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_valeure_seconde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.label_valeure_seconde.Location = new System.Drawing.Point(348, 441);
            this.label_valeure_seconde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_valeure_seconde.Name = "label_valeure_seconde";
            this.label_valeure_seconde.Size = new System.Drawing.Size(0, 20);
            this.label_valeure_seconde.TabIndex = 16;
            // 
            // label_valeure_heure
            // 
            this.label_valeure_heure.AutoSize = true;
            this.label_valeure_heure.BackColor = System.Drawing.Color.Transparent;
            this.label_valeure_heure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_valeure_heure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.label_valeure_heure.Location = new System.Drawing.Point(672, 441);
            this.label_valeure_heure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_valeure_heure.Name = "label_valeure_heure";
            this.label_valeure_heure.Size = new System.Drawing.Size(0, 20);
            this.label_valeure_heure.TabIndex = 15;
            // 
            // label_etiquette_Seconde
            // 
            this.label_etiquette_Seconde.AutoSize = true;
            this.label_etiquette_Seconde.BackColor = System.Drawing.Color.Transparent;
            this.label_etiquette_Seconde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_etiquette_Seconde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.label_etiquette_Seconde.Location = new System.Drawing.Point(319, 411);
            this.label_etiquette_Seconde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_etiquette_Seconde.Name = "label_etiquette_Seconde";
            this.label_etiquette_Seconde.Size = new System.Drawing.Size(82, 20);
            this.label_etiquette_Seconde.TabIndex = 14;
            this.label_etiquette_Seconde.Text = "Seconde(s)";
            // 
            // bt_lancementrecuperation
            // 
            this.bt_lancementrecuperation.BackColor = System.Drawing.Color.Transparent;
            this.bt_lancementrecuperation.Enabled = false;
            this.bt_lancementrecuperation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_lancementrecuperation.Image = null;
            this.bt_lancementrecuperation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_lancementrecuperation.Location = new System.Drawing.Point(16, 497);
            this.bt_lancementrecuperation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_lancementrecuperation.Name = "bt_lancementrecuperation";
            this.bt_lancementrecuperation.Size = new System.Drawing.Size(953, 50);
            this.bt_lancementrecuperation.TabIndex = 12;
            this.bt_lancementrecuperation.Text = "Séléctionner une catégories de videos a charger ";
            this.bt_lancementrecuperation.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bt_lancementrecuperation.Click += new System.EventHandler(this.bt_lancementrecuperation_Click);
            // 
            // bt_fenetreprincipale
            // 
            this.bt_fenetreprincipale.BackColor = System.Drawing.Color.Transparent;
            this.bt_fenetreprincipale.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_fenetreprincipale.Image = null;
            this.bt_fenetreprincipale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_fenetreprincipale.Location = new System.Drawing.Point(17, 555);
            this.bt_fenetreprincipale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_fenetreprincipale.Name = "bt_fenetreprincipale";
            this.bt_fenetreprincipale.Size = new System.Drawing.Size(953, 50);
            this.bt_fenetreprincipale.TabIndex = 11;
            this.bt_fenetreprincipale.Text = "Home";
            this.bt_fenetreprincipale.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bt_fenetreprincipale.Click += new System.EventHandler(this.bt_fenetreprincipale_click);
            // 
            // label_statistique
            // 
            this.label_statistique.AutoSize = true;
            this.label_statistique.BackColor = System.Drawing.Color.Transparent;
            this.label_statistique.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_statistique.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label_statistique.Location = new System.Drawing.Point(357, 327);
            this.label_statistique.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_statistique.Name = "label_statistique";
            this.label_statistique.Size = new System.Drawing.Size(0, 37);
            this.label_statistique.TabIndex = 9;
            // 
            // label_nom_section_recuperation
            // 
            this.label_nom_section_recuperation.AutoSize = true;
            this.label_nom_section_recuperation.BackColor = System.Drawing.Color.Transparent;
            this.label_nom_section_recuperation.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nom_section_recuperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label_nom_section_recuperation.Location = new System.Drawing.Point(297, 247);
            this.label_nom_section_recuperation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_nom_section_recuperation.Name = "label_nom_section_recuperation";
            this.label_nom_section_recuperation.Size = new System.Drawing.Size(636, 37);
            this.label_nom_section_recuperation.TabIndex = 8;
            this.label_nom_section_recuperation.Text = "Séléctionner une catégories de videos a charger ";
            // 
            // Panel_option
            // 
            this.Panel_option.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.Panel_option.Controls.Add(this.label_option);
            this.Panel_option.Controls.Add(this.radio_films);
            this.Panel_option.Controls.Add(this.radio_series);
            this.Panel_option.Controls.Add(this.radio_anime);
            this.Panel_option.Location = new System.Drawing.Point(721, 90);
            this.Panel_option.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel_option.Name = "Panel_option";
            this.Panel_option.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Panel_option.Size = new System.Drawing.Size(253, 142);
            this.Panel_option.TabIndex = 6;
            this.Panel_option.Text = "monoFlat_Panel1";
            // 
            // label_option
            // 
            this.label_option.AutoSize = true;
            this.label_option.BackColor = System.Drawing.Color.Transparent;
            this.label_option.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label_option.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label_option.Location = new System.Drawing.Point(15, 9);
            this.label_option.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_option.Name = "label_option";
            this.label_option.Size = new System.Drawing.Size(212, 25);
            this.label_option.TabIndex = 6;
            this.label_option.Text = "Sélectionnez la section";
            // 
            // radio_films
            // 
            this.radio_films.Checked = false;
            this.radio_films.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_films.Location = new System.Drawing.Point(83, 41);
            this.radio_films.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radio_films.Name = "radio_films";
            this.radio_films.Size = new System.Drawing.Size(107, 17);
            this.radio_films.TabIndex = 1;
            this.radio_films.Text = "Films";
            this.radio_films.CheckedChanged += new MonoFlat.MonoFlat_RadioButton.CheckedChangedEventHandler(this.radiobutton_categorie_CheckedChanged);
            // 
            // radio_series
            // 
            this.radio_series.Checked = false;
            this.radio_series.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_series.Location = new System.Drawing.Point(83, 69);
            this.radio_series.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radio_series.Name = "radio_series";
            this.radio_series.Size = new System.Drawing.Size(111, 17);
            this.radio_series.TabIndex = 2;
            this.radio_series.Text = "Series";
            this.radio_series.CheckedChanged += new MonoFlat.MonoFlat_RadioButton.CheckedChangedEventHandler(this.radiobutton_categorie_CheckedChanged);
            // 
            // radio_anime
            // 
            this.radio_anime.Checked = false;
            this.radio_anime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_anime.Location = new System.Drawing.Point(84, 97);
            this.radio_anime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radio_anime.Name = "radio_anime";
            this.radio_anime.Size = new System.Drawing.Size(121, 17);
            this.radio_anime.TabIndex = 3;
            this.radio_anime.Text = "Mangas";
            this.radio_anime.CheckedChanged += new MonoFlat.MonoFlat_RadioButton.CheckedChangedEventHandler(this.radiobutton_categorie_CheckedChanged);
            // 
            // monoFlat_ControlBox1
            // 
            this.monoFlat_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monoFlat_ControlBox1.EnableHoverHighlight = false;
            this.monoFlat_ControlBox1.EnableMaximizeButton = true;
            this.monoFlat_ControlBox1.EnableMinimizeButton = true;
            this.monoFlat_ControlBox1.Location = new System.Drawing.Point(840, 18);
            this.monoFlat_ControlBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monoFlat_ControlBox1.Name = "monoFlat_ControlBox1";
            this.monoFlat_ControlBox1.Size = new System.Drawing.Size(100, 25);
            this.monoFlat_ControlBox1.TabIndex = 0;
            this.monoFlat_ControlBox1.Text = "monoFlat_ControlBox1";
            // 
            // Acceuille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 612);
            this.Controls.Add(this.Theme_acceuille);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Acceuille";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des vidéos du site SKStream";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formulaire_keydown);
            this.Theme_acceuille.ResumeLayout(false);
            this.Theme_acceuille.PerformLayout();
            this.Panel_option.ResumeLayout(false);
            this.Panel_option.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer Theme_acceuille;
        private MonoFlat.MonoFlat_ControlBox monoFlat_ControlBox1;
        private MonoFlat.MonoFlat_HeaderLabel label_statistique;
        private MonoFlat.MonoFlat_HeaderLabel label_nom_section_recuperation;
        private MonoFlat.MonoFlat_Panel Panel_option;
        private MonoFlat.MonoFlat_HeaderLabel label_option;
        private MonoFlat.MonoFlat_RadioButton radio_films;
        private MonoFlat.MonoFlat_RadioButton radio_series;
        private MonoFlat.MonoFlat_RadioButton radio_anime;
        private System.Windows.Forms.Timer timer_animation;
        private System.Windows.Forms.Timer timer_redirection;
        private MonoFlat.MonoFlat_Button bt_fenetreprincipale;
        private MonoFlat.MonoFlat_Button bt_lancementrecuperation;
        private MonoFlat.MonoFlat_Label label_valeure_minute;
        private MonoFlat.MonoFlat_Label label_etiquette_minute;
        private MonoFlat.MonoFlat_Label label_etiquette_heure;
        private MonoFlat.MonoFlat_Label label_valeure_seconde;
        private MonoFlat.MonoFlat_Label label_valeure_heure;
        private MonoFlat.MonoFlat_Label label_etiquette_Seconde;
        private System.Windows.Forms.Timer duree_traitement;
    }
}
