using SomeProgrammingConcepts;
using System;
using System.Diagnostics;
using static SomeProgrammingConcepts.SomeLongRunningData;
using static SomeProgrammingConcepts.Task1;
using static SomeProgrammingConcepts.Task2;

public class Program
{

    public static void Main(string[] args)
    {
        Task2 t2 = new Task2();
        Logger l = t2.LogToConsole;
        l("123");
        l += t2.LogToList;
        l("456");
        l("a");
        l("b");
        l("c");
        t2.PrintLogToList();

        /*🔹 Level 1 – Warm-up
        //Creation of instance of Task1 class
        Task1 t = new Task1();
        //Creation of delegate instance and linking it to Print method
        Myprinter d = t.Print;
        //Invoking the delegate
        d("papa");

        Calculation c = t.Add;
        var var1 = c(4, 5);
        c += t.Multiply;
        c += t.Add;
        List<int> results = new List<int>();
        foreach (Calculation calc in c.GetInvocationList())
        {
            results.Add(calc(4, 5));
        }
        // So basically we print Add,Multiply,Add in that order because
        // we added them in that order to the delegate chain
        // 
        Console.WriteLine($"Var1: {var1}");
        foreach ( int result in results)
        {
            Console.WriteLine(result);
        }
        */







        //Simulation simulation = new Simulation();
        //MyObject1 myObject1 = new MyObject1(simulation);
        //MyObject2 myObject2 = new MyObject2(simulation);
        //simulation.Simulate();


        //SomeLongRunningData sm = new SomeLongRunningData();
        //Task.Run(() => sm.SomeMethod(SomeLongRunningData.CallBackMethod));
        //Task.Run(() => sm.SomeMethod(SomeLongRunningData.CallBackMethod2));
        //Delegates.Arithmetic add = (num1, num2) => Console.WriteLine($"Addition: {num1 + num2}");
        //Delegates.Arithmetic subtract = (num1, num2) => Console.WriteLine($"Subtraction: {num1 - num2}");
        //Delegates.Arithmetic multiply = (num1, num2) => Console.WriteLine($"Multiplication: {num1 * num2}");
        //Delegates.Arithmetic divide = (num1, num2) =>
        //{
        //    if (num2 != 0)
        //        Console.WriteLine($"Division: {num1 / num2}");
        //    else
        //        Console.WriteLine("Division by zero is not allowed.");
        //};
        //Task.Run(() => sm.OnIntialized(sm.Add));
        //Task.Run(() => sm.XaXa());

        //Console.WriteLine("Type in first number");
        //double number1 = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Type in second number");
        //double number2 = Convert.ToDouble(Console.ReadLine());
        //Delegates.Arithmetic operation = null;
        //bool operationCheck = false;
        //while (!operationCheck)
        //{
        //    Console.WriteLine("Choose Operation(add, subtract, multiply,divide)");
        //    string choice = Console.ReadLine().ToLower();
        //    switch (choice)
        //    {
        //        case "add":
        //            operation = add;
        //            operationCheck = true;
        //            break;
        //        case "subtract":
        //            operation = subtract;
        //            operationCheck = true;
        //            break;
        //        case "multiply":
        //            operation = multiply;
        //            operationCheck = true;
        //            break;
        //        case "divide":
        //            operation = divide;
        //            operationCheck = true;
        //            break;
        //        default:
        //            Console.WriteLine("Invalid choice");
        //            break;
        //    }
        //}
        //operation(number1, number2);
        //return;


    }
}