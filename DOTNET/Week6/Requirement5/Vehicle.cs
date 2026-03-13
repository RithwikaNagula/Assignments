
namespace Requirement5
{
    public class Vehicle : IComparable<Vehicle>
    {
    
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        // properties
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public Ticket Ticket { get; set; }

        // parameterized constructor
        public Vehicle(string _registrationNo, string _name, string _type,
                       double _weight, Ticket _ticket)
        {
            RegistrationNo = _registrationNo;
            Name = _name;
            Type = _type;
            Weight = _weight;
            Ticket = _ticket;
        }

        // default sorting based on weight
        public int CompareTo(Vehicle other)
        {
            if (other == null) return 0;

            // compare weights
            return this.Weight.CompareTo(other.Weight);
        }

        // create vehicle from comma separated input
        public static Vehicle CreateVehicle(string detail)
        {
            try
            {
                // check invalid input
                if (string.IsNullOrWhiteSpace(detail))
                    throw new Exception();

                string[] data = detail.Split(',');

                if (data.Length != 7)
                    throw new Exception();

                string regNo = data[0];
                string name = data[1];
                string type = data[2];
                double weight = double.Parse(data[3]);

                string ticketNo = data[4];

                // parse date with exact format
                DateTime parkedTime =
                    DateTime.ParseExact(data[5],
                    "dd-MM-yyyy HH:mm:ss", null);

                double cost = double.Parse(data[6]);

                Ticket t = new Ticket(ticketNo, parkedTime, cost);

                return new Vehicle(regNo, name, type, weight, t);
            }
            catch
            {
                throw new Exception("invalid vehicle details");
            }
        }

        // override tostring for display
        public override string ToString()
        {
            return String.Format("{0,-15}{1,-10}{2,-12}{3,-7:F1}{4}",
                RegistrationNo, Name, Type, Weight, Ticket.TicketNo);
        }
    }

}
