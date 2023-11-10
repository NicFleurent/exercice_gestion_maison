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
    public sealed partial class Liste : Page
    {
        public Liste()
        {
            this.InitializeComponent();
            lvListe.ItemsSource = SingletonListe.getInstance().Maisons;
        }

        private void cbCategorieFiltre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SingletonListe.getInstance().getListeMaisons(tbVilleFiltre.Text, cbCategorieFiltre.SelectedIndex);
        }

        private void tbVilleFiltre_TextChanged(object sender, TextChangedEventArgs e)
        {
            SingletonListe.getInstance().getListeMaisons(tbVilleFiltre.Text, cbCategorieFiltre.SelectedIndex);
        }

        private void lvListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void lvListe_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SingletonListe.getInstance().getCount() == 0)
                tblVilles.Visibility = Visibility.Visible;
            else
                tblVilles.Visibility = Visibility.Collapsed;
        }
    }
}
