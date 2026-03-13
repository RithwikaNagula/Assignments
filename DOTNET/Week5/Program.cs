namespace Week5
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            //Exercise1
            Console.Write("Enter number of matches: ");
            int N = int.Parse(Console.ReadLine());

            int term;

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    Console.Write("0 ");
                }
                else
                {
                    term = i * (i + 1) * (i + 2);
                    Console.Write(term + " ");
                }
            }
            Console.WriteLine("\n");

            //Exercise2
            double xa, ya, ra;
            double xb, yb, rb;
            Console.Write("Enter xa: ");
            xa = double.Parse(Console.ReadLine());
            Console.Write("Enter ya: ");
            ya = double.Parse(Console.ReadLine());
            Console.Write("Enter ra: ");
            ra = double.Parse(Console.ReadLine());
            Console.Write("Enter xb: ");
            xb = double.Parse(Console.ReadLine());
            Console.Write("Enter yb: ");
            yb = double.Parse(Console.ReadLine());
            Console.Write("Enter rb: ");
            rb = double.Parse(Console.ReadLine());
            double d = Math.Sqrt((xa - xb) * (xa - xb) + (ya - yb) * (ya - yb));
            if (d + rb < ra)
                Console.WriteLine("B is in A");
            else if (d + ra < rb)
                Console.WriteLine("A is in B");
            else if (d <= ra + rb)
                Console.WriteLine("A and B intersect");
            else
                Console.WriteLine("A and B do not intersect");


            //Exercise 4
            Console.Write("Customer ID:");
            string id = Console.ReadLine();
            Console.Write("Customer Name:");
            string name = Console.ReadLine();
            Console.Write("Address:");
            string address = Console.ReadLine();
            Console.Write("Phone Number:");
            string phone = Console.ReadLine();
            Console.Write("Email ID:");
            string email = Console.ReadLine();
            Console.Write("Connection Type:");
            string type = Console.ReadLine();
            Console.Write("Previous Reading:");
            double prev = double.Parse(Console.ReadLine());
            Console.Write("Current Reading:");
            double cur = double.Parse(Console.ReadLine());

            double units = cur - prev;
            double amount = 0;
            double meterRent = 0;
 
            if (units <= 100)
                amount = units * 1.5;
            else if (units <= 250)
                amount = (100 * 1.5) + (units - 100) * 2.5;
            else if (units <= 550)
                amount = (100 * 1.5) + (150 * 2.5) + (units - 250) * 4.5;
            else
                amount = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + (units - 550) * 7.5;

            if (type == "Industrial")
                meterRent = 2500;
            else if (type == "Business")
                meterRent = 1500;
            else if (type == "Domestic")
                meterRent = 1000;
            else
                meterRent = 0;

            double total = amount + meterRent;
            
            Console.WriteLine("Customer ID : " + id);
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Address : " + address);
            Console.WriteLine("Phone : " + phone);
            Console.WriteLine("Email : " + email);
            Console.WriteLine("Connection: " + type);
            Console.WriteLine("Previous Reading : " + prev);
            Console.WriteLine("Current Reading : " + cur);
            Console.WriteLine("Units Used : " + units);
            Console.WriteLine("Energy Charge : " + amount);
            Console.WriteLine("Total Amount : " + total);



            //Exercise 5
            Console.Write("Enter John's weight:");
            int weight = int.Parse(Console.ReadLine());

            if (weight < 0 || weight > 120)
            {
                Console.WriteLine("Invalid Input");
            }
            else if (weight <= 48)
            {
                Console.WriteLine("light fly");
            }
            else if (weight <= 51)
            {
                Console.WriteLine("fly");
            }
            else if (weight <= 54)
            {
                Console.WriteLine("bantam");
            }
            else if (weight <= 57)
            {
                Console.WriteLine("feather");
            }
            else if (weight <= 60)
            {
                Console.WriteLine("light");
            }
            else if (weight <= 64)
            {
                Console.WriteLine("light welter");
            }
            else if (weight <= 69)
            {
                Console.WriteLine("welter");
            }
            else if (weight <= 75)
            {
                Console.WriteLine("light middle");
            }
            else if (weight <= 81)
            {
                Console.WriteLine("middle");
            }
            else if (weight <= 91)
            {
                Console.WriteLine("light heavy");
            }
            else
            {
                Console.WriteLine("heavy");
            }
        }
    }
}
