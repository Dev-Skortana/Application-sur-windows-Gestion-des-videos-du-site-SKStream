using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSKStream.Services.Interfaces;

namespace AppSKStream.Services.Classes
{
    class Notification_changementfrom_database_image : INotificationchargemetfrom_database
    {
        public Image image { get; set; }
        public Notification_changementfrom_database_image(Control objet,String chemin_image_import=null) {
            this.objet_animation = objet;
            chemin_image_import = String.IsNullOrWhiteSpace(chemin_image_import) ? Application.StartupPath + @"\Image_chargement_from_database\CortanaAnimation.gif" : chemin_image_import;
            this.image =Image.FromFile(chemin_image_import);
        }

        public Control objet_animation
        {
            get;

            set;
        }

        public void signalement_chargement()
        {
            (this.objet_animation as PictureBox).BackgroundImage = image;
            (this.objet_animation as PictureBox).Visible = true;
        }

        public void arret_signalement_chargement()
        {
            (this.objet_animation as PictureBox).Visible = false;
            (this.objet_animation as PictureBox).BackgroundImage = null;
        }

    }
}
