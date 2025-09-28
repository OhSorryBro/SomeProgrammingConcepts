using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SomeProgrammingConcepts
{
    internal class Delegates_Intermediate
    {

        //        🔟 Next 10 Delegate Tasks(Intermediate Level)

        //1. Custom Where with logging
        //Write a method FilterWithLog<T> that takes IEnumerable<T>, a Func<T, bool>, and an Action<T>.
        //It should work like Where, but also call the action for every rejected element (e.g., logging).

        public List<T> FilterWithLog<T>(IEnumerable<T> items, Func<T, bool> doSomething, Action<T> performAction)
        {
            List<T> endResult = new List<T>();
            foreach (var item in items)
            {
                bool result = doSomething(item);
                if (!result)
                {
                    performAction(item);
                }
                else
                {
                 endResult.Add(item);
                }
            }
            return endResult;
        }

        public void PrintItem<T>(T item)
        {
            Console.WriteLine($"Item {item} was filtered out.");
        }
        public bool isEven(int number)
        {
            return number % 2 == 0;
        }
        public void PrintList<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"What has not been filtered out: "+item);
            }
        }




        //2. Map & Reduce
        //Write a method MapReduce<T, U> that:
        //maps a list of T into a list of U using a Func<T, U>,
        //then reduces the list into a single result using a Func<U, U, U>.

        public U MapReduce<T, U>(IEnumerable<T> items, Func<T, U> mapFunc, Func<U, U, U> reduceFunc)
        {
            List<U> mappedItems = new List<U>();
            foreach (var item in items)
            {                 
                mappedItems.Add(mapFunc(item));
            }
            return mappedItems.Aggregate(reduceFunc);
        }

        public int CountChars(string str)
        {
            return str.Length;
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public void PrintFromReduce<U>(U item)
        {
            Console.WriteLine($"Result from Reduce: " + item);
        }

        //3. Retry with delay
        //Extend your Retry method so it accepts an additional Func<int, int> parameter — a delay strategy
        //(e.g., for attempt i, return milliseconds to wait).
        //Add a delay between retries.




        public void RetryWithDelay(Func<bool> operation, int attempts, Func<int, int> retryStrategy)
        {
            for (int i = 0; i < attempts; i++)
            {
                int delay = retryStrategy(i);
                bool sucess = operation();
                if (sucess == true)
                {
                    Console.WriteLine("Operation sucess");
                    break;
                }
                else
                {
                    Console.WriteLine("Waiting: " + delay);
                    System.Threading.Thread.Sleep(delay);
                }
            }
        }

        public int WaitStrategy1(int attempt)
        {
            return attempt * 1000;
        }
        public bool UnreliableOperation()
        {
            int var1 = 3;
            int var2 = 5;
            return var1 > var2;
        }


        //4. Batch processor
        //Write a method ProcessInBatches<T> that takes a list of items, an int batchSize, and an Action<List<T>>.
        //Split the list into batches and invoke the action on each batch.




        //5. Parallel execution
        //Write a method RunInParallel<T> that takes a list of Func<T> and returns a List<T> of results.
        //Execute all functions in parallel using Task.WhenAll.




        //6. Pipeline with branching
        //Extend your pipeline so that it accepts a Func<int,bool> as a condition.
        //If the condition returns true, continue normally; if false, skip to an alternative list of steps.




        //7. Validator collection
        //Create a class Validator<T> that holds a list of Func<T, bool>.
        //Add a method ValidateAll(T value) that returns a list of messages indicating which validations failed.




        //8. Transform and side-effect
        //Write a method TransformWithSideEffect<T, U> that takes a T input, a Func<T, U> transformer, an Action<T> before, and an Action<U> after.
        //It should:
        //Run the before action on the input,
        //Transform the input,
        //Run the after action on the result.



        //9. Command dispatcher
        //Implement a class CommandDispatcher where you can register commands (string → Action).
        //Add a method Dispatch(string command) that triggers the right action, or reports that the command does not exist.




        //10. Dynamic calculator
        //Write a class Calculator that stores a dictionary of operators (Dictionary<string, Func<int, int, int>>).
        //Add a method Calculate(string op, int a, int b) that finds the delegate and executes it.
        //Register operators like "+", "-", "*", "/".



    }
}
