using System.Globalization;

namespace Requirement1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Vehicle 1 details:");
            string input1 = Console.ReadLine();

            Console.WriteLine("Enter Vehicle 2 details:");
            string input2 = Console.ReadLine();

            Vehicle v1 = CreateVehicle(input1);
            Vehicle v2 = CreateVehicle(input2);

            Console.WriteLine("Vehicle 1");
            Console.WriteLine(v1);

            Console.WriteLine();

            Console.WriteLine("Vehicle 2");
            Console.WriteLine(v2);

            Console.WriteLine();

            if (v1.Equals(v2))
                Console.WriteLine("Vehicle 1 is same as Vehicle 2");
            else
                Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
        }

      
        static Vehicle CreateVehicle(string input)
        {
            string[] data = input.Split(',');

            string registrationNo = data[0];
            string name = data[1];
            string type = data[2];
            double weight = double.Parse(data[3]);

            string ticketNo = data[4];
            DateTime parkedTime = DateTime.ParseExact(data[5], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            double cost = double.Parse(data[6]);
            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);

            return new Vehicle(registrationNo, name, type, weight, ticket);
        }
    }
}
