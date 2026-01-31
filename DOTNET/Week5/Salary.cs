namespace SalaryCalculator
{
    public class Salary
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            try
            {
                if (basicSalary <= 0)
                {
                    throw new Exception("Basic salary must be greater than 0");
                }
                double hra = 0.20 * basicSalary;
                double da = 0.10 * basicSalary;
                double pf = 0;

                if (basicSalary >= 15000)
                {
                    pf = 0.12 * basicSalary;
                }
                double netSalary = basicSalary + hra + da - pf;
                return netSalary;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return 0;
            }
        }
    }
}
