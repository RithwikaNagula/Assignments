using System.Text.RegularExpressions;

namespace Requirement3
{
    internal class Program
    {
        // method to validate registration number
        public static bool ValidateRegistrationNo(string registrationNo)
        {
            try
            {
                // check empty or null input
                if (string.IsNullOrWhiteSpace(registrationNo))
                    return false;               
               // exactly 2 uppercase letters,1 or 2 digits,space + 1 or 2 uppercase letters and 1 to 4 digits 
                string pattern = @"^[A-Z]{2} \d{1,2}( [A-Z]{1,2})? \d{1,4}$";
                return Regex.IsMatch(registrationNo, pattern);
            }
            catch
            {
                // if any unexpected error occurs return false
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the registration no. to be validated:");

            try
            {
                string input = Console.ReadLine();

                bool result = ValidateRegistrationNo(input);

                if (result)
                    Console.WriteLine("Registration No is valid");
                else
                    Console.WriteLine("Registration No is invalid");
            }
            catch
            {
                Console.WriteLine("Registration No is invalid");
            }

        }
    }
}
