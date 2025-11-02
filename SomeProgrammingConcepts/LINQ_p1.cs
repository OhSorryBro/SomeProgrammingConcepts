using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using static SomeProgrammingConcepts.ΛExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SomeProgrammingConcepts
{
    internal class LINQ_p1
    {
        //        Exercise L1 – Basic filtering
        public static void Run() { 
        //You are given an array of integers:
        int[] nums = { 2, 5, 7, 10, 12, 15, 20 };
            //        Task:
            //Return all numbers greater than 10 using LINQ.
            //Output: a sequence of integers.

            var LINQ1 = from num in nums
                        where num > 10
                        select num;

         //Exercise L2 – Projection (Select)
         //You are given a list of strings (names):
         var names = new[] { "Anna", "Robert", "Ewa", "Tom" };
            //        Task:
            //Project this list into a new sequence of objects with the shape:
            //{ OriginalName, Length
            //    },
            //where OriginalName is the name, and Length is the number of characters.
            //Output: sequence of anonymous objects.

            var QueryL2 = from name in names
                          select new { OriginalName = name, Length = name.Length };

         //Exercise L2a – Project numbers into objects
            // Given a list of integers:
            var numbers = new[] { 1, 5, 10, 15, 20 };

            // Task:
            // Project this list into a new sequence of anonymous objects with the shape:
            // { Number, IsEven, Square }
            // where:
            // - Number is the original value,
            // - IsEven is true if the number is even,
            // - Square is the number multiplied by itself.

            var QueryL2a = from number in numbers
                           select new {Number = number, 
                                        IsEven = number % 2 == 0,
                                        Square = number * number};

            //Exercise L2b – Project people into simplified objects
            // Given a list of people (with name and age):
            var people = new[]
            {
                new { Name = "Alice", Age = 25 },
                new { Name = "Bob", Age = 32 },
                new { Name = "Carla", Age = 19 },
                new { Name = "David", Age = 40 }
            };
            // Task:
            // Project this list into a sequence of anonymous objects with:
            // { NameUpper, AgeGroup }
            // where:
            // - NameUpper is the uppercase name,
            // - AgeGroup is "Young" if < 30, otherwise "Adult".

            var QueryL2b = from person in people
                           select new { NameUpper = person.Name.ToUpper(),
                               AgeGroup = person.Age > 30? "Adult": "Young"
                           };

            //Exercise L2c – Project words into custom structure
            // Given an array of words:
            var words = new[] { "tree", "forest", "bush", "flower", "grass" };

            // Task:
            // Create a projection that returns:
            // { Word, Length, StartsWithF }
            // where:
            // - Word is the original word,
            // - Length is number of letters,
            // - StartsWithF is true if word begins with 'f' or 'F'.


            var QueryL3c = from word in words
                           select new
                           {
                               Word = word,
                               Length = word.Length,
                               StartsWithF = word.StartsWith('f') || word.StartsWith('F')
                           };

            //Exercise L3 – Ordering with multiple keys
            //You are given:
            var words2 = new[] { "pear", "apple", "kiwi", "banana", "fig" };
            //    Task:
            //Sort the words first by length(ascending), and then alphabetically(ascending).
            //Use OrderBy and ThenBy.
            //Output: ordered sequence of strings.

            var QueryL3 = words2
                .OrderBy(word => word.Length)
                .ThenBy(word => word);


            // =======================================================
            // Exercise L3a – Simple Ordering
            // =======================================================
            // Given an array of words:
              var wordsL3a = new[] { "pear", "apple", "kiwi", "banana", "fig" };
            //
            // Task:
            //   Sort the words alphabetically (ascending).
            //   Use OrderBy.
            //
            // Expected output:
            //   apple
            //   banana
            //   fig
            //   kiwi
            //   pear
            // =======================================================
            var QueryL3a = wordsL3a
                .OrderBy(word => word);

            // =======================================================
            // Exercise L3b – Ordering by Length
            // =======================================================
            // Given the same array of words:
               var wordsL3b = new[] { "pear", "apple", "kiwi", "banana", "fig" };
            //
            // Task:
            //   Sort the words by their length (ascending).
            //   Use OrderBy.
            //
            // Expected output:
            //   fig
            //   kiwi
            //   pear
            //   apple
            //   banana
            // =======================================================
            var QueryL3b = wordsL3b
                .OrderBy(word => word.Length);

            // =======================================================
            // Exercise L3c – Ordering with Multiple Keys
            // =======================================================
            // Given:
               var wordsL3c = new[] { "pear", "apple", "kiwi", "banana", "fig" };
            //
            // Task:
            //   Sort the words first by length (ascending),
            //   and then alphabetically (ascending).
            //   Use OrderBy and ThenBy.
            //
            // Expected output:
            //   fig
            //   kiwi
            //   pear
            //   apple
            //   banana
            // =======================================================
            var QueryL3cNew = wordsL3c
                .OrderBy(word => word.Length)
                .ThenBy(word => word);


            //Exercise L4 – First / Single / Any
            //You are given:
            var values = new[] { 3, 5, 5, 10, 12, 12, 12 };
            //    Tasks:
            //Get the first value greater than 10.
            //Check if there is any value equal to 7 (boolean result).
            //Get the single value equal to 10.
            //(Assume there is exactly one such value – if not, it should fail.)
            //Output: three separate results.

            var QueryL4 = values
                .First(x => x > 10);

            var QueryL4Any = values
                .Any(x => x == 7);

            var QueryL4Single = values
                .Single(x => x == 10);

            // =======================================================
            // Exercise L4a – First / Single / Any (Fruits)
            // =======================================================
            // Given an array of fruits:
               var fruits = new[] { "apple", "pear", "banana", "kiwi", "plum", "banana" };
            //
            // Tasks:
            // 1. Get the first fruit that starts with the letter 'b'.
            // 2. Check if there is any fruit with more than 6 letters (boolean result).
            // 3. Get the single fruit that equals "kiwi".
            //    (Assume there is exactly one such fruit – if not, it should fail.)
            //
            // Output: three separate results.
            // =======================================================

            var QueryL4aFirst = fruits
                .First(f => f.StartsWith('b'));

            var QueryL4aAny = fruits
                .Any(f => f.Length > 6);

            var QueryL4aSingle = fruits
                .Single(f => f == "kiwi");

            // =======================================================
            // Exercise L4b – First / Single / Any (Temperatures)
            // =======================================================
            // Given an array of temperatures in Celsius:
               var temps = new[] { -5, 0, 3, 10, 10, 15, 22, 25 };
            //
            // Tasks:
            // 1. Get the first temperature that is above freezing (greater than 0).
            // 2. Check if there is any temperature equal to 30 (boolean result).
            // 3. Get the single temperature equal to 15.
            //    (Assume there is exactly one such value – if not, it should fail.)
            //
            // Output: three separate results.
            // =======================================================

            var QueryL4bFirst = temps
                .First(t => t > 0);

            var QueryL4bAny = temps
                .Any(t => t == 30);

            var QueryL4bSingle = temps
                .Single(t => t == 15);

            // =======================================================
            // Exercise L4c – First / Single / Any (Employees)
            // =======================================================
            // Given an array of employee ages:
               var ages = new[] { 19, 25, 32, 32, 45, 50 };
            //
            // Tasks:
            // 1. Get the first employee age greater than 40.
            // 2. Check if there is any employee age below 18 (boolean result).
            // 3. Get the single employee age equal to 50.
            //    (Assume there is exactly one such value – if not, it should fail.)
            //
            // Output: three separate results.
            // =======================================================


            var QueryL4cFirst = ages
                .First(a => a > 40);

            var QueryL4cAny = ages
                .Any(a => a < 18);

            var QueryL4cSingle = ages
                .Single(a => a == 50);

            //Exercise L5 – Distinct and Count
            //You are given:
            var cities = new[] { "Paris", "Berlin", "Paris", "London", "Berlin", "Rome" };
            //    Tasks:
            //Return all unique city names.
            //Count how many distinct cities there are.
            //Output: sequence of unique strings, and an integer.

            var QueryL5Dist = cities
                .Distinct();
            
            var QueryL5Count = QueryL5Dist
                .Count();

            // =======================================================
            // Exercise L5a – Distinct and Count (Animals)
            // =======================================================
            // Given an array of animal names:
              var animals = new[] { "cat", "dog", "bird", "dog", "cat", "lion", "tiger" };
            //
            // Tasks:
            // 1. Return all unique animal names.
            // 2. Count how many distinct animals there are.
            // Output: sequence of unique strings, and an integer.
            // =======================================================

            var QueryL5aDist = animals
                .Distinct();

            var QueryL5aCount = QueryL5aDist
                .Count();


            // =======================================================
            // Exercise L5b – Distinct and Count (Numbers)
            // =======================================================
            // Given an array of integers:
              var numbers2 = new[] { 10, 5, 10, 20, 5, 30, 40, 30 };
            //
            // Tasks:
            // 1. Return all unique numbers.
            // 2. Count how many distinct numbers there are.
            // Output: sequence of unique integers, and an integer.
            // =======================================================

            var QueryL5b = numbers2
                .Distinct();

            var QueryL5bCount = QueryL5b
                .Count();


            // =======================================================
            // Exercise L5c – Distinct and Count (Countries)
            // =======================================================
            // Given an array of country names:
              var countries = new[] { "Netherlands", "Belgium", "France", "Germany", "France", "Italy", "Germany" };
            //
            // Tasks:
            // 1. Return all unique country names.
            // 2. Count how many distinct countries there are.
            // Output: sequence of unique strings, and an integer.
            // =======================================================

            var QueryL5c = countries
                .Distinct();
            var QueryL5cCount = QueryL5c
                .Count();


            //Exercise L6 – Grouping
            //You are given:
            var people2 = new[]
            {
                new { Name = "Anna",   Country = "NL" },
                new { Name = "Mark",   Country = "NL" },
                new { Name = "Eva",    Country = "DE" },
                new { Name = "Luca",   Country = "IT" },
                new { Name = "Mario",  Country = "IT" },
            };
            //    Task:
            //Group people by Country.
            //For each country, return an object:
            //{ Country, People = [all names from that country] }
            //    Output: sequence of anonymous objects.

            var QueryL6 = people2
                .GroupBy(p => p.Country)
                .Select (g => new {Country = g.Key, People = g});

            // =======================================================
            // Exercise L6a – Grouping (Students by Grade)
            // =======================================================
            // Given an array of students:
            var students = new[]
            {
                   new { Name = "Alice",  Grade = "A" },
                   new { Name = "Bob",    Grade = "B" },
                   new { Name = "Carla",  Grade = "A" },
                   new { Name = "David",  Grade = "C" },
                   new { Name = "Eva",    Grade = "B" },
               };

            // Tasks:
            // 1. Group students by their Grade.
            // 2. For each grade, return an object:
            //    { Grade, Students = [all names with that grade] }
            // Output: sequence of anonymous objects.
            // =======================================================

            var QueryL6a = students
                .GroupBy(s => s.Grade)
                .Select(g => new { Grade = g.Key, Students = g });


            // =======================================================
            // Exercise L6b – Grouping (Products by Category)
            // =======================================================
            // Given an array of products:
            var products = new[]
            {
                   new { Name = "Milk",     Category = "Dairy" },
                   new { Name = "Cheese",   Category = "Dairy" },
                   new { Name = "Apple",    Category = "Fruit" },
                   new { Name = "Banana",   Category = "Fruit" },
                   new { Name = "Bread",    Category = "Bakery" },
               };
            //
            // Tasks:
            // 1. Group products by their Category.
            // 2. For each category, return an object:
            //    { Category, Products = [all names in that category] }
            // Output: sequence of anonymous objects.
            // =======================================================

            var QueryL6b = products
                .GroupBy(p => p.Category)
                .Select(g => new {Category = g.Key, Products = g.Select(s=> s.Name)});


            // =======================================================
            // Exercise L6c – Grouping (Employees by Department)
            // =======================================================
            // Given an array of employees:
            var employees = new[]
            {
                   new { Name = "John",  Department = "HR" },
                   new { Name = "Lisa",  Department = "IT" },
                   new { Name = "Tom",   Department = "IT" },
                   new { Name = "Nina",  Department = "Finance" },
                   new { Name = "Sara",  Department = "HR" },
               };
            //
            // Tasks:
            // 1. Group employees by their Department.
            // 2. For each department, return an object:
            //    { Department, Employees = [all names in that department] }
            // Output: sequence of anonymous objects.
            // =======================================================

            var QueryL6c = employees
                .GroupBy(e => e.Department)
                .Select(g => new { Department = g.Key, Employees = g.Select(g => g.Name) });


            //    Exercise L7 – Flatten (SelectMany)
            //    You are given:

            var orders = new[]
            {
                new { OrderId = 1001, Items = new[] { "Milk", "Cheese" } },
                new { OrderId = 1002, Items = new[] { "Beer", "Chips", "Nuts" } },
                new { OrderId = 1003, Items = new[] { "Water" } }
                };
            //    Task:
            //Create a flat sequence of all item names across all 
            //orders(no grouping, just a flat list of strings).
            //Then remove duplicates.

            //Output: sequence of unique item names.

            var QueryL7 = orders
                .SelectMany(o => o.Items)
                .Distinct();

            // =======================================================
            // Exercise L7a – Flatten (Books and Authors)
            // =======================================================
            //Given an array of books:
            var books = new[]
            {
                   new { Title = "Book A", Authors = new[] { "Alice", "Bob" } },
                   new { Title = "Book B", Authors = new[] { "Carla" } },
                   new { Title = "Book C", Authors = new[] { "Bob", "David" } },
               };
            //
            // Tasks:
            // 1. Create a flat sequence of all author names across all books.
            // 2. Remove duplicates.
            // Output: sequence of unique author names.
            // =======================================================

            var QueryL7a = books
                .SelectMany(b => b.Authors)
                .Distinct();

            // =======================================================
            // Exercise L7b – Flatten (Students and Courses)
            // =======================================================
            // Given an array of students:
            var students2 = new[]
            {
                   new { Name = "John",  Courses = new[] { "Math", "Physics" } },
                   new { Name = "Lisa",  Courses = new[] { "Biology", "Math" } },
                   new { Name = "Mark",  Courses = new[] { "Chemistry", "Math", "Biology" } },
               };

            // Tasks:
            // 1. Create a flat sequence of all course names across all students.
            // 2. Remove duplicates.
            // Output: sequence of unique course names.
            // =======================================================

            var QueryL7b = students2
                .SelectMany(s => s.Courses)
                .Distinct();


            // =======================================================
            // Exercise L7c – Flatten (Companies and Departments)
            // =======================================================
            // Given an array of companies:
            var companies = new[]
            {
                   new { Name = "TechCorp",   Departments = new[] { "IT", "HR", "Finance" } },
                   new { Name = "LogiTrans",  Departments = new[] { "Logistics", "IT" } },
                   new { Name = "MediCare",   Departments = new[] { "HR", "Health", "Finance" } },
               };

            // Tasks:
            // 1. Create a flat sequence of all department names across all companies.
            // 2. Remove duplicates.
            // Output: sequence of unique department names.
            // =======================================================


            var QueryL7c = companies
                .SelectMany(c => c.Departments)
                .Distinct();

            //Exercise L8 – Join
            //You are given:
            var customers = new[]
            {
                new { CustomerId = 1, Name = "FrieslandCampina" },
                new { CustomerId = 2, Name = "Heineken" },
                new { CustomerId = 3, Name = "Nabuurs" }
            };

            var orders2 = new[]
            {
                new { OrderId = 5001, CustomerId = 1 },
                new { OrderId = 5002, CustomerId = 2 },
                new { OrderId = 5003, CustomerId = 2 },
                new { OrderId = 5004, CustomerId = 3 }
            };

            //    Task:
            //Join customers with orders2 on CustomerId.
            //Return an object for each match:
            //{ CustomerName, OrderId }.
            //Output: sequence of anonymous objects.

            var QueryL8 = customers.Join(orders2
                , customer => customer.CustomerId
                , order => order.CustomerId
                , (customer, order) => new { CustomerName = customer.Name, OrderId = order.OrderId}
                );


            // =======================================================
            // Exercise L8a – Join (Students and Grades)
            // =======================================================
            // Given two arrays:

            var studentsL8a = new[]
            {
                   new { StudentId = 1, Name = "Alice" },
                   new { StudentId = 2, Name = "Bob" },
                   new { StudentId = 3, Name = "Carla" },
               };

            var gradesL8a = new[]
            {
                   new { StudentId = 1, Grade = "A" },
                   new { StudentId = 2, Grade = "B" },
                   new { StudentId = 3, Grade = "A" },
               };

            // Tasks:
            // 1. Join students with grades on StudentId.
            // 2. Return an object for each match:
            //    { StudentName, Grade }.
            // Output: sequence of anonymous objects.
            // =======================================================

            var QueryL8a = studentsL8a.Join(gradesL8a,
                students => students.StudentId,
                grades => grades.StudentId,
                (students, grades) => new { StudentName = students.Name, Grade = grades.Grade }
                );
                


            // =======================================================
            // Exercise L8b – Join (Employees and Departments)
            // =======================================================
            // Given two arrays:

            var employeesL8b = new[]
            {
                   new { EmpId = 1, Name = "John" },
                   new { EmpId = 2, Name = "Lisa" },
                   new { EmpId = 3, Name = "Tom" },
               };

            var departmentsL8b = new[]
            {
                   new { EmpId = 1, Department = "HR" },
                   new { EmpId = 2, Department = "IT" },
                   new { EmpId = 3, Department = "Finance" },
               };
            //
            // Tasks:
            // 1. Join employees with departments on EmpId.
            // 2. Return an object for each match:
            //    { EmployeeName, Department }.
            // Output: sequence of anonymous objects.
            // =======================================================

            var QueryL8b = employeesL8b.Join(
                departmentsL8b,
                employeesKey => employeesKey.EmpId,
                departmentsKey => departmentsKey.EmpId,
                (employeesKey, departmentsKey) => new { EmployeeName = employeesKey.Name,
                    Department = departmentsKey.Department });


            // =======================================================
            // Exercise L8c – Join (Orders and Customers)
            // =======================================================
            // Given two arrays:

            var customersL8c = new[]
            {
                   new { Id = 1, Name = "FrieslandCampina" },
                   new { Id = 2, Name = "Heineken" },
                   new { Id = 3, Name = "Nabuurs" },
               };

            var ordersL8c = new[]
            {
                   new { OrderId = 1001, CustomerId = 1 },
                   new { OrderId = 1002, CustomerId = 2 },
                   new { OrderId = 1003, CustomerId = 3 },
                   new { OrderId = 1004, CustomerId = 2 },
               };
            //
            // Tasks:
            // 1. Join customers with orders on CustomerId.
            // 2. Return an object for each match:
            //    { CustomerName, OrderId }.
            // Output: sequence of anonymous objects.
            // =======================================================




            // =======================================================
            // Exercise L8d – Join (Products and Categories)
            // =======================================================
            // Given two arrays:

            var productsL8d = new[]
            {
                   new { Id = 1, Name = "Milk", CategoryId = 10 },
                   new { Id = 2, Name = "Cheese", CategoryId = 10 },
                   new { Id = 3, Name = "Banana", CategoryId = 20 },
                   new { Id = 4, Name = "Bread", CategoryId = 30 },
               };

            var categoriesL8d = new[]
            {
                   new { CategoryId = 10, CategoryName = "Dairy" },
                   new { CategoryId = 20, CategoryName = "Fruit" },
                   new { CategoryId = 30, CategoryName = "Bakery" },
               };
            //
            // Tasks:
            // 1. Join products with categories on CategoryId.
            // 2. Return an object for each match:
            //    { ProductName, CategoryName }.
            // Output: sequence of anonymous objects.
            // =======================================================




            // =======================================================
            // Exercise L8e – Join (Books and Publishers)
            // =======================================================
            // Given two arrays:

            var booksL8e = new[]
            {
                   new { Id = 1, Title = "C# Basics", PublisherId = 100 },
                   new { Id = 2, Title = "LINQ Mastery", PublisherId = 200 },
                   new { Id = 3, Title = "Data Structures", PublisherId = 100 },
               };

            var publishersL8e = new[]
            {
                   new { PublisherId = 100, Name = "TechPress" },
                   new { PublisherId = 200, Name = "CodeHouse" },
               };

            // Tasks:
            // 1. Join books with publishers on PublisherId.
            // 2. Return an object for each match:
            //    { BookTitle, PublisherName }.
            // Output: sequence of anonymous objects.
            // =======================================================





            //Exercise L9 – Aggregation and summary per group

            //You are given:
            var lines = new[]
            {
            new { OrderId = 5001, Product = "Milk",   Qty = 10, Price = 1.20m },
            new { OrderId = 5001, Product = "Cheese", Qty =  5, Price = 3.50m },
            new { OrderId = 5002, Product = "Beer",   Qty = 20, Price = 1.10m },
            new { OrderId = 5002, Product = "Chips",  Qty = 10, Price = 0.80m },
            new { OrderId = 5003, Product = "Beer",   Qty = 30, Price = 1.15m },
            };


            //    Task:
            //For each OrderId, calculate:
            //TotalQty = sum of all quantities for that order,
            //TotalValue = sum of Qty * Price for that order.
            //Return a sequence of:
            //{ OrderId, TotalQty, TotalValue }.
            //Then sort the result by TotalValue descending.
            //Output: ordered sequence of anonymous objects.







            //Exercise L10 – Build a report-style structure
            //You are given the same customers, orders2, and lines from L8/L9.
            //Task:
            //Build a sequence where each element represents a customer and looks like this:

            //{
            //    CustomerName: "...",
            //    Orders: [
            //        {
            //            OrderId: ...,
            //            TotalValue: ...,
            //            Products: [ "Milk", "Cheese", ... ] // unique product names in that order
            //        },
            //        ...
            //    ],
            //    GrandTotalValue: ... // sum of TotalValue of all that customer's orders
            //}


            //Requirements:
            //A customer with multiple orders should have multiple entries in Orders.
            //If an order has multiple lines with the same product name, only list that product once in Products.
            //Sort each customer's Orders by TotalValue descending.
            //Sort the customers themselves by GrandTotalValue descending.
            //Output: complex hierarchical anonymous objects.
            //(This is the “mini-report” task. If you can do this cleanly, to be blunt, you’re dangerous for a junior interview.)



        }
    }
}
