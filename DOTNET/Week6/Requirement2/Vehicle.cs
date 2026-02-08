namespace Requirement2
{
    internal class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public Ticket Ticket { get; set; }

        // default constructor
        public Vehicle() { }

        // parameterized constructor
        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {
            this.RegistrationNo = _registrationNo;
            this.Name = _name;
            this.Type = _type;
            this.Weight = _weight;
            this.Ticket = _ticket;
        }

        // static method to create vehicle object from string input
        public static Vehicle CreateVehicle(string detail)
        {
            try
            {
                // check empty input
                if (string.IsNullOrWhiteSpace(detail))
                     throw new Exception("empty input");

                string[] data = detail.Split(',');

                // must contain 7 fields
                if (data.Length != 7)
                    throw new Exception("wrong format");

                string regNo = data[0];
                string name = data[1];
                string type = data[2];
                double weight = double.Parse(data[3]);

                string ticketNo = data[4];

                DateTime parkedTime =
                    DateTime.ParseExact(data[5],"dd-MM-yyyy HH:mm:ss", null);

                double cost = double.Parse(data[6]);

                Ticket t = new Ticket(ticketNo, parkedTime, cost);

                return new Vehicle(regNo, name, type, weight, t);
            }
            catch
            {
                // throw again so main handles it
                throw new Exception("invalid vehicle details");
            }
        }
    }
}
