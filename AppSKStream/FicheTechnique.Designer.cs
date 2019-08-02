﻿namespace AppSKStream
{
    partial class FicheTechnique
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheTechnique));
            this.monoFlatThemeContainer_fichetechnique = new MonoFlat.MonoFlat_ThemeContainer();
            this.panel_exit = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.bt_precedent = new MonoFlat.MonoFlat_Button();
            this.bt_suivant = new MonoFlat.MonoFlat_Button();
            this.panel_description = new System.Windows.Forms.Panel();
            this.text_description = new System.Windows.Forms.RichTextBox();
            this.panel_image = new System.Windows.Forms.Panel();
            this.picture_image = new System.Windows.Forms.PictureBox();
            this.monoFlatThemeContainer_fichetechnique.SuspendLayout();
            this.panel_exit.SuspendLayout();
            this.panel_description.SuspendLayout();
            this.panel_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).BeginInit();
            this.SuspendLayout();
            // 
            // monoFlatThemeContainer_fichetechnique
            // 
            this.monoFlatThemeContainer_fichetechnique.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlatThemeContainer_fichetechnique.Controls.Add(this.panel_exit);
            this.monoFlatThemeContainer_fichetechnique.Controls.Add(this.bt_precedent);
            this.monoFlatThemeContainer_fichetechnique.Controls.Add(this.bt_suivant);
            this.monoFlatThemeContainer_fichetechnique.Controls.Add(this.panel_description);
            this.monoFlatThemeContainer_fichetechnique.Controls.Add(this.panel_image);
            this.monoFlatThemeContainer_fichetechnique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monoFlatThemeContainer_fichetechnique.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monoFlatThemeContainer_fichetechnique.Location = new System.Drawing.Point(0, 0);
            this.monoFlatThemeContainer_fichetechnique.Name = "monoFlatThemeContainer_fichetechnique";
            this.monoFlatThemeContainer_fichetechnique.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.monoFlatThemeContainer_fichetechnique.RoundCorners = true;
            this.monoFlatThemeContainer_fichetechnique.Sizable = true;
            this.monoFlatThemeContainer_fichetechnique.Size = new System.Drawing.Size(1055, 711);
            this.monoFlatThemeContainer_fichetechnique.SmartBounds = true;
            this.monoFlatThemeContainer_fichetechnique.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.monoFlatThemeContainer_fichetechnique.TabIndex = 0;
            this.monoFlatThemeContainer_fichetechnique.Text = "Fiche technique";
            // 
            // panel_exit
            // 
            this.panel_exit.BackColor = System.Drawing.Color.Transparent;
            this.panel_exit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_exit.Controls.Add(this.label_exit);
            this.panel_exit.Location = new System.Drawing.Point(960, 1);
            this.panel_exit.Name = "panel_exit";
            this.panel_exit.Size = new System.Drawing.Size(91, 57);
            this.panel_exit.TabIndex = 5;
            this.panel_exit.Click += new System.EventHandler(this.click_zone_exit);
            this.panel_exit.MouseEnter += new System.EventHandler(this.enter_zone_exit);
            this.panel_exit.MouseLeave += new System.EventHandler(this.leave_zone_exit);
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exit.Location = new System.Drawing.Point(26, 8);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(40, 43);
            this.label_exit.TabIndex = 0;
            this.label_exit.Text = "X";
            this.label_exit.Click += new System.EventHandler(this.click_zone_exit);
            this.label_exit.MouseEnter += new System.EventHandler(this.enter_zone_exit);
            // 
            // bt_precedent
            // 
            this.bt_precedent.BackColor = System.Drawing.Color.Transparent;
            this.bt_precedent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_precedent.Image = null;
            this.bt_precedent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_precedent.Location = new System.Drawing.Point(0, 63);
            this.bt_precedent.Name = "bt_precedent";
            this.bt_precedent.Size = new System.Drawing.Size(146, 41);
            this.bt_precedent.TabIndex = 4;
            this.bt_precedent.Text = "Précédent";
            this.bt_precedent.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bt_precedent.Click += new System.EventHandler(this.bt_precedent_Click);
            // 
            // bt_suivant
            // 
            this.bt_suivant.BackColor = System.Drawing.Color.Transparent;
            this.bt_suivant.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_suivant.Image = null;
            this.bt_suivant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_suivant.Location = new System.Drawing.Point(909, 63);
            this.bt_suivant.Name = "bt_suivant";
            this.bt_suivant.Size = new System.Drawing.Size(146, 41);
            this.bt_suivant.TabIndex = 3;
            this.bt_suivant.Text = "Suivant";
            this.bt_suivant.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bt_suivant.Click += new System.EventHandler(this.bt_suivant_Click);
            // 
            // panel_description
            // 
            this.panel_description.Controls.Add(this.text_description);
            this.panel_description.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_description.Location = new System.Drawing.Point(10, 441);
            this.panel_description.Name = "panel_description";
            this.panel_description.Size = new System.Drawing.Size(1035, 261);
            this.panel_description.TabIndex = 2;
            // 
            // text_description
            // 
            this.text_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.text_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_description.ForeColor = System.Drawing.Color.White;
            this.text_description.Location = new System.Drawing.Point(0, 0);
            this.text_description.Name = "text_description";
            this.text_description.Size = new System.Drawing.Size(1035, 261);
            this.text_description.TabIndex = 5;
            this.text_description.Text = "";
            // 
            // panel_image
            // 
            this.panel_image.Controls.Add(this.picture_image);
            this.panel_image.Location = new System.Drawing.Point(375, 80);
            this.panel_image.Name = "panel_image";
            this.panel_image.Size = new System.Drawing.Size(370, 348);
            this.panel_image.TabIndex = 1;
            // 
            // picture_image
            // 
            this.picture_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picture_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_image.Location = new System.Drawing.Point(0, 0);
            this.picture_image.Name = "picture_image";
            this.picture_image.Size = new System.Drawing.Size(370, 348);
            this.picture_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_image.TabIndex = 0;
            this.picture_image.TabStop = false;
            // 
            // FicheTechnique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 711);
            this.Controls.Add(this.monoFlatThemeContainer_fichetechnique);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FicheTechnique";
            this.Text = "Fiche technique";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.FicheTechnique_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formulaire_KeyDown);
            this.monoFlatThemeContainer_fichetechnique.ResumeLayout(false);
            this.panel_exit.ResumeLayout(false);
            this.panel_exit.PerformLayout();
            this.panel_description.ResumeLayout(false);
            this.panel_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picture_image;
        private System.Windows.Forms.Panel panel_image;
        private System.Windows.Forms.Panel panel_description;
        private MonoFlat.MonoFlat_Button bt_precedent;
        private MonoFlat.MonoFlat_Button bt_suivant;
        private System.Windows.Forms.RichTextBox text_description;
        private System.Windows.Forms.Panel panel_exit;
        private System.Windows.Forms.Label label_exit;
        private MonoFlat.MonoFlat_ThemeContainer monoFlatThemeContainer_fichetechnique;
    }
}