using InsuranceLibrary.Services;
using InsuranceLibrary.Models;

namespace InsuranceConsoleApp
    
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PolicyService service = new PolicyService();
            int choice;

            do
            {
                Console.WriteLine("\nInsurance Policy Management");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Update Policy");
                Console.WriteLine("4. Deactivate Policy");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddPolicy(service);
                        break;

                    case 2:
                        ViewPolicies(service);
                        break;

                    case 3:
                        UpdatePolicy(service);
                        break;

                    case 4:
                        DeactivatePolicy(service);
                        break;

                        break;

                    case 5:
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 5);
        }

        static void AddPolicy(PolicyService service)
        {
            int id;
            Console.Write("Policy ID: ");
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }


            Console.Write("Policy Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Policy Type: ");
            string type = Console.ReadLine();

            decimal premium;
            Console.Write("Premium Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out premium))
            {
                Console.WriteLine("Invalid premium");
                return;
            }


            Console.Write("Policy Term : ");
            int term = int.Parse(Console.ReadLine());

            Console.Write("Is Active : ");
            bool active = bool.Parse(Console.ReadLine());

            InsurancePolicy policy =
                new InsurancePolicy(id, name, type, premium, term, active);

            if (service.AddPolicy(policy))
                Console.WriteLine("Policy added successfully.");
            else
                Console.WriteLine("Policy ID already exists.");

        }

        static void ViewPolicies(PolicyService service)
        {
            var policies = service.GetAllPolicies();

            if (policies.Count == 0)
            {
                Console.WriteLine("No policies available.");
                return;
            }

            foreach (InsurancePolicy p in policies)
            {
                Console.WriteLine(p);
            }
        }

        static void UpdatePolicy(PolicyService service)
        {
            Console.Write("Enter Policy ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("New Premium Amount: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Console.Write("New Policy Term: ");
            int term = int.Parse(Console.ReadLine());

            if (service.UpdatePolicy(id, premium, term))
                Console.WriteLine("Policy updated successfully.");
            else
                Console.WriteLine("Policy not found.");
        }

        static void DeactivatePolicy(PolicyService service)
        {
            Console.Write("Enter Policy ID to deactivate: ");
            int id = int.Parse(Console.ReadLine());

            if (service.DeactivatePolicy(id))
                Console.WriteLine("Policy deactivated.");
            else
                Console.WriteLine("Policy not found.");
        }

    }
}
