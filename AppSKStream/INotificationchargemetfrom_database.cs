using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSKStream
{
    public interface INotificationchargemetfrom_database
    {
        Control objet_animation { get; set; }
        void signalement_chargement();
        void arret_signalement_chargement();
    }
}
