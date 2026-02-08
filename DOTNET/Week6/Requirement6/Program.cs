namespace Requirement6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number of vehicles");
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

                // get type wise count
                var result = Vehicle.TypeWiseCount(vehicleList);
                Console.Write("{0,-15} {1}\n", "Type", "No. of Vehicles");

                foreach (var item in result)
                {
                    Console.WriteLine("{0,-15} {1}",
                    item.Key,
                    item.Value);
                }
            }
            catch
            {
                Console.WriteLine("unexpected error occurred");
            }
        }
    }
}
