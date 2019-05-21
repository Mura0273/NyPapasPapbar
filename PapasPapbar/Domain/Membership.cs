using PapasPapbar.Appli;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace PapasPapbar.Domain
{
    public class Membership : IMember
    {
        public int MemberNo;
        public string MemberName;
        public string SubscriptionDate;
        public string EndDate;
        public string EMail;

        public Membership(int memberNo, string memberName, string subscriptionDate, string endDate, string eMail)
        {
            MemberNo = memberNo;
            MemberName = memberName;
            SubscriptionDate = subscriptionDate;
            EndDate = endDate;
            EMail = eMail;
        }

        private void InsertExcelIntoSQL()
        {

            try
            {

                string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;");
                OleDbConnection Econ = new OleDbConnection(constr);
                string query5 = string.Format("Select [Member_No],[Member_Name],[Member_Email],[Sub_Date],[End_Date] FROM [{0}]", "Sheet1$");
                OleDbCommand Ecom = new OleDbCommand(query5, Econ);
                Econ.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(query5, Econ);
                Econ.Close();//close Excel connection after adding to data set  
                oda.Fill(ds);
                DataTable Exceldt = ds.Tables[0];

                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Employee Name"] == DBNull.Value || Exceldt.Rows[i]["Email"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                }
                Exceldt.AcceptChanges();
                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(Connection.connectionString);
                ////assigning Destination table name      
                //objbulk.DestinationTableName = "Student";
                ////Mapping Table column    
                //objbulk.ColumnMappings.Add("[Employee Name]", "Name");
                //objbulk.ColumnMappings.Add("DOB", "DOB");
                //objbulk.ColumnMappings.Add("Email", "Email");
                //objbulk.ColumnMappings.Add("Mobile", "Mob");

                //inserting Datatable Records to DataBase   
                SqlConnection connection = new SqlConnection(Connection.connectionString);
                connection.Open(); //Open DataBase conection  

                objbulk.WriteToServer(Exceldt); //inserting Datatable Records to DataBase con.Close(); //Close DataBase conection  
                connection.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Fejl: " + e.Message);
            }

        }
    }
}
