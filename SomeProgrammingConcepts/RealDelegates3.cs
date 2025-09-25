using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SomeProgrammingConcepts
{
    internal class RealDelegates3
    {
//        Level 3 – More realistic scenarios

//7. Input validation
//Write a method Validate<T>(T value, Func<T, bool> validator, Action<T> onValid, Action<T> onInvalid).
//– If validator(value) returns true, call onValid(value), otherwise onInvalid(value).
        
    public void Validate<T>(T value, Func<T,bool> validator, Action<T> onValid, Action<T> onInvalid)
        {
            if (validator(value))
            {
                onValid(value);
            }
            else
            {
                onInvalid(value);
            }
        }
    public bool isGreaterThan10(int value)
        {
            return value > 10;
        }

    public void OnValidAction<T>(T value)
        {
            Console.WriteLine($"Value {value} is valid.");
        }
    public void OnInvalidAction<T>(T value)
        {
            Console.WriteLine($"Value {value} in invalid.");
        }


//8. Retry logic
//Write a method Retry(Func<bool> operation, int attempts),
//which tries to execute operation up to attempts times until it returns true.
    public void Retry(Func<bool> operation, int attempts)
        {
            for (int i=0;i<attempts;i++)
            {
                bool sucess = operation();
                Console.WriteLine($"Attempt {i+1}: {(sucess==true?"Sucess":"Fail")}");
                if (sucess == true)
                {
                    Console.WriteLine("Operation sucess");
                    break;
                }
            }
        }
    public bool UnreliableOperation()
        {
            int var1 = 3;
            int var2 = 5;
            return var1 > var2;
        }
    





//9. Simple event system
//Write a class EventBus that allows you to subscribe with
//Action<string> and then trigger all registered actions via Publish(string message).
    public class EventBus
        {
            private List<Action<string>> subscribers = new List<Action<string>>();
            public void Subscribe(Action<string> action)
            {
                subscribers.Add(action);
            }
            public void  Publish(string message)
            { foreach (var action in subscribers)
                {
                    action(message);
                }
            }
        }
        public void EventBusExample()
        {
            EventBus eventBus = new EventBus();
            eventBus.Subscribe((msg) => Console.WriteLine($"Subscriber 1 received: {msg}"));
            eventBus.Subscribe((msg) => Console.WriteLine($"Subscriber 2 received: {msg}"));
            eventBus.Publish("Hello, EventBus!");
        }




        //10. Mini processing pipeline
        //Write a method RunPipeline(int input, List<Func<int, int>> steps, Action<int> output),
        //which passes the input through each function in steps and then calls the output action
        //with the final result.





    }
}
