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
using System.Windows.Shapes;

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
        private BoardgameRepos boardgameRepos = new BoardgameRepos();
        private SqlDataReader reader;
        private List<Boardgame> Boardgames = new List<Boardgame>();


        Controller control = new Controller();      

        private void Boardgame_Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Switch = new MainWindow();
            Switch.Show();
            Close();
        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataTable dt = new DataTable();
            //reader = cmd.ExecuteReader();

            //dt.Load(reader);
            //txtBrætspil.Focus();
            //control.ReadBoardGameData();
            //DataGrid1.Columns[0].Visibility = Visibility.Collapsed;
            //DataGrid1.ItemsSource = dt.DefaultView;

        }

        //Get Data for datagrid


        //Nulstil Boardgame
        public void btnReset_Click(object sender, RoutedEventArgs e)
        {
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

        //Indsætfunktion til Boardgame
        public void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();
        }

        //Slettefunktion til Boardgame
        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Delete();
            //Read();
        }

        //Updatefunktion til Boardgame
        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();
            MessageBox.Show("Record Update Successfully", "Updated", MessageBoxButton.OK);
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
                txtId.Text = rowSelected[0].ToString();
                txtBrætspil.Text = rowSelected[1].ToString();
                txtAntal.Text = rowSelected[2].ToString();
                txtAldersgruppe.Text = rowSelected[3].ToString();
                txtSpilletid.Text = rowSelected[4].ToString();
                txtDistrubutør.Text = rowSelected[5].ToString();
                txtGenre.Text = rowSelected[6].ToString();
            }
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnInsert.IsEnabled = false;
        }
        public void Create()
        {
            //BGR.BoardgameName = txtBrætspil.Text;
            //BGR.PlayerCount = txtAntal.Text;
            //BGR.Audience = txtAldersgruppe.Text;
            //BGR.GameTime = txtSpilletid.Text;
            //BGR.Distributor = txtDistrubutør.Text;
            //BGR.GameTag = txtGenre.Text;
            //control.AddBoardGame();
        }
        public void Update()
        {
            Boardgames = boardgameRepos.DisplayBoardgames();
            List<Object> Boardgamelist = new List<Object>();
            for (int i = 0; i < Boardgames.Count; i++)
            {
                Boardgamelist.Add(new { OrderID = Boardgamelist[i].boardgameName, Customer = Boardgamelist[i].Customer.CompanyName, DateOfPurchase = Boardgamelist[i].DateOfPurchase, TotalPrice = Boardgamelist[i].TotalPrice });
                //boardgameName, numberOfPlayers, audience, expectedGameTime, distributor, gameTag, boardgameId
                //boardgameRepos.EditBoardgame();
            }
            //public void Delete()
            //{
            //    //BGR.BoardgameId = txtId.Text;
            //    //control.DeleteBoardGame();
            //}
            //public void Read()
            //{
            //    //DataGrid1.DataContext = null;
            //    //control.ReadBoardGameData();
            //    //DataGrid1.DataContext = BGR.dataTable;
            //}
        }
}
