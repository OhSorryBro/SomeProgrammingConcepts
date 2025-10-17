using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    public class Task1
    {
        /*
🔹 Level 1 – Warm-up

1. Hello World with a delegate
Define delegate void MyPrinter(string msg);
        Attach a method that prints "Hello, " + msg.
        Invoke it with "World".
        */

        //Definition of delegate
        public delegate void Myprinter(string msg);
        //Method that matches the delegate signature
        public void Print(string msg)
        {
            Console.WriteLine($"Hello, {msg}");
        }

        public void PrintΛ(string msg) => Console.WriteLine($"Hello, {msg}");


        /*
2. Addition and Multiplication
Define delegate int Operation(int a, int b);
        Create two methods: Add and Multiply.
        Attach them to the delegate and call with different numbers.
        */
        public delegate int Calculation(int a, int b);
        public int Add(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
                return a * b;
        }


    }
}
