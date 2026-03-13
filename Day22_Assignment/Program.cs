namespace MyfirstApp
{
    internal class Program
    {
        //sum of two numbers
        static int sum(int a, int b)
        {
            return a + b;
        }

        //swap two numbers
        void swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("Swapped values:{0}{1}",a,b);
           
        }

        //Average of 4 numbers
        static double CalculateAverage(int a, int b, int c, int d)
        {
            return (a + b + c + d) / 4.0;
        }

        //Remove character by Index
        static string RemoveChar(string s, int index)
        {
            return s.Remove(index, 1);
        }


        //Convert to Lowercase
        static string ConvertToLower(string s)
        {
            return s.ToLower();
        }

        // Logical Operators
        void Logical(bool x, bool y)
        {
            Console.WriteLine("Logical Operators:");
            Console.WriteLine("x&&y:"+(x && y));
            Console.WriteLine("x||y:"+(x || y));
            Console.WriteLine("!x:"+(!x));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(sum(6,7));
            Program p = new Program();
            p.swap(2, 5);
            double avg = CalculateAverage(4,7,9,12);
            Console.WriteLine("Average:"+avg);
            Console.WriteLine(RemoveChar("Hello",2));
            Console.WriteLine(ConvertToLower("DOTNET"));
            p.Logical(true, false);
        }
    }
}


