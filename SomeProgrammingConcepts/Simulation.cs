using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    public class Simulation
    {
        public int CurrentTime = 0;
        public delegate void CurrentTimeIsEven(string msg);
        public CurrentTimeIsEven a;
        public void Simulate()
        {
            while (CurrentTime < 100)
            {
                if (CurrentTime % 2 == 0)
                {
                    a("CurrentTime X");
                    Console.WriteLine($"--- Time {CurrentTime}: Event Triggered! ---");
                }
                System.Threading.Thread.Sleep(100); // Simulate time passing
                CurrentTime++;
            }
        }

    }
}
