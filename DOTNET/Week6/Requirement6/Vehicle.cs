
namespace Requirement6
{
    internal class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;

        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }

        // default constructor
        public Vehicle() { }

        // parameterized constructor
        public Vehicle(string _registrationNo, string _name, string _type, double _weight)
        {
            RegistrationNo = _registrationNo;
            Name = _name;
            Type = _type;
            Weight = _weight;
        }

        // create vehicle from comma separated string
        public static Vehicle CreateVehicle(string detail)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(detail))
                    throw new Exception();

                string[] data = detail.Split(',');

                if (data.Length != 4)
                    throw new Exception();

                string regNo = data[0].Trim();
                string name = data[1].Trim();
                string type = data[2].Trim();
                double weight = double.Parse(data[3].Trim());

                return new Vehicle(regNo, name, type, weight);
            }
            catch
            {
                throw new Exception("invalid vehicle input");
            }
        }

        // method to calculate type wise count
        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            // sorted dictionary keeps keys sorted automatically
            SortedDictionary<string, int> result =
                new SortedDictionary<string, int>();

            foreach (var v in vehicleList)
            {
                //remove extra spaces
                string type = v.Type.Replace(" ", "");

                if (result.ContainsKey(type))
                    result[type]++;
                else
                    result[type] = 1;
            }

            return result;
        }
    }
}
