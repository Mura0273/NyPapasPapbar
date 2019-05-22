using PapasPapbar.Appli;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PapasPapbar.UI;


namespace PapasPapbar.Appli
{

    public class BoardgameRepos
    {
        public string BoardgameName { get; set; }
        public string PlayerCount { get; set; }
        public string Audience { get; set; }
        public string GameTime { get; set; }
        public string Distributor { get; set; }
        public string GameTag { get; set; }
        public string BoardgameId { get; set; }

        public DataTable dataTable = new DataTable();
        private DataSet dataSet = new DataSet();
        public SqlDataReader reader;

        public void CreateBoardgame()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into Game_Library (Boardgame_Name, Player_Count, Audience, Game_Time, Distributor, GameTag) Values (@Boardgame_Name, @Player_Count, @Audience, @Game_Time, @Distributor, @GameTag)", con);
                cmd.Parameters.AddWithValue("Boardgame_Name", txtBrætspil.Text.Trim());
                cmd.Parameters.AddWithValue("Player_Count", txtAntal.Text.Trim());
                cmd.Parameters.AddWithValue("Audience", txtAldersgruppe.Text.Trim());
                cmd.Parameters.AddWithValue("Game_Time", txtSpilletid.Text.Trim());
                cmd.Parameters.AddWithValue("Distributor", txtDistrubutør.Text.Trim());
                cmd.Parameters.AddWithValue("GameTag", txtGenre.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Save Successfully", "Saved", MessageBoxButton.OK);
                GetData();
                Reset();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        //public void CreateBoardgame()
        //{
        //    using (SqlConnection con = new SqlConnection(Connection.connectionString))
        //    {
        //    con.Open();
        //        using (SqlCommand command1 = new SqlCommand())
        //        {
        //            command1.CommandText = "INSERT INTO [C_DB13_2018].[dbo].[Game_Library] (Boardgame_Name, Player_Count, Audience, Game_Time, Distributor, GameTag) VALUES (@Boardgame_Name, @Player_Count, @Audience, @Game_Time, @Distributor, @GameTag);";
        //            command1.CommandType = CommandType.Text;
        //            command1.Connection = con;

        //            command1.Parameters.Add(new SqlParameter("Boardgame_Name", BoardgameName));
        //            command1.Parameters.Add(new SqlParameter("Player_Count", PlayerCount));
        //            command1.Parameters.Add(new SqlParameter("Audience", Audience));
        //            command1.Parameters.Add(new SqlParameter("Game_Time", GameTime));
        //            command1.Parameters.Add(new SqlParameter("Distributor", Distributor));
        //            command1.Parameters.Add(new SqlParameter("GameTag", GameTag));

        //            command1.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //}
        public void UpdateBoardgame()
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                con.Open();
                using (SqlCommand command2 = new SqlCommand())
                {
                    command2.CommandText = "UPDATE [C_DB13_2018].[dbo].[Game_Library] SET Boardgame_Name = @Boardgame_Name, Player_Count = @Player_Count, Audience = @Audience, Game_Time = @Game_Time, Distributor = @Distributor, GameTag = @GameTag WHERE Boardgame_Id = @Boardgame_Id";

                    command2.CommandType = CommandType.Text;
                    command2.Connection = con;

                    command2.Parameters.Add(new SqlParameter("Boardgame_Name", BoardgameName));
                    command2.Parameters.Add(new SqlParameter("Player_Count", PlayerCount));
                    command2.Parameters.Add(new SqlParameter("Audience", Audience));
                    command2.Parameters.Add(new SqlParameter("Game_Time", GameTime));
                    command2.Parameters.Add(new SqlParameter("Distributor", Distributor));
                    command2.Parameters.Add(new SqlParameter("GameTag", GameTag));
                    command2.Parameters.Add(new SqlParameter("BoardGame_Id", BoardgameId));

                    command2.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void DeleteBoardgame()
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                con.Open();
                using (SqlCommand command3 = new SqlCommand())
                {
                    command3.CommandText = "DELETE FROM [C_DB13_2018].[dbo].[Game_Library] WHERE Boardgame_Id = @Boardgame_Id";

                    command3.CommandType = CommandType.Text;
                    command3.Connection = con;

                    command3.Parameters.Add(new SqlParameter("BoardGame_Id", BoardgameId));

                    command3.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void ReadData()
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                dataTable.Clear();
                string query1 = "SELECT Boardgame_Name, Player_Count, Audience, Game_Time, Distributor, GameTag, Boardgame_Id FROM ViewGameLibrary";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query1, con);
                sqlDataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }

        }
    }
}
