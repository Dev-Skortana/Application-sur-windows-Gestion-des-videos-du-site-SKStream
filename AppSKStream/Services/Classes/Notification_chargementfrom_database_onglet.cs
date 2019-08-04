using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSKStream.Services.Interfaces;

namespace AppSKStream.Services.Classes
{
    class Notification_chargementfrom_database_onglet : INotificationchargemetfrom_database
    {   TabPage onglet_cible;
        String text_origine_objetanimation;

        public Notification_chargementfrom_database_onglet(Control objet) {
            this.objet_animation = objet;
        }

        public Control objet_animation
        {
            get;
            set;
        }

        public void signalement_chargement()
        {
            onglet_cible = (objet_animation as TabControl).SelectedTab;
            text_origine_objetanimation = onglet_cible.Text;
            onglet_cible.Text+= " Chargement...";
        }

        public void arret_signalement_chargement()
        {
            onglet_cible.Text = text_origine_objetanimation;
        }

    }
}
