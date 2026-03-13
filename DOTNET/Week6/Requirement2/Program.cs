
namespace Requirement2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get parking lot name
            Console.WriteLine("Enter the name of the Parking Lot:");
            string name = Console.ReadLine();

            // create parking lot
            ParkingLot parkingLot = new ParkingLot(name, new List<Vehicle>());

            
            while (true)
            {
                Console.WriteLine("1.Add Vehicle");
                Console.WriteLine("2.Delete Vehicle");
                Console.WriteLine("3.Display Vehicles");
                Console.WriteLine("4.Exit");

                Console.WriteLine("Enter your choice:");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        try
                        {
                            string input = Console.ReadLine();

                            Vehicle v = Vehicle.CreateVehicle(input);

                            parkingLot.AddVehicleToParkingLot(v);

                            Console.WriteLine("Vehicle successfully added");
                        }
                        catch
                        {
                            Console.WriteLine("invalid vehicle details");
                        }
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                        string reg = Console.ReadLine();

                        bool result =
                            parkingLot.RemoveVehicleFromParkingLot(reg);

                        if (result)
                            Console.WriteLine("Vehicle successfully deleted");
                        else
                            Console.WriteLine("Vehicle not found in parkinglot");
                    }
                    else if (choice == 3)
                    {
                        parkingLot.DisplayVehicles();
                    }
                    else if (choice == 4)
                    {
                        break;
                    }
                }
                catch
                {
                    // handle invalid menu input
                    Console.WriteLine("invalid choice");
                }
            }
        }
    }
}
