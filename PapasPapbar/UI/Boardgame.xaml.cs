using PapasPapbar.Appli;
using PapasPapbar.Domain;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace PapasPapbar.UI
{
    /// <summary>
    /// Interaction logic for Boardgame.xaml
    /// </summary>
    public partial class Boardgame : Window
    {
        public Boardgame()
        {
            InitializeComponent();
        }
        private Appli.BoardgameRepos boardgameRepos = new Appli.BoardgameRepos();
        private Domain.Boardgame boardgame = new Domain.Boardgame();
        //private Boardgame boardgame;
        //private int boardgameId;
        private SqlDataReader reader;
        private SqlCommand cmd;


        Controller control = new Controller();

        private void Boardgame_Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Switch = new MainWindow();
            Switch.Show();
            Close();
        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowData_Boardgame();
            DataGrid1.Columns[4].Visibility = Visibility.Collapsed;
        }

        //Indsætfunktion til Boardgame
        public void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Domain.Boardgame boardgame = new Domain.Boardgame();
            boardgame.BoardgameName = txtBrætspil.Text.ToString();

            if (txtAntal != null && txtAldersgruppe != null && txtSpilletid != null && txtDistrubutør != null && txtGenre != null)
            {
                boardgame.BoardgameName = txtBrætspil.Text;
                boardgame.PlayerCount = txtAntal.Text;
                boardgame.Audience = txtAldersgruppe.Text;
                boardgame.GameTime = txtSpilletid.Text;
                boardgame.Distributor = txtDistrubutør.Text;
                boardgame.GameTag = txtGenre.Text;

                boardgameRepos.InsertBoardgame(boardgame);
                MessageBox.Show("Brætspillet er tilføjet");
                ShowData_Boardgame();
                Reset_Boardgame();
            }
            else
            {
                MessageBox.Show("Noget gik galt");
            }
        }

        //Slettefunktion til Boardgame
        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (boardgame != null)
            {
                WindowDeleteOrder weo = new WindowDeleteOrder(boardgame);
                weo.ShowDialog();
                Update();
            }
            else
            {
                WindowShowDialog wsd = new WindowShowDialog();
                wsd.LabelShowDialog.Content = "Ingen ordre er valgt!";
                wsd.ShowDialog();
            }
            //List<Boardgame> boardgames = boardgameRepos.DisplayBoardgame(_boardgame);
            //for (int i = 0; i < orderlines.Count; i++)
            //{
            //    Product product = orderlines[i].Product;
            //    product.ProductAmount += orderlines[i].Amount;
            //    productRepository.EditProduct(product);
            //    boardgameRepos.DeleteBoardgame(boardgame.BoardgameId);
            //}

            //ShowData_Boardgame();
            //Reset_Boardgame();
            //this.Close();
        }

        //Updatefunktion til Boardgame
        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtAntal != null && txtAldersgruppe != null && txtSpilletid != null && txtDistrubutør != null && txtGenre != null)
            {
                boardgame.BoardgameName = txtBrætspil.Text;
                boardgame.PlayerCount = txtAntal.Text;
                boardgame.Audience = txtAldersgruppe.Text;
                boardgame.GameTime = txtSpilletid.Text;
                boardgame.Distributor = txtDistrubutør.Text;
                boardgame.GameTag = txtGenre.Text;

                boardgameRepos.UpdateBoardgame(boardgame);
                MessageBox.Show("Brætspil er opdateret");
                ShowData_Boardgame();
                Reset_Boardgame();
            }
            else
            {
                MessageBox.Show("Noget gik galt, prøv igen");
            }
        }

        //Nulstil Boardgame
        public void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Boardgame();
        }

        private void Reset_Boardgame()
        {
            txtId.Text = "";
            txtBrætspil.Text = "";
            txtAntal.Text = "";
            txtAldersgruppe.Text = "";
            txtSpilletid.Text = "";
            txtDistrubutør.Text = "";
            txtGenre.Text = "";
            txtBrætspil.Focus();
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnInsert.IsEnabled = true;
        }

        //Søgefunktion til Boardgame
        public void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            DataGrid1.ItemsSource = dt.DefaultView;
            DataGrid1.Columns[0].Visibility = Visibility.Collapsed;
        }

        public void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView rowSelected = dg.SelectedItem as DataRowView;
            if (rowSelected != null)
            {
                txtId.Text = rowSelected[6].ToString();
                txtBrætspil.Text = rowSelected[0].ToString();
                txtAntal.Text = rowSelected[1].ToString();
                txtAldersgruppe.Text = rowSelected[2].ToString();
                txtSpilletid.Text = rowSelected[3].ToString();
                txtDistrubutør.Text = rowSelected[4].ToString();
                txtGenre.Text = rowSelected[5].ToString();
            }
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnInsert.IsEnabled = false;
        }

        public string connectionString =
            "Server=EALSQL1.eal.local; " +
            "Database= C_DB13_2018; " +
            "User Id=C_STUDENT13; " +
            "Password=C_OPENDB13;";

        public void ShowData_Boardgame()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Select * From Game_Library", con);
                    reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    DataGrid1.ItemsSource = dt.DefaultView;
                    con.Close();
                    DataGrid1.Columns[4].Visibility = Visibility.Collapsed;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}
