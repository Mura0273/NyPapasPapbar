using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PapasPapbar.Appli
{
    public class Controller
    {
        public void AddBoardGame()
        {
            BoardgameRepos BG = new BoardgameRepos();
            BG.CreateBoardgame();

        }
        public void UpdateBoardGame()
        {
            BoardgameRepos BG = new BoardgameRepos();
            BG.UpdateBoardgame();
        }
        public void DeleteBoardGame()
        {
            BoardgameRepos BG = new BoardgameRepos();
            BG.DeleteBoardgame();
        }
        public void ReadBoardGameData()
        {
            BoardgameRepos BG = new BoardgameRepos();
            BG.ReadData();
        }
    }
}
