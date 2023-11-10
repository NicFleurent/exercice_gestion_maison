using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Exercice_maison_2
{
    internal class SingletonMaison
    {
        static SingletonMaison instance = null;
        MySqlConnection con;
        ObservableCollection<Maison> listeMaisons;

        public SingletonMaison()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=1596189-fleurent-nicolas;Uid=1596189;Pwd=1596189;");
            listeMaisons = new ObservableCollection<Maison>();
            getListeMaisons();
        }

        public static SingletonMaison getInstance()
        {
            if (instance == null)
                instance = new SingletonMaison();

            return instance;
        }

        public ObservableCollection<Maison> Maisons { get { return listeMaisons; } }

        public void getListeMaisons()
        {
            listeMaisons.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = con;
                command.CommandText = "Select * from maison";
                con.Open();
                MySqlDataReader r = command.ExecuteReader();

                while (r.Read())
                {
                    string categorie = (string)r["categorie"];
                    double prix = (double)r["prix"];
                    string ville = (string)r["ville"];
                    Maison maison = new Maison { Categorie = categorie, Prix = prix, Ville = ville };
                    listeMaisons.Add(maison);

                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public void getListeMaisons(string villeRecherche)
        {
            listeMaisons.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from maison WHERE ville LIKE @ville";
                commande.Parameters.AddWithValue("@ville", "%" + villeRecherche + "%");
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string categorie = (string)r["categorie"];
                    double prix = (double)r["prix"];
                    string ville = (string)r["ville"];
                    Maison maison = new Maison { Categorie = categorie, Prix = prix, Ville = ville };
                    listeMaisons.Add(maison);

                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public void getListeMaisons(int indexCategorie)
        {
            string categorieRecherche;
            switch (indexCategorie)
            {
                case 1: categorieRecherche = "Condo"; break;
                case 2: categorieRecherche = "Unifamiliale"; break;
                case 3: categorieRecherche = "Jumulé"; break;
                default: categorieRecherche = ""; break;
            }
            listeMaisons.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from maison WHERE categorie LIKE @categorie";
                commande.Parameters.AddWithValue("@categorie", "%" + categorieRecherche + "%");
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string categorie = (string)r["categorie"];
                    double prix = (double)r["prix"];
                    string ville = (string)r["ville"];
                    Maison maison = new Maison { Categorie = categorie, Prix = prix, Ville = ville };
                    listeMaisons.Add(maison);

                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public void getListeMaisons(string villeRecherche, int indexCategorie)
        {
            string categorieRecherche;
            switch (indexCategorie)
            {
                case 1: categorieRecherche = "Condo"; break;
                case 2: categorieRecherche = "Unifamiliale"; break;
                case 3: categorieRecherche = "Jumulé"; break;
                default: categorieRecherche = ""; break;
            }
            listeMaisons.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from maison WHERE ville LIKE @ville AND categorie LIKE @categorie";
                commande.Parameters.AddWithValue("@ville", "%" + villeRecherche + "%");
                commande.Parameters.AddWithValue("@categorie", "%" + categorieRecherche + "%");
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string categorie = (string)r["categorie"];
                    double prix = (double)r["prix"];
                    string ville = (string)r["ville"];
                    Maison maison = new Maison { Categorie = categorie, Prix = prix, Ville = ville };
                    listeMaisons.Add(maison);

                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public int getCount()
        { return listeMaisons.Count; }

        public void ajouter(string categorie, double prix, string ville)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into maison values(null,@categorie,@prix,@ville)";

                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@prix", prix);
                commande.Parameters.AddWithValue("@ville", ville);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
                con.Close();

                SingletonMaison.getInstance().getListeMaisons();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
