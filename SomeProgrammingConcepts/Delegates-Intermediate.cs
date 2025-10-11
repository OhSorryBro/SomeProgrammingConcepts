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

        public void ProcessInBatches<T>(IEnumerable<T> items, int batchSize, Action<List<T>> processBatch)
        {
            List<T> batch = new List<T>();
            foreach (var item in items)
            {
                batch.Add(item);
                if (batch.Count == batchSize)
                {
                    processBatch(batch);
                    batch.Clear();
                    System.Threading.Thread.Sleep(batchSize * 1000); // Simulate some processing time
                }
            }
            if (batch.Count > 0)
            {
                processBatch(batch);
                Console.WriteLine("Final batch processed.");
            }
        }
        public void PrintBatch<T>(List<T> batch)
        {
            Console.WriteLine("Processing batch:");
            foreach (var item in batch)
            {
                Console.WriteLine(item);
            }
        }



        //5. Parallel execution
        //Write a method RunInParallel<T> that takes a list of Func<T> and returns a List<T> of results.
        //Execute all functions in parallel using Task.WhenAll.

        public async Task<List<T>> RunInParallel<T>(IEnumerable<Func<T>> functions)
        {
            List<Task<T>> tasks = new List<Task<T>>();

            foreach (var func in functions)
            {
                tasks.Add(Task.Run(func));
            }
            var resultsArray =  await Task.WhenAll(tasks);
            List<T> results = resultsArray.ToList();
            return results;
        }
        public int DivisorCount(int n)
        {
            int count = 0;
            for (int i = 1; i <= n;i++)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }
            return count;
        }
        public int IsPrime(int n)
        {
            if (n < 2) return 0;               
            if (n == 2) return 1;               
            if (n % 2 == 0) return 0;          
            int limit = (int)Math.Sqrt(n);
            for (int i = 3; i <= limit; i += 2)    
            {
                if (n % i == 0)
                    return 0;                  
            }
            return 1;                           
        }

        public int FactorialDigitCount(int n)
        {
            if (n < 0) return 0;            // brak sensu dla liczb ujemnych
            if (n <= 1) return 1;           // 0! i 1! = 1 → 1 cyfra

            double sum = 0;
            for (int i = 2; i <= n; i++)
            {
                sum += Math.Log10(i);
            }

            return (int)Math.Floor(sum) + 1;
        }

        public void PrintResults<T>(List<T> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine("Result from parallel execution: " + result);
            }
        }

        public int GetOrdersFromReflex()
        {
            System.Threading.Thread.Sleep(2000);
            // Simulate delay
            Random Random = new Random();
            int result = Random.Next(1, 100);
            return result;
        }
        public int GetTransportsFromTMS()
        {
            System.Threading.Thread.Sleep(3140);
            // Simulate delay
            Random Random = new Random();
            int result = Random.Next(1, 100);
            return result;
        }

        public int GetInvoicesFromSAP()
        {
            System.Threading.Thread.Sleep(8321);
            Random Random = new Random();
            int result = Random.Next(1, 100);
            return result;
        }
        // Example functions for testing

        //Func<int> calc1 = () => DivisorCount(50000000);
        //Func<int> calc2 = () => FactorialDigitCount(20);
        //Func<int> calc3 = () => IsPrime(2147483647) ? 1 : 0;


        // more realistic functions

        // Func<List<Order>> getOrders = () => GetOrdersFromReflex();
        // Func<List<Transport>> getTransports = () => GetTransportsFromTMS();
        // Func<List<Invoice>> getInvoices = () => GetInvoicesFromSAP();

        //6. Pipeline with branching
        //Extend your pipeline so that it accepts a Func<int,bool> as a condition.
        //If the condition returns true, continue normally; if false, skip to an alternative list of steps.


        public List<Func<int, int>> steps;
        public void RunPipeLineWithBranching(int input, Func<int,bool> condition, List<Func<int, int>> steps, List<Func<int, int>> alternativeSteps, Action<int> output)
        {
            int result = input;
            bool conditionReuslt = condition(input);
            if (conditionReuslt == true)
            {
                foreach (var step in steps)
                {
                    result = step(result);
                }

            }
            else
            {
                foreach (var step in alternativeSteps)
                {
                    result = step(result);
                }
            }
            output(result);
        }
        public int Add2(int x) { return x + 2; }
        public int MultiplyBy3(int x) { return x * 3; }
        public void OutputResult(int result)
        {
            Console.WriteLine($"Final result: {result}");

        }
        public bool IsLessThan100(int x) { return x < 100; }

        //7. Validator collection
        //Create a class Validator<T> that holds a list of Func<T, bool>.
        //Add a method ValidateAll(T value) that returns a list of messages indicating which validations failed.

        public class Validator<T>
        {
            private List<Func<T, bool>> validators = new List<Func<T, bool>>();
            public void AddValidator(Func<T, bool> validator)
            {
                validators.Add(validator);
            }

            public List<string> ValidateAll(T value)
            {
                List<string> result = new List<string>();
                int counter = 0;
                foreach (var validation in this.validators)
                {
                    counter++;
                    if (!validation(value))
                    {
                        result.Add($"Validation number: {counter}. {value} has NOT matched the validation");
                    }
                }
                return result;
            }
        }


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
