
namespace Requirement5
{
    public class Ticket
    {
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        // properties
        public string TicketNo { get; set; }
        public DateTime ParkedTime { get; set; }
        public double Cost { get; set; }

        // parameterized constructor
        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            TicketNo = _ticketNo;
            ParkedTime = _parkedTime;
            Cost = _cost;
        }
    }
}

