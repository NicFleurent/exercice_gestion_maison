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
using Windows.Globalization.NumberFormatting;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Exercice_maison_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ajout : Page
    {
        public Ajout()
        {
            this.InitializeComponent();
            SetNumberBoxNumberFormatter();
        }

        private void SetNumberBoxNumberFormatter()
        {
            IncrementNumberRounder rounder = new IncrementNumberRounder();
            rounder.Increment = 0.01;
            rounder.RoundingAlgorithm = RoundingAlgorithm.RoundHalfUp;

            DecimalFormatter formatter = new DecimalFormatter();
            formatter.IntegerDigits = 1;
            formatter.FractionDigits = 2;
            formatter.NumberRounder = rounder;
            nbxPrix.NumberFormatter = formatter;
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            string categorie, ville;
            categorie = ville = "";
            double prix = 0;
            bool erreurSaisie = false;

            if (cbCategorie.SelectedIndex >= 0)
            {
                categorie = cbCategorie.SelectedItem.ToString();
                tblInvalidCategorie.Visibility = Visibility.Collapsed;
            }
            else
            {
                tblInvalidCategorie.Visibility = Visibility.Visible;
                erreurSaisie = true;
            }

            if (nbxPrix.Value is double.NaN)
            {
                tblInvalidPrix.Text = "Veuillez entrer un prix";
                tblInvalidPrix.Visibility = Visibility.Visible;
                erreurSaisie = true;
            }
            else
            {
                prix = (int)nbxPrix.Value;
                tblInvalidPrix.Visibility = Visibility.Collapsed;
            }

            if (tbxVille.Text != "")
            {
                ville = tbxVille.Text;
                tblInvalidVille.Visibility = Visibility.Collapsed;
            }
            else
            {
                tblInvalidVille.Visibility = Visibility.Visible;
                erreurSaisie = true;
            }

            if (!erreurSaisie)
            {
                SingletonListe.getInstance().ajouter(categorie, prix, ville);

                this.Frame.Navigate(typeof(Liste));
            }
        }
    }
}
