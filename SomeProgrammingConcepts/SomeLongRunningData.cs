using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SomeProgrammingConcepts.Delegates;

namespace SomeProgrammingConcepts
{
    public class SomeLongRunningData
    {
        public delegate void Callback(int i);
        public void SomeMethod(Callback obj)
        { 
            for (int i = 1; i < 999999999; i++)
            {
                int z = 69;   // Simulate long-running operation
                int x = 69;
                int y1 = z * x;
                int z2 = z * (x + 1);
                int z3 = z2 * (x + 2);
                int z4 = z3 * (x + 3);
                int z5 = z4 * (x + 4);
                int z6 = z5 * (x + 5);
                int z7 = z6 * (x + 6);
                int z8 = z7 * (x + 7);
                int z9 = z8 * (x + 8);
                int z10 = z9 * (x + 9);
                int z11 = z10 * (x + 10);
                int z12 = z11 * (x + 11);
                int z13 = z12 * (x + 12);
                int z14 = z13 * (x + 13);
                int z15 = z14 * (x + 14);
                int z16 = z15 * (x + 15);
                int z17 = z16 * (x + 16);
                int z18 = z17 * (x + 17);
                int z19 = z18 * (x + 18);
                int z20 = z19 * (x + 19);
                GC.KeepAlive(z20);
                obj(i);
            }

        }
        public static void  CallBackMethod(int i)
        {

            if (i % 100000000 == 0)
            {
                Console.Write($"-{i}-");
            }
        }

        public static void CallBackMethod2(int i)
        {

            if (i % 10000000 == 0)
            {
                Console.Write($"-{i}-");
            }
        }

        public int Add(int x, int y) => x + y;
        public int Subtract(int x, int y) => x - y;

        public void OnIntialized(MathOperation obj)
        {
            Console.WriteLine($"Addition: {obj(5, 3)}");
        }
        
        public void XaXa()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = FilterList(numbers, IsEven);
            Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));
        }


        private List<int> FilterList(List<int> list, Filter <int> filter)
        {
            var result = new List<int>();
            foreach (var item in list)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private bool IsEven(int number) => number % 2 == 0;
    }
}
