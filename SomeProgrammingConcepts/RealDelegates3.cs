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




//8. Retry logic
//Write a method Retry(Func<bool> operation, int attempts),
//which tries to execute operation up to attempts times until it returns true.




//9. Simple event system
//Write a class EventBus that allows you to subscribe with
//Action<string> and then trigger all registered actions via Publish(string message).




//10. Mini processing pipeline
//Write a method RunPipeline(int input, List<Func<int, int>> steps, Action<int> output),
//which passes the input through each function in steps and then calls the output action
//with the final result.



    }
}
