using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    public class Task5
    {
        /*
🔹 Level 5 – Mixed scenarios
9. Math quiz
    Have a list of questions like (2,3,Add) → expected answer 5.
    Delegate Operation decides how to calculate the result.
    Ask the user and check correctness.
       */
        public List<string> questions = new List<string>();
        public delegate int Operation(int a, int b);
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Division(int a, int b)
        {
            return a / b;
        }







        /*
10. Number game
    For numbers 1–10, attach different “actions”: Square, Double, PrintStars (e.g., 3 → "***").
    Run all actions in sequence for each number.
       */
        public List<int> numbers = new List<int>();
        public delegate int TestDel (int a);
        public int Square(int a)
        {
        int firstvalue = a;
        int result = firstvalue;
        for(int i = 0; i < a ; i++)
            {
                result = result * firstvalue;
            }
        return  result;
        }
        public int Double(int a)
        {
            return a * 2;
        }
        public void PrintStars(int a)
        {
            Console.WriteLine(a * '*');
        }

    }
}
