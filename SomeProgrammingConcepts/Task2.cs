using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    public class Task2
    {
        /*
🔹 Level 2 – Multiple subscribers

3.  Two loggers at once
    Define delegate void Logger(string msg);
    Attach one method that writes to console, and another that saves to a List<string>.
    Invoke the delegate and check both were executed.
                */
        public delegate void Logger(string msg);
        public void LogToConsole(string msg)
        {
            Console.WriteLine($"Log to console: {msg}");
        }
        public List<string> logList = new List<string>();
        public void LogToList(string msg)
        {
            logList.Add(msg);
        }
        public void PrintLogToList()
        {
            foreach (string log in logList)
            {
                Console.WriteLine("Log from list: " + log);
            }    
        }
        /*
    4.  Clock event
        Create a Clock class that every 2 seconds invokes a delegate Action<int> with the current tick.
        Subscribe two handlers: one logs to console, the other counts total elapsed time.
                            */
        public class Clock 
        {
            public event Action<int> Tick;
            private int tickCount = 0;
            public void Start()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(2000);
                    tickCount++;
                    Tick?.Invoke(tickCount);
                }
            }
        }
        public void ClockLogToConsole(int tick)
        {
            Console.WriteLine($"Clock is at it's {tick}");
        }
        public int totalElapsedTime = 0;
        public void ClockCountElapsedTime(int tick)
        {
            totalElapsedTime = tick * 2;
            Console.WriteLine($"Total elapsed time: {totalElapsedTime} seconds");
        }


    }
}
