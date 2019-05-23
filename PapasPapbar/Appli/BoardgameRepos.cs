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
using PapasPapbar.Domain;


namespace PapasPapbar.Appli
{

    public class BoardgameRepos
    {
        private Boardgame boardgame = new Boardgame();

        public void AddBoardgame(Boardgame boardgame)
        {
            boardgame.AddBoardgame(boardgame.BoardgameName, boardgame.NumberOfPlayers, boardgame.Audience, boardgame.ExpectedGameTime, boardgame.Distributor, boardgame.GameTag);
        }
        public void EditBoardgame(Boardgame boardgame)
        {
            boardgame.EditBoardgame(boardgame.BoardgameName, boardgame.NumberOfPlayers, boardgame.Audience, boardgame.ExpectedGameTime, boardgame.Distributor, boardgame.GameTag, boardgame.BoardgameId);
        }
        public void DeleteBoardgame(int boardgameId)
        {
            boardgame.DeleteBoardgame(boardgameId);
        }
    }
}
