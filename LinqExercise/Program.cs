using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var numSum = numbers.Sum();
            Console.WriteLine($"Sum: {numSum}");  
            //TODO: Print the Average of numbers
            var numAvg = numbers.Average();
            Console.WriteLine($"Average: {numAvg}");
            //TODO: Order numbers in ascending order and print to the console
            var numGoingUp = numbers.OrderBy(num => num);
            Console.WriteLine($"Ascending order:");
            foreach (var item in numGoingUp)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //TODO: Order numbers in descending order and print to the console
            var numGoingDown = numbers.OrderByDescending(num => num);
            Console.WriteLine("Descending order:");
            foreach (var item in numGoingDown)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Printing numbers greater than six:");
            var greaterThanSix = numbers.Where(num => num > 6);
            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Printing only four numbers that are in descending order AND less than 4:");
            var onlyFour = numbers.Where(num => num < 4)
                                  .OrderByDescending(num => num);
            foreach (var item in onlyFour)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Printing descending ordered list WITH my old, decrepit, senile age added in:");
            numbers[4] = 25;
            var withMyAge = numbers.OrderByDescending(num => num);

            foreach (var item in withMyAge)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Printing (in alphabetical order) the names of employees whose FIRST names start with either C or S:");
            var onlyCS = employees.Where(employee => employee.FirstName.ToLower().StartsWith('c') || employee.FirstName.ToLower().StartsWith('s'))
                                  .OrderBy(employee => employee.FirstName);
            foreach (var item in onlyCS)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine();
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Printing employees starting at twenty-six years of age in alphabetical order(first name):");
            var overTwentySix = employees.Where(employee => employee.Age > 26)
                .OrderBy(employee => employee.Age)
                .OrderBy(employee => employee.FirstName);

            foreach (var item in overTwentySix)
            {
                Console.WriteLine(item.FullName, item.Age);
            }
            Console.WriteLine();
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            var filteredExp = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);

            Console.WriteLine($"Sum of employees' years of experience: {filteredExp.Sum(employee => employee.YearsOfExperience)}");
            Console.WriteLine();
            Console.WriteLine($"Average years of experience if less than or equal to 10 years and over the age of 35: {filteredExp.Average(employee => employee.YearsOfExperience)}");
            Console.WriteLine();
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Sneakily granting myself employment by hacking the mainframe:");
            employees = employees.Append(new Employee("Colin", "Reavis", 25, 200)).ToList();
            foreach (var item in employees)
            {
                Console.WriteLine(item.FullName);
            }
            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
