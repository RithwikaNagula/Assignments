
namespace Requirement4
{
    internal class Ticket
    {
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;
        public string TicketNo { get; set; }
        public DateTime ParkedTime { get; set; }
        public double Cost { get; set; }

        // default constructor
        public Ticket() { }

        // parameterized constructor
        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            TicketNo = _ticketNo;
            ParkedTime = _parkedTime;
            Cost = _cost;
        }
    }
}
