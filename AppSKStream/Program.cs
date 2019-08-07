using System;
using System.Windows.Forms;
using AppSKStream.Views;

namespace AppSKStream
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Fenetre_principale());
        }
    }
}
