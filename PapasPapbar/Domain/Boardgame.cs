using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class Boardgame
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

    }
}
