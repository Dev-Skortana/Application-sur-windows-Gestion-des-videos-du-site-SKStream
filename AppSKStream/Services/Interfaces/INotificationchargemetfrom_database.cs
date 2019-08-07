using System.Windows.Forms;

namespace AppSKStream.Services.Interfaces
{
    public interface INotificationchargemetfrom_database
    {
        Control objet_animation { get; set; }
        void signalement_chargement();
        void arret_signalement_chargement();
    }
}
