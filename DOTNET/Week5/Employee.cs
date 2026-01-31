using SalaryCalculator;
namespace EmployeeApp
{
    internal class Employee
    {
        static void Main(string[] args)
        {
            //Exercise3
            Console.Write("Enter Employee Name:");
            string name = Console.ReadLine();
            Console.Write("Enter Basic Salary:");
            double basicSalary = double.Parse(Console.ReadLine());
            double netSalary = Salary.CalculateNetSalary(basicSalary);
            Console.WriteLine("Employee Name:" + name);
            Console.WriteLine("Basic Salary:" + basicSalary);
            Console.WriteLine("Net Salary:" + netSalary);
        }
    }
}
