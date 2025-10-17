using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    internal class Task3
    {
        /*
🔹 Level 3 – Strategy pattern

5. Choose an algorithm
    Write a method RunOperation(int a, int b, Operation op).
    Pass in different operations: Add, Subtract, Multiply, Max.
    See how the same method works differently depending on the delegate.
               */
        public delegate int Operation(int a, int b);
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int AddΛ(int a, int b) => a + b;
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int SubtractΛ(int a, int b) => a - b;
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int MultiplyΛ(int a, int b) => a * b;
        public int Max(int a, int b)
        {
            return Math.Max(a, b);
        }
        public int MaxΛ(int a, int b) => Math.Max(a, b);

        public int RunOperation(int a, int b, Operation o)
        {
            return o(a, b)
                ;
        }
        public int RunOperationΛ(int a, int b, Operation o) => o(a, b);

        public void PrintResult(int Result, Operation o)
        {
            Console.WriteLine($"Result of {o.Method.Name}: {Result}");
        }
        PrintResultΛ(int Result, Operation o) => Console.WriteLine($"Result of {o.Method.Name}: {Result}");


        /*
6. Filtering a list
    Define delegate bool Filter(int x);
    Write a function that accepts a list of numbers and a filter, and returns only the matching values.
    Try filters like: “even numbers”, “greater than 10”, “divisible by 3”.

        */
        public delegate bool Filter(int x);
        public List<int> FilterList(List<int> numbers, Filter f)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (f(number))
                {
                    result.Add(number);
                }
            }
            return result;

        }
        public bool IsEven(int x)
        {
            return x % 2 == 0;
        }
        public bool IsEvenΛ(int x) => x % 2 == 0;
        public bool IsGreaterThan10(int x)
        {
            return x > 10;
        }
        public bool IsGreaterThan10Λ(int x) => x > 10;
        public bool IsDivisibleBy3(int x)
        {
            return x % 3 == 0;
        }
        public bool IsDivisibleBy3Λ(int x) => x % 3 == 0;

        public void PrintFilteredList(List<int> filteredNumbers)
        {
            Console.WriteLine("Filtered numbers: " + string.Join(", ", filteredNumbers));
        }
        public void PrintFilteredListΛ(List<int> filteredNumbers) => Console.WriteLine("Filtered numbers: " + string.Join(", ", filteredNumbers));
    }
}
