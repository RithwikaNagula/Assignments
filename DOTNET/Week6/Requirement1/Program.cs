using System.Globalization;

namespace Requirement1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
                Console.WriteLine("Enter Vehicle 1 details:");
                string input1 = Console.ReadLine();
                Console.WriteLine("Enter Vehicle 2 details:");
                string input2 = Console.ReadLine();

                // create vehicle objects from input
                Vehicle v1 = CreateVehicle(input1);
                Vehicle v2 = CreateVehicle(input2);

                // display vehicle 1 details
                Console.WriteLine("Vehicle 1");
                Console.WriteLine(v1);

                Console.WriteLine();

                // display vehicle 2 details
                Console.WriteLine("Vehicle 2");
                Console.WriteLine(v2);

                Console.WriteLine();

                // compare vehicles using overridden equals method
                if (v1.Equals(v2))
                    Console.WriteLine("Vehicle 1 is same as Vehicle 2");
                else
                    Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
            }
            catch (Exception ex)
            {
                // handle unexpected errors
                Console.WriteLine("error occurred: " + ex.Message);
            }
        }

        // method to create vehicle object input
        static Vehicle CreateVehicle(string input)
        {
            try
            {
                // check empty input
                if (string.IsNullOrWhiteSpace(input))
                    throw new Exception("input cannot be empty");

                // split input by comma
                string[] data = input.Split(',');

                // check required number of fields
                if (data.Length != 7)
                    throw new Exception("invalid input format");

                string registrationNo = data[0].Trim();
                string name = data[1].Trim();
                string type = data[2].Trim();

                // parse weight
                double weight = double.Parse(data[3].Trim());

                string ticketNo = data[4].Trim();

                // parse date date format
                DateTime parkedTime = DateTime.ParseExact(data[5].Trim(),"dd-MM-yyyy HH:mm:ss",CultureInfo.InvariantCulture);
                double cost = double.Parse(data[6].Trim());

                // create ticket object
                Ticket ticket = new Ticket(ticketNo, parkedTime, cost);

                // return vehicle object
                return new Vehicle(registrationNo, name, type, weight, ticket);
            }
            catch
            {
                // throw custom error so main handles it
                throw new Exception("invalid vehicle details");
            }
        }
    }
}
