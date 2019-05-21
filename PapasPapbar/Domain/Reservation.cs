using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class Reservation
    {
        public string ReservationTime;
        public string ReservationDate;
        public int ReservationId;
        public string CustomerName;
        public string Comment;

        public Reservation(string reservationTime, string reservationDate, int reservationId, string customerName, string comment)
        {
            ReservationTime = reservationTime;
            ReservationDate = reservationDate;
            ReservationId = reservationId;
            CustomerName = customerName;
            Comment = comment;
        }
    }
}
