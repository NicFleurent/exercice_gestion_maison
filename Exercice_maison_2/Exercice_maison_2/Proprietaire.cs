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
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public override string ToString()
        {
            return $"{Prenom} - {Nom}";
        }
    }
}
