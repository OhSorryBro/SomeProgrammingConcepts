using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    public class Delegates
    {
        public delegate void Arithmetic(double num1, double num2);

        public delegate bool Filter<T>(T item);
        public delegate int MathOperation(int x, int y);
        
    }
}
