using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PapasPapbar.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class Boardgame : Domain.Connection
    {
        //Property
        public string BoardgameName { get; set; }
        public string PlayerCount { get; set; }
        public string Audience { get; set; }
        public string GameTime { get; set; }
        public string Distributor { get; set; }
        public string GameTag { get; set; }
        public int BoardgameId { get; set; }

        public Boardgame() { }

        public Boardgame(string boardgameName, string playerCount, string audience, string gameTime, string distributor, string gameTag, int boardgameId)
        {
            this.BoardgameName = boardgameName;
            this.PlayerCount = playerCount;
            this.Audience = audience;
            this.GameTime = gameTime;
            this.Distributor = distributor;
            this.GameTag = gameTag;
            this.BoardgameId = boardgameId;
        }

        public void InsertBoardgame(string boardgameName, string playerCount, string audience, string gameTime, string distributor, string gameTag)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("InsertGameLibrary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Boardgame_Name", boardgameName);
                cmd.Parameters.AddWithValue("@Player_Count", playerCount);
                cmd.Parameters.AddWithValue("@Audience", audience);
                cmd.Parameters.AddWithValue("@Game_Time", gameTime);
                cmd.Parameters.AddWithValue("@Distributor", distributor);
                cmd.Parameters.AddWithValue("@GameTag", gameTag);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateBoardgame(string boardgameName, string playerCount, string audience, string gameTime, string distributor, string gameTag, int boardgameId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UpdateGameLibrary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Boardgame_Name", boardgameName);
                cmd.Parameters.AddWithValue("@Player_Count", playerCount);
                cmd.Parameters.AddWithValue("@Audience", audience);
                cmd.Parameters.AddWithValue("@Game_Time", gameTime);
                cmd.Parameters.AddWithValue("@Distributor", distributor);
                cmd.Parameters.AddWithValue("@GameTag", gameTag);
                cmd.Parameters.AddWithValue("@Boardgame_Id", boardgameId);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteBoardgame(int boardgameId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteGameLibrary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Boardgame_Id", boardgameId);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void GetBoardgame()
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
                try
                {
                    SqlCommand cmd2 = new SqlCommand("ViewGameLibrary", con);
                    con.Open();
                    cmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd2.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            string boardgameName = reader["Boardgame_Name"].ToString();
                            string numberOfPlayers = reader["Player_Count"].ToString();
                            string audience = reader["Audience"].ToString();
                            string expectedGameTime = reader["Game_Time"].ToString();
                            string distributor = reader["Distributor"].ToString();
                            string gameTag = reader["GameTag"].ToString();
                            string boardgameId = reader["Boardgame_Id"].ToString();

                            Console.WriteLine($"\nBoardgame_Name: {boardgameName} \nPlayer_Count: {numberOfPlayers} \nAudience: {audience} " +
                           $"\nGame_Time: {expectedGameTime} \nDistributor: {distributor}\nBoardgame_Id: {boardgameId}\nGameTag: {gameTag}\n");


                        }
                    }
                    con.Close();

                    Console.ReadKey();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Fejl: " + e.Message);
                }

        }
        public List<Boardgame> GetBoardgames()
        {
            List<Boardgame> boardgames = new List<Boardgame>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd2 = new SqlCommand("ViewGameLibrary", connection);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string boardgameName = reader["Boardgame_Name"].ToString();
                        string numberOfPlayers = reader["Player_Count"].ToString();
                        string audience = reader["Audience"].ToString();
                        string expectedGameTime = reader["Game_Time"].ToString();
                        string distributor = reader["Distributor"].ToString();
                        string gameTag = reader["GameTag"].ToString();
                        string boardgameId = reader["Boardgame_Id"].ToString();
                    }
                }
            }

            return boardgames;
        }
    }
}
