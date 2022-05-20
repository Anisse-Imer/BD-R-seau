using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ConnBd
{
    public class Class1
    {
        private static MySqlConnection MaCnx;

        public static void Affiche(string table)
        {
            string serveur = "10.1.139.236";
            string login = "f1";
            string passwd = "mdp";
            string BD = "basef1";
            string chaineDeConnection = $"server={serveur};uid={login};pwd={passwd};database={BD}";

            MaCnx = new MySqlConnection(chaineDeConnection);

            string sql = $"SELECT * FROM {table}";

            try
            {
                MaCnx.Open();

                MySqlCommand cmd = new MySqlCommand(sql, MaCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr.GetValue(0).ToString());
                    Console.WriteLine(rdr.GetValue(1));
                    Console.WriteLine(rdr.GetBoolean(2));
                    Console.WriteLine(rdr.GetString(3));
                }

                MaCnx.Dispose();
                MaCnx.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
            public static void Supp(string cle, string ligne, string table)
            {
                string serveur = "10.1.139.236";
                string login = "f1";
                string passwd = "mdp";
                string BD = "basef1";
                string chaineDeConnection = $"server={serveur};uid={login};pwd={passwd};database={BD}";

                MaCnx = new MySqlConnection(chaineDeConnection);

                string sql = $"DELETE FROM '{table}' WHERE '{cle}' = '{ligne}'";

                try
                {
                    MaCnx.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, MaCnx);
                    cmd.ExecuteNonQuery();

                    MaCnx.Dispose();
                    MaCnx.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
    }
}
