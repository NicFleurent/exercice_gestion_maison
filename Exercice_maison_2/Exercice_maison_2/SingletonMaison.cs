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
                MySqlCommand command = new MySqlCommand("p_get_maisons");
                command.Connection = con;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader r = command.ExecuteReader();

                while (r.Read())
                {
                    string categorie = (string)r["categorie"];
                    double prix = (double)r["prix"];
                    string ville = (string)r["ville"];
                    string proprio = (string)r["proprio"];
                    Maison maison = new Maison { Categorie = categorie, Prix = prix, Ville = ville, Proprio = proprio };
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

        public void getListeMaisons(string villeRecherche, string categorieRecherche)
        {
            if(categorieRecherche == "Aucun")
            {
                categorieRecherche = "%";
            }

            listeMaisons.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("p_get_maisons_filtre");
                command.Connection = con;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("villeRecherche", "%" + villeRecherche + "%");
                command.Parameters.AddWithValue("categorieRecherche", categorieRecherche);
                con.Open();
                command.Prepare();
                MySqlDataReader r = command.ExecuteReader();

                while (r.Read())
                {
                    string categorie = (string)r["categorie"];
                    double prix = (double)r["prix"];
                    string ville = (string)r["ville"];
                    string proprio = (string)r["proprio"];
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
                MySqlCommand command = new MySqlCommand("p_ajout_maison");
                command.Connection = con;
                command.CommandText = $"insert into maison values(null,@categorie,@prix,@ville)";
                //command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("_categorie", categorie);
                command.Parameters.AddWithValue("_prix", prix);
                command.Parameters.AddWithValue("_ville", ville);
                //command.Parameters.AddWithValue("idProprio", idProprio);

                con.Open();
                command.Prepare();
                command.ExecuteNonQuery();
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
