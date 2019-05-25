using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class Boardgame : Domain.Connection
    {
        private string boardgameName;
        private string numberOfPlayers;
        private string audience;
        private string expectedGameTime;
        private string distributor;
        private int boardgameId;
        private string gameTag;
        public string BoardgameName
        {
            get { return boardgameName; }
            set { boardgameName = value; }
        }
        public string NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set { numberOfPlayers = value; }
        }
        public string Audience
        {
            get { return audience; }
            set { audience = value; }
        }
        public string ExpectedGameTime
        {
            get { return expectedGameTime; }
            set { expectedGameTime = value; }
        }
        public string Distributor
        {
            get { return distributor; }
            set { distributor = value; }
        }
        public int BoardgameId
        {
            get { return boardgameId; }
            set { boardgameId = value; }
        }
        public string GameTag
        {
            get { return gameTag; }
            set { gameTag = value; }
        }
        public Boardgame()
        {

        }
        public Boardgame(string boardgameName, string playerCount, string audience, string gameTime, string distributor, string gameTag, int boardgameId)
        {
            this.BoardgameName = boardgameName;
            this.NumberOfPlayers = numberOfPlayers;
            this.Audience = audience;
            this.ExpectedGameTime = expectedGameTime;
            this.Distributor = distributor;
            this.GameTag = gameTag;
            this.boardgameId = boardgameId;
        }

        public DataTable dataTable = new DataTable();
        private DataSet dataSet = new DataSet();
        public SqlDataReader reader;

        //public void CreateBoardgame()
        //{
        //    using (SqlConnection con = new SqlConnection(Connection.connectionString))
        //        try
        //        {

        //            con.Open();
        //            SqlCommand cmd = new SqlCommand("Insert into Game_Library (Boardgame_Name, Player_Count, Audience, Game_Time, Distributor, GameTag) Values (@Boardgame_Name, @Player_Count, @Audience, @Game_Time, @Distributor, @GameTag)", con);
        //            cmd.Parameters.AddWithValue("Boardgame_Name", BoardgameName);
        //            cmd.Parameters.AddWithValue("Player_Count", PlayerCount);
        //            cmd.Parameters.AddWithValue("Audience", Audience);
        //            cmd.Parameters.AddWithValue("Game_Time", GameTime);
        //            cmd.Parameters.AddWithValue("Distributor", Distributor);
        //            cmd.Parameters.AddWithValue("GameTag", GameTag);
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        catch (System.Exception)
        //        {
        //            throw;
        //        }
        //}


        public void AddBoardgame(string boardgameName, string numberOfPlayers, string audience, string expectedGameTime, string distributor, string gameTag)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand command1 = new SqlCommand("InsertGameLibrary", con);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Connection = con;

                    command1.Parameters.Add(new SqlParameter("@Boardgame_Name, ", boardgameName));
                    command1.Parameters.Add(new SqlParameter("@Player_Count, ", numberOfPlayers));
                    command1.Parameters.Add(new SqlParameter("@Audience, ", audience));
                    command1.Parameters.Add(new SqlParameter("@Game_Time, ", expectedGameTime));
                    command1.Parameters.Add(new SqlParameter("@Distributor, ", distributor));
                    command1.Parameters.Add(new SqlParameter("@GameTag, ", gameTag));



                    command1.ExecuteNonQuery();
                    con.Close();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Fejl: " + e.Message);
                }
            }
        }
        public void EditBoardgame(string boardgameName, string numberOfPlayers, string audience, string expectedGameTime, string distributor, string gameTag, int boardgameId)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                con.Open();
                using (SqlCommand command2 = new SqlCommand())
                {
                    command2.CommandText = "UPDATE [C_DB13_2018].[dbo].[Game_Library] SET Boardgame_Name = @Boardgame_Name, Player_Count = @Player_Count, Audience = @Audience, Game_Time = @Game_Time, Distributor = @Distributor, GameTag = @GameTag WHERE Boardgame_Id = @Boardgame_Id";

                    command2.CommandType = CommandType.Text;
                    command2.Connection = con;

                    command2.Parameters.Add(new SqlParameter("Boardgame_Name", boardgameName));
                    command2.Parameters.Add(new SqlParameter("Player_Count", numberOfPlayers));
                    command2.Parameters.Add(new SqlParameter("Audience", audience));
                    command2.Parameters.Add(new SqlParameter("Game_Time", expectedGameTime));
                    command2.Parameters.Add(new SqlParameter("Distributor", distributor));
                    command2.Parameters.Add(new SqlParameter("GameTag", gameTag));
                    command2.Parameters.Add(new SqlParameter("BoardGame_Id", BoardgameId));

                    command2.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void DeleteBoardgame(int boardgameId)
        {
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                con.Open();
                using (SqlCommand command3 = new SqlCommand())
                {
                    command3.CommandText = "DELETE FROM [C_DB13_2018].[dbo].[Game_Library] WHERE Boardgame_Id = @Boardgame_Id";

                    command3.CommandType = CommandType.Text;
                    command3.Connection = con;

                    command3.Parameters.Add(new SqlParameter("BoardGame_Id", boardgameId));

                    command3.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public List<Boardgame> ShowBoardgame()
        {
            List<Boardgame> boardgames = new List<Boardgame>();
            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                con.Open();
            
                //Ændre navnet ShowBoardGame til navnet på vores stored procedure.
                SqlCommand command = new SqlCommand("ShowBoardgame", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BoardgameId", boardgameId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string boardgameName = reader["BoardgameName"].ToString();
                        string numberOfPlayers = reader["PlayerCount"].ToString();
                        string audience = reader["Audience"].ToString();
                        string expectedGameTime = reader["GameTime"].ToString();
                        string distributor = reader["Distributor"].ToString();
                        string gameTag = reader["GameTag"].ToString();
                        int _boardgameId = int.Parse(reader["BoardgameId"].ToString());
                        boardgames.Add(new Boardgame(boardgameName, numberOfPlayers, audience, expectedGameTime, distributor, gameTag, boardgameId));
                    }
                }
            }
            return boardgames;
        }
    }
}
