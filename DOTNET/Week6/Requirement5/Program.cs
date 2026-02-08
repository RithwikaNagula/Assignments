namespace Requirement4
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number of the vehicles:");
                int n = int.Parse(Console.ReadLine());

                List<Vehicle> vehicleList = new List<Vehicle>();

                // read vehicle inputs
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        string input = Console.ReadLine();
                        vehicleList.Add(Vehicle.CreateVehicle(input));
                    }
                    catch
                    {
                        Console.WriteLine("invalid vehicle input");
                        i--;
                    }
                }

                Console.WriteLine("Enter a type to sort:");
                Console.WriteLine("1.Sort by weight");
                Console.WriteLine("2.Sort by parked time");

                int choice = int.Parse(Console.ReadLine());

                // sorting logic
                if (choice == 1)
                {
                    // uses icomparable (weight)
                    vehicleList.Sort();
                }
                else if (choice == 2)
                {
                    // uses icomparer (parked time)
                    vehicleList.Sort(new parkedTimeComparer());
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

                // display heading
                Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}",
                "Registration No", "Name", "Type", "Weight", "Ticket No");

                // display sorted list
                foreach (var v in vehicleList)
                {
                    Console.WriteLine(v);
                }
            }
            catch
            {
                // handle unexpected runtime errors
                Console.WriteLine("unexpected error occurred");
            }
        }
    }
}