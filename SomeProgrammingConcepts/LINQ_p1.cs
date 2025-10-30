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
            //var words = new[] { "pear", "apple", "kiwi", "banana", "fig" };
            //    Task:
            //Sort the words first by length(ascending), and then alphabetically(ascending).
            //Use OrderBy and ThenBy.
            //Output: ordered sequence of strings.










            //Exercise L4 – First / Single / Any
            //You are given:
            var values = new[] { 3, 5, 5, 10, 12, 12, 12 };
        //    Tasks:
        //Get the first value greater than 10.
        //Check if there is any value equal to 7 (boolean result).
        //Get the single value equal to 10.
        //(Assume there is exactly one such value – if not, it should fail.)
        //Output: three separate results.







        //Exercise L5 – Distinct and Count
        //You are given:
        //var cities = new[] { "Paris", "Berlin", "Paris", "London", "Berlin", "Rome" };
        //    Tasks:
        //Return all unique city names.
        //Count how many distinct cities there are.
        //Output: sequence of unique strings, and an integer.








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
        //    Exercise L7 – Flatten (SelectMany)
        //    You are given:


        var orders = new[]
        {
            new { OrderId = 1001, Items = new[] { "Milk", "Cheese" } },
            new { OrderId = 1002, Items = new[] { "Beer", "Chips", "Nuts" } },
            new { OrderId = 1003, Items = new[] { "Water" } }
            };
        //    Task:
        //Create a flat sequence of all item names across all orders(no grouping, just a flat list of strings).
        //Then remove duplicates.

        //Output: sequence of unique item names.







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
