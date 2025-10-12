using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace SomeProgrammingConcepts
{
    public class RealDelegates1
    {



//        Level 1 – Basics

// 1. Filtering a list
//Write a method that takes a list of integers and a Func<int, bool>.
//Return only the numbers for which the delegate returns true (mini version of LINQ’s Where).
      Func<int, bool> filterFunc = num=> num % 2 == 0; // Example: filter even numbers
        public List<int> FilterList(List<int> numbers, Func <int, bool>filterFunc)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (filterFunc(number))
                {
                    result.Add(number);
                }
            }
            return result;
        }

        public void PrintList(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        public void PrintListΛ(List<int> numbers) => numbers.ForEach(Console.WriteLine);


        //2.  Transforming a list
        //Write a method that takes a list of strings and a Func<string, int>.
        //Return a list of word lengths.
        Func<string, int> lengthFunc; // Example: get string lengths
        public List<int> TransformList(List<string> strings, Func<string, int> lengthFunc)
        {
            var result = new List<int>();
            foreach (var str in strings)
            {
                result.Add(lengthFunc(str));
            }
            return result;
        }




        //3. Performing an action on each element
        //Write a method that takes a list of integers and an Action<int>.
        //Execute the action for each element (e.g., print it).
        public void PerformAction(List<int> numbers, Action<int> action)
        {
            foreach (var number in numbers)
            {
                action(number);
            }
        }
        public void PerformActionΛ(List<int> numbers, Action<int> action) => numbers.ForEach(action);
        public void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }
        public void PrintNumberΛ(int number) => Console.WriteLine(number);
        Func<int,int> x = xa => 2 * 3;
        Func<int, int> ya = y => y + 3;

        public void PrintNumberTwice(int number)
        {
            Console.WriteLine(number);
            Console.WriteLine(number);
        }
        public void PrintNumberTwiceΛ(int number) => Console.WriteLine(number);
        

    }
}
