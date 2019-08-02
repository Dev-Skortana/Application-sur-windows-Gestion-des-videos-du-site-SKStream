using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoFlat;
using System.Threading;
namespace AppSKStream
{
    public static class Minigestionnnaviguationformulaire
    {
        public static void passage_formulaire_controlepardefault(Form formulaire_acacher,Form formulaire_amontrer)
        {
            formulaire_acacher.Hide();
            formulaire_amontrer.FormClosed += (s, args) => formulaire_acacher.Close();
            formulaire_amontrer.Show();

        }

        public static void sortie_formulaire(Form formulaire, KeyEventArgs key_event,Form formulaire_redirection=null) {
            if(key_event.KeyCode==Keys.Escape){
                if (MessageBox.Show(formulaire,"Voulez-vous vraiment sortir de ce formulaire ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) {
                    if (formulaire_redirection==null) {
                        formulaire.Close();
                    }
                    else {
                        formulaire.Hide();
                        formulaire_redirection.FormClosed += (s, args) => formulaire.Close();
                        formulaire_redirection.Show();
                    }
                }
            }
        }
    }
}
