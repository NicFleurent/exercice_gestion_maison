using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_maison_2
{
    internal class Proprietaire
    {
        public string Nom { get; set; }
        public double Prenom { get; set; }

        public override string ToString()
        {
            return $"{Nom} - {Prenom}";
        }
    }
}
