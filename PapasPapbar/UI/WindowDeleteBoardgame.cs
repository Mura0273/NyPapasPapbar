using PapasPapbar.Appli;
using System.Windows;

namespace PapasPapbar.UI
{
    public partial class WindowDeleteBoardgame : Window
    {
        private BoardgameRepos boardgameRepos = new BoardgameRepos();
        private Boardgame boardgame;

            public WindowDeleteBoardgame(Boardgame boardgame)
            {
                InitializeComponent();
                this.boardgame = boardgame;
                LabelDeleteBoardgame.Content = $"Er du sikker på at du vil slette ordren '{order.OrderID}'?";
            }

            private void ButtonYes_Click(object sender, RoutedEventArgs e)
            {
                List<Orderline> orderlines = orderlineRepository.DisplayOrderlines(order);
                for (int i = 0; i < orderlines.Count; i++)
                {
                    Product product = orderlines[i].Product;
                    product.ProductAmount += orderlines[i].Amount;
                    productRepository.EditProduct(product);
                    orderlineRepository.DeleteOrderline(orderlines[i].OrderlineNumber);
                }
                orderRepository.DeleteOrder(order.OrderID);
                this.Close();
            }

            private void ButtonNo_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
        //List<Boardgame> boardgames = boardgameRepos.DisplayBoardgame(_boardgame);
        //for (int i = 0; i<orderlines.Count; i++)
        //{
        //    Product product = orderlines[i].Product;
        //product.ProductAmount += orderlines[i].Amount;
        //    productRepository.EditProduct(product);
        //    boardgameRepos.DeleteBoardgame(boardgame.BoardgameId);
        //}
        //this.Close();

}