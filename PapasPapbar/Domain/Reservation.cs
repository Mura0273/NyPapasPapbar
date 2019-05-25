using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class Reservation : Connection
    {
        //skal nok ikke have to DateTimes.
        public DateTime ReservationTime { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }

        public Reservation(DateTime reservationTime, DateTime reservationDate, int reservationId, string customerName, string comment)
        {
            this.ReservationTime = reservationTime;
            this.ReservationDate = reservationDate;
            this.ReservationId = reservationId;
            this.CustomerName = customerName;
            this.Comment = comment;
        }
        public void AddReservation(DateTime reservationTime, DateTime reservationDate, int reservationId, string customerName, string comment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("AddReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ReservationTime", reservationTime);
                command.Parameters.AddWithValue("Reservationdate", reservationDate);
                command.Parameters.AddWithValue("ReservationId", reservationId);
                command.Parameters.AddWithValue("CustomerName", customerName);
                command.Parameters.AddWithValue("Comment", comment);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
