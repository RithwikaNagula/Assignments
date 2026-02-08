
namespace Requirement4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number of vehicles:");
                int n = int.Parse(Console.ReadLine());

                List<Vehicle> vehicleList = new List<Vehicle>();

               
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        string input = Console.ReadLine();
                        vehicleList.Add(Vehicle.CreateVehicle(input));
                    }
                    catch
                    {
                        Console.WriteLine("invalid vehicle details");
                        i--;
                    }
                }

                Console.WriteLine("Enter a search type:");
                Console.WriteLine("1.By type");
                Console.WriteLine("2.By parked time");

                int choice = int.Parse(Console.ReadLine());

                VehicleBO bo = new VehicleBO();
                List<Vehicle> result = new List<Vehicle>();

                if (choice == 1)
                {
                    Console.WriteLine("Enter the vehicle type");
                    string type = Console.ReadLine();

                    result = bo.FindVehicle(vehicleList, type);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the parked time:");
                    string date = Console.ReadLine();

                    DateTime parkedTime =
                        DateTime.ParseExact(date,
                        "dd-MM-yyyy HH:mm:ss", null);

                    result = bo.FindVehicle(vehicleList, parkedTime);
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

             
                if (result.Count == 0)
                {
                    Console.WriteLine("No such vehicle is present");
                }
                else
                {
                    Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                    "Registration No", "Name", "Type", "Weight", "Ticket No");

                    foreach (var v in result)
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
            catch
            {
                // catch unexpected runtime errors
                Console.WriteLine("unexpected error occurred");
            }
        }
    }
}
