using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Exercice_maison_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutP : Page
    {
        public AjoutP()
        {
            this.InitializeComponent();
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            string prenom, nom;
            prenom = nom = "";
            bool erreurSaisie = false;

            

            if (tbxNom.Text != "")
            {
                nom = tbxNom.Text;
                tblInvalidNom.Visibility = Visibility.Collapsed;
            }
            else
            {
                tblInvalidNom.Visibility = Visibility.Visible;
                erreurSaisie = true;
            }

            if (tbxPrenom.Text != "")
            {
                prenom = tbxPrenom.Text;
                tblInvalidPrenom.Visibility = Visibility.Collapsed;
            }
            else
            {
                tblInvalidPrenom.Visibility = Visibility.Visible;
                erreurSaisie = true;
            }

            if (!erreurSaisie)
            {
                SingletonProprietaire.getInstance().ajouter(prenom, nom);

                this.Frame.Navigate(typeof(Liste));
            }

        }
    }
}
