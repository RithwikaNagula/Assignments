
namespace ConsoleApp2
{
    internal class CsBasics 
    {
        static void Main(string[] args)
        {
            //Conversion from one datatype to other
            int x = 6;
            string stri = Convert.ToString(x);
            Console.WriteLine(stri);

            Double doub = Convert.ToDouble(stri);
            Console.WriteLine(doub);

            string s = x.ToString();
            Console.WriteLine(s);

            double l = 6;
            double dou = l / 4;//either numerator or denominator must be double to get 1.5 else ans will be 1
            Console.WriteLine(dou);

            string s1 = "12b";
            //Console.WriteLine(int.Parse(s1));//we get runtime exception if invalid input given
            Console.WriteLine(int.TryParse(s1, out int a));//handles exception and give true or false whether conversion is possible or not and also sets default value to 0 and prints it
            Console.WriteLine(a);

            double str1 = 10.0;
            int str2 = 10;
            string str3 = "10";
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str1.Equals(str2));//True
            Console.WriteLine(str1 == str2);//True
            Console.WriteLine(str2.Equals(str3));//False 
            //Console.WriteLine(str2==str3);//compile time error because str and int cannot be compared

            //using Array class methods
            int[] arr = new int[] { 12, 33, 14, 55, 16, 67, 38, 59, 10 };
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", arr));
            Array.Reverse(arr);
            Console.WriteLine(arr);
            Console.WriteLine(string.Join(" ", arr));

            //Copying values from one array to other
            int[] array = { 1, 2, 3, 4, 5 };
            int[] copy = new int[3];
            Array.Copy(array, copy, 3);
            Console.WriteLine(string.Join(" ", copy));
            int[] clone = (int[])array.Clone();
            Console.WriteLine(string.Join(" ", clone));
            //Remove first 2 characters in string
            string b = "Hello";
            Console.WriteLine(b.Remove(0, 2));

            //Jagged array
            int[][] jaggedarr = {
            new int[] { 1,2,3},
            new int[] { 5,9},
            new int[] { 9,4}
            };
            for (int i = 0; i < jaggedarr.Length; i++)
            {
                for (int j = 0; j < jaggedarr[i].Length; j++)
                {
                    Console.Write($"{jaggedarr[i][j]} ");
                }
                Console.WriteLine();
            }
            //using Array class method(sort) on jagged array
            Array.Sort(jaggedarr[2]);
            for (int i = 0;i < jaggedarr.Length; i++)
            {
                for(int j = 0;j < jaggedarr[i].Length;j++)
                {
                    Console.Write($"{jaggedarr[i][j]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
