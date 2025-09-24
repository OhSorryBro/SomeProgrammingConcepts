using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SomeProgrammingConcepts
{
    internal class RealDelegates2
    {



//        Level 2 – Functional operations
//4. Function composition
//Write a method Compose(Func<int, int> f1, Func<int, int> f2) that returns a new function
//Func<int, int>, which executes f1 first and then f2.

        public Func<int, int> Compose(Func<int, int> f1, Func<int, int> f2)
        {
            return x => f2(f1(x));
        }
        public int AddOne(int x)
        {
            return x + 1;
        }
        public int AddTwo(int x)
        {
            return x + 2;
        }


//5. Aggregation with a function
//Write a method that takes an array of int[] and a Func<int, int, int> (e.g., sum, max, min).
//Apply it across the whole array (like Aggregate).
        
        public int DoOperation(int[] numbers, Func<int,int,int> operation)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Array is null or empty");
            }
            else
            {
                int result = numbers[0];
                for (int i = 1; i <numbers.Length; i++)
                {
                    result = operation(result, numbers[i]);
                }
                return result;
            }
        }
        internal int Sum(int a, int b)
        {
            return a + b;
        }
        internal int Max(int a, int b)
        {
            return Math.Max(a, b);

        }
        internal int Min(int a, int b)
        {
            return Math.Min(a, b);
        }




        //6. Mapping with a final action
        //Write a method that takes a Func<string, string> and an Action<string>.
        //For a list of strings, first transform each with the function, then apply the action
        //(e.g., ToUpper + Console.WriteLine).

        public void TransformString (string x, Func<string, string> transformer, Action<string> action)
        {
            var transformed = transformer(x);
            action(transformed);
        }
        public string ToUpp(string x)
        { return x.ToUpper(); }

        public void PrintString(string str)
        {
            Console.WriteLine(str);
        }

    }
}
