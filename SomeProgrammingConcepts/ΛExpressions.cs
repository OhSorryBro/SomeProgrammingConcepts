using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static SomeProgrammingConcepts.ΛExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SomeProgrammingConcepts
{
    internal class ΛExpressions
    {
        public class Product
        {
            public string Name;
            public int Number;

            public Product(string name, int number)
            {
                Name = name;
                Number = number;
            }
        }

        public class Order
        {
            public string[] Ordered = { "Nothing" };

        }
        private class FirstCharComparer : IEqualityComparer<string>
        {
            public bool Equals(string? x, string? y) =>
                (x ?? "").FirstOrDefault() == (y ?? "").FirstOrDefault();

            public int GetHashCode(string obj) => (obj.FirstOrDefault()).GetHashCode();
        }

        public static void Run()
        {
            // Exercise 1 – Anonymous methods → lambdas
            Func<int, int> square = delegate (int x) { return x * x; };
            Func<int, int> squareΛ = x => x * x;

            Func<int, bool> isOdd = delegate (int x) { return x % 2 != 0; };
            Func<int, bool> isOddΛ = x => x % 2 != 0;

            Action<string> print = delegate (string s) { Console.WriteLine(s); };
            Action<string> printΛ = s => Console.WriteLine(s);



            // Exercise 2 – Named method → inline lambda
            bool IsShort(string s) { return s.Length < 5; }
            bool IsShortΛ(string s) => s.Length < 5;

            var names = new[] { "Ann", "Robert", "Ewa", "Tom" };
            var shortOnes = names.Where(IsShort);
            var shortOnesΛ = names.Where(IsShortΛ);




            // Exercise 3 – Multi-parameter lambda
            Func<int, int, int> max = delegate (int a, int b) 
            { if (a > b) return a; else return b; };

            Func<int, int, int> maxΛ = (int a, int b) =>
            {
                if (a > b) { return a; }
                else { return b; }
            };



            // Exercise 4 – Statement lambda (multi-line)
            Func<int, int> fib = delegate (int n)
            {
                if (n <= 1) return n;
                int a = 0, b = 1;
                for (int i = 2; i <= n; i++)
                {
                    int t = a + b; a = b; b = t;
                }
                return b;
            };

            Func<int, int> fibΛ = n =>
            { if (n <= 1) return n;
                int a = 0, b = 1;
                for (int i = 2; i <= n; i++)
                {
                    int t = a + b; a = b; b = t;
                }
                return b;
            };

            // Exercise 5 – LINQ using a named predicate
            bool Expensive(int x) { return x > 100; }

            var nums = Enumerable.Range(50, 100);
            var expensive = nums.Where(Expensive);


            bool ExpensiveΛ(int x) => x > 100;
            var expensiveΛ = nums.Where(ExpensiveΛ);
            var expensiveΛ2 = nums.Where(x=> x > 100);

            // Exercise 5a – Named Predicate: Even Numbers

            //Create a named method that checks if a number is even.
            //Use it inside.Where() to return only even numbers from a sequence 1–50.

            // Example:
            // bool IsEven(int x) => x % 2 == 0;
            // var evens = Enumerable.Range(1, 50).Where(IsEven);
            List<int> xaxa = [1, 2, 3];
            bool namedMethodΛ(int x) => x % 2 == 0;
            var evenNumers = xaxa.Where(namedMethodΛ);
            var odds = Enumerable.Range(1, 30);


            // Exercise 5b – Inline Lambda Predicate: Odd Numbers

            //Write the same filter but as an inline lambda expression instead of a named method.
            //Return all odd numbers from 1–30.
            // Example:
            // var odds = Enumerable.Range(1, 30).Where(x => x % 2 != 0);

            var oddnumbersΛ = odds.Where(x => x % 2 != 0);


            // Exercise 5c – Complex Predicate: Range Filter

            //Filter numbers between inclusive 20 and 80 using a named method predicate.
            //Name it InRange.
            // bool InRange(int x) => x >= 20 && x <= 80;
            // var inRange = Enumerable.Range(1, 100).Where(InRange);

            bool inRangeΛ(int x) => x >= 20 && x <= 80;
            var inRange = xaxa.Where(inRangeΛ);



            // Exercise 5d – Reusable Predicate: Custom Filter Function

            //Write a reusable method:
            static IEnumerable<int> Filter
                (Func<int, bool> predicate, IEnumerable<int> source)
            {
                foreach (var item in source)
                    if (predicate(item))
                        yield return item;
            }
            ;
            // Use it twice:
            // once with a named predicate that filters numbers > 50,
            //once with a lambda that filters numbers < 10.
            // var above50 = Filter(x => x > 50, Enumerable.Range(1,100));
            // var below10 = Filter(x => x < 10, Enumerable.Range(1,100));

            var above50Λ = Filter(x => x > 50, xaxa);
            var below10Λ = Filter(x => x < 10, xaxa);

            // Exercise 5e – Predicate Composition

            //Combine two predicates(e.g., IsEven and GreaterThanTen)
            //to create a new filter that finds numbers satisfying both.
            // bool IsEven(int x) => x % 2 == 0;
            // bool GreaterThanTen(int x) => x > 10;
            // var combined = Enumerable.Range(1, 30)
            //                          .Where(x => IsEven(x) && GreaterThanTen(x));

            bool IsEvenΛ(int x) => x % 2 == 0;
            bool GreaterThanTenΛ(int x) => x > 10;

            var combinedΛ = xaxa.Where(x => IsEvenΛ(x)).Where(x=> GreaterThanTenΛ(x));




            // Exercise 5f – Filtering Objects with Predicate

            //Create a small list of Product objects with properties Name and Price.
            //Write:
            // A named predicate ExpensiveProduct(price > 20).
            //A lambda predicate for ShortName(name length < 5).
            //Then combine them in a single LINQ chain.



            // var products = new list<product> {
            //     new("milk", 2.5m), new("cheese", 15m),
            //     new("butter", 22m), new("bread", 4m)
            // };

            // bool ExpensiveProduct(Product p) => p.Price > 20;
            // var filtered = products.Where(ExpensiveProduct)
            //                        .Where(p => p.Name.Length < 5);


            var products = new List<Product>
            {
                new("milk", 2), new ("Cheese",15)
            };
            bool ExpensiveProductΛ(Product p) => p.Number > 10;
            bool ShortNameΛ(Product p) => p.Name.Length < 5;

            var filteredΛ = products.Where(ExpensiveProductΛ)
                                    .Where(ShortNameΛ);

            // Exercise 6 – SelectMany with a named method
            IEnumerable<char> ToChars(string s) { return s.ToCharArray(); }

            var words = new[] { "ab", "cde", "f" };
            var charsQuery = words.SelectMany(ToChars);

            //Exercise 6a – Words to Characters

            //Given an array of strings, flatten it into a single sequence of all characters
            //using SelectMany.
            //Use a named method that converts a word into a sequence of characters.

            string[] someArray = { "Apple", "Pear", "Banana" };

            var someArrayFlatΛ = someArray.SelectMany(s => s.ToCharArray());

            // Exercise 6b – Sentences to Words

            //You have an array of sentences(each a string).
            //Split each sentence into words and flatten all words into a
            //single list using SelectMany.

            string[] sentencesArray = {"OhSorryBro, i just made a mistake", "Yep you did",
            "I did only 135 mistakes this month"};

            var splitSentenceIntoWords = sentencesArray.SelectMany(s => s.Split());

            // Exercise 6c – Orders to Products

            //You have a list of Order objects, and each Order has a collection of Product names.
            //Use SelectMany to create a single list of all product names across all orders.

            List<Order> listOfOrders = new List<Order>();
            listOfOrders.Add( new Order { Ordered = new[] { "Milk", "Apple" } });
            listOfOrders.Add(new Order { Ordered = new[] { "Milk2", "Apple2" } });
            var allProducts = listOfOrders.SelectMany(o => o.Ordered);


            // Exercise 7 – Sorting keys as lambdas
            string Key1(string s) { return s.Substring(0, 1); }
            int Key2(string s) { return s.Length; }

            var sorted = words
                .OrderBy(Key1)
                .ThenByDescending(Key2);

            // Exercise 7a – Sort Numbers by Absolute Value

            //You have an array of integers(both positive and negative).
            //Sort them in ascending order by their absolute value using a lambda
            //expression inside OrderBy.
            //Then, display the sorted sequence.

            int[] integers = { 3, 10, -3, -10 };
            integers.OrderBy(i => Math.Abs(i));


            // Exercise 7b – Sort Words by Length and Alphabet

            //You have a list of words.
            //First sort them by length(ascending),
            //then by alphabetical order(ascending) using ThenBy.
            //Use lambdas for both keys.

            var words2 = new[] { "ab", "cde", "f" };

            words2.OrderBy(w => w.Length)
                .ThenBy(w => w);


            // Exercise 7c – Sort Products by Price and Name

            //You have a list of Product objects with properties Name and Price.
            //Sort them by Price(descending) and then by Name(ascending).
            //Use lambda expressions as key selectors for both OrderByDescending and ThenBy.

            List<Order> listOfOrders2 = new List<Order>();
            listOfOrders.Add(new Order { Ordered = new[] { "Milk", "Apple" } });
            listOfOrders.Add(new Order { Ordered = new[] { "Milk2", "Apple2" } });



            // Exercise 8 – Join with key selectors and result selector
            var left = new[] { new { Id = 1, Name = "A" }, new { Id = 2, Name = "B" } };
            var right = new[] { new { Id = 10, LId = 1 }, new { Id = 11, LId = 1 }, new { Id = 12, LId = 2 } };

            int LeftKey(dynamic x) { return x.Id; }
            int RightKey(dynamic y) { return y.LId; }

            var joined = left.Join(
                right,
                LeftKey,
                RightKey,
                delegate (dynamic l, dynamic r) { return new { L = l.Name, R = r.Id }; }
            );

            // Exercise 9 – Query syntax → Method syntax
            var q =
                from n in Enumerable.Range(1, 20)
                where n % 3 == 0
                orderby n descending
                select n * n;

            // Exercise 10 – GroupBy with custom comparer
            var animals = new[] { "dog", "deer", "cat", "cow" };
            var g = animals.GroupBy(s => s, new FirstCharComparer());

            // Exercise 11 – Aggregate using a method → lambda
            int SumSquares(int acc, int x) { return acc + x * x; }
            var aggr = Enumerable.Range(1, 5).Aggregate(0, SumSquares);

            // Exercise 12 – Predicates and combined condition
            Predicate<int> p1 = delegate (int x) { return x > 10; };
            Predicate<int> p2 = delegate (int x) { return x % 2 == 0; };
            Func<int, bool> both = delegate (int x) { return p1(x) && p2(x); };

            var filtered = Enumerable.Range(1, 30).Where(both).ToList();


            _ = square(3); _ = isOdd(3); print("ok");
            _ = shortOnes.ToList(); _ = max(1, 2); _ = fib(10);
            _ = expensive.ToList(); _ = charsQuery.ToList(); _ = sorted.ToList();
            _ = joined.ToList(); _ = q.ToList(); _ = g.ToList(); _ = aggr; _ = filtered;
        }
    } 
}     
