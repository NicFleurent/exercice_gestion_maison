using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_maison_2
{
    internal class SingletonProprietaire
    {
        static SingletonProprietaire instance = null;
        MySqlConnection con;
        ObservableCollection<Proprietaire> listeproprietaires;

        public SingletonProprietaire() 
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=1596189-fleurent-nicolas;Uid=1596189;Pwd=1596189;");
            listeproprietaires = new ObservableCollection<Proprietaire>();
            getListeProprietaires();

        }

        public static SingletonProprietaire getInstance()
        {
            if (instance == null)
                instance = new SingletonProprietaire();

            return instance;
        }

        public ObservableCollection<Proprietaire> Proprietaire { get { return listeproprietaires; } }
        public void getListeProprietaires()
        {
            listeproprietaires.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = con;
                command.CommandText = "Select * from proprietaire";
                con.Open();
                MySqlDataReader r = command.ExecuteReader();

                while (r.Read())
                {
                    
                    string nom = (string)r["nom"];
                    string prenom = (string)r["prenom"];
                    
                    Proprietaire proprio = new Proprietaire { Nom = nom, Prenom = prenom};
                    listeproprietaires.Add(proprio);

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
        public void ajouter(string nom, string prenom)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into proprietaire values(null,@nom,@prenom)";

                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
                con.Close();

                SingletonProprietaire.getInstance().getListeProprietaires();
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
