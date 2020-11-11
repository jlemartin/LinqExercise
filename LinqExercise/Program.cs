using System;
using System.Collections.Generic;
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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sumNums = numbers.Sum();
            Console.WriteLine($"The sum of the numbers is {sumNums}");

            var avgNums = numbers.Average();
            Console.WriteLine($"The average of the numbers is {avgNums}");
            Console.WriteLine();

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(n => n);
            Console.WriteLine("Printing numbers in ascending order:");
            foreach (var n in ascending)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            var descending = numbers.OrderByDescending(n => n);
            Console.WriteLine("Printing numbers in descending order:");
            foreach (var n in descending)
            {
                Console.WriteLine(n);
            }

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("Numbers greater than 6:");
            foreach (var n in greaterThanSix)
            {
                Console.WriteLine(n);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var orderFour = numbers.OrderBy(n => n).Take(4);
            Console.WriteLine("Printing only 4 from ordered list;");
            foreach (var n in orderFour)
            {
                Console.WriteLine(n);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            // numbers[4] = 61; <-- old way
            // New way:
            numbers.SetValue(61, 4);
            var descWithAge = numbers.OrderByDescending(n => n);
            Console.WriteLine("Printing numbers (with age addition) in descending order:");
            foreach (var n in descWithAge)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("employees' FullName properties to the console only if their FirstName starts with a C OR an S");
            var empCS = employees.Where(fn => fn.FirstName[0] is 'C' || fn.FirstName[0] is 'S').OrderBy(n => n.FirstName);
            foreach (var e in empCS)
            {
                Console.WriteLine(e.FullName);
            }
            Console.WriteLine();

            Console.WriteLine("employees' FullName and Age who are over the age 26");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var empAge = employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName);
            foreach (var e in empAge)
            {
                Console.WriteLine($"{e.FullName}, {e.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var empYOE = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35);
            var sumYOE = empYOE.Sum(e => e.YearsOfExperience);
            var avgYOE = empYOE.Average(e => e.YearsOfExperience);
            Console.WriteLine($" Sum of Years of Exeperience: {sumYOE}");
            Console.WriteLine($" Average Years of Experience: {avgYOE}");

            Console.WriteLine();

            Console.WriteLine("Adding an employee to list");
            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Robert", "Frost", 35, 10)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FullName}");
            }

            Console.WriteLine();

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
