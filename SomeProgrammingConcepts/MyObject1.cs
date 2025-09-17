using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    public class MyObject1
    {
        
        public void Print(string msg)
        {
            Console.WriteLine($"MyObject1 Print Method {msg}");
        }
        public MyObject1(Simulation simulation)
        {
            simulation.a += Print;
            simulation.a += (string msg) => Print($"Current Time is Even: {simulation.CurrentTime}");
        }
    }
}
