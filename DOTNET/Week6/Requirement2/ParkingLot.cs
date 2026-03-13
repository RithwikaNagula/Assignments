namespace Requirement2
{
    internal class ParkingLot
    {
        
        private string _name;
        private List<Vehicle> _vehicleList;

       
        public string Name { get; set; }
        public List<Vehicle> VehicleList { get; set; }

        // default constructor
        public ParkingLot()
        {
            VehicleList = new List<Vehicle>();
        }

        // parameterized constructor
        public ParkingLot(string _name, List<Vehicle> _vehicleList)
        {
            this.Name = _name;
            // initialize empty list as requirement says
            this.VehicleList = new List<Vehicle>();
        }

        // add vehicle into parking lot
        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            VehicleList.Add(vehicle);
        }

        // remove vehicle by registration number
        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            foreach (var v in VehicleList)
            {
                if (v.RegistrationNo == registrationNo)
                {
                    VehicleList.Remove(v);
                    return true;
                }
            }
            return false;
        }

        // display all vehicles
        public void DisplayVehicles()
        {
            // check if empty
            if (VehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
                return;
            }

            Console.WriteLine($"Vehicles in {Name}");

            // print heading with formatting
            Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
            "Registration No", "Name", "Type", "Weight", "Ticket No");

            // print each vehicle
            foreach (var v in VehicleList)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}",
                v.RegistrationNo,
                v.Name,
                v.Type,
                v.Weight,
                v.Ticket.TicketNo);
            }
        }
    }
}
