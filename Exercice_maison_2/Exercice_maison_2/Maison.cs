using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_maison_2
{
    internal class Maison
    {
        public string Categorie { get; set; }

        public double Prix { get; set; }

        public string PrixFormat
        {
            get { return Prix.ToString("C2", CultureInfo.CurrentCulture); }
        }

        public string Ville { get; set; }

        public string Proprio { get; set; }

        public override string ToString()
        {
            return $"{Categorie} - {Prix.ToString("C2", CultureInfo.CurrentCulture)} - {Ville} - {Proprio}";
        }
    }
}
