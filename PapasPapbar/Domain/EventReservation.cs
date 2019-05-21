using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class EventReservation
    {
        public string ReservationTime;
        public string ReservationDate;
        public int EventId;
        public string Comment;

        public EventReservation(string reservationTime, string reservationDate, int eventId, string comment)
        {
            ReservationTime = reservationTime;
            ReservationDate = reservationDate;
            EventId = eventId;
            Comment = comment;
        }
    }
}
