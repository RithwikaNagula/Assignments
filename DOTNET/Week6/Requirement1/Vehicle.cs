namespace Requirement1
{
    internal class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        // constructor with validation
        public Vehicle(string _registrationNo, string _name, string _type,
                       double _weight, Ticket _ticket)
        {
            if (string.IsNullOrWhiteSpace(_registrationNo))
                throw new ArgumentException("registration number cannot be empty");

            if (string.IsNullOrWhiteSpace(_name))
                throw new ArgumentException("name cannot be empty");

            if (_ticket == null)
                throw new ArgumentNullException("ticket cannot be null");

            if (_weight <= 0)
                throw new ArgumentException("weight must be positive");

            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        // display vehicle details
        public override string ToString()
        {
            return $"Registration No:{_registrationNo}\n" +
                   $"Name:{_name}\n" +
                   $"Type:{_type}\n" +
                   $"Weight:{_weight:F1}\n" +
                   $"Ticket No:{_ticket.TicketNo}";
        }

        // compare vehicles based on registrationNo + name
        public override bool Equals(object obj)
        {
            try
            {
                Vehicle other = obj as Vehicle;

                if (other == null)
                    return false;

                return string.Equals(this._registrationNo, other._registrationNo, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this._name, other._name, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // override hashcode when equals overridden
        public override int GetHashCode()
        {
            return (_registrationNo + _name).ToLower().GetHashCode();
        }
    }
}
