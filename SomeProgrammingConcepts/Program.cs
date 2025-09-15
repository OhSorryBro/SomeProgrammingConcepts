using SomeProgrammingConcepts;
using System;
using static SomeProgrammingConcepts.SomeLongRunningData;

public class Program
{

    public static void Main(string[] args)
    {
        SomeLongRunningData sm = new SomeLongRunningData();
        Task.Run(() => sm.SomeMethod(SomeLongRunningData.CallBackMethod));
        Task.Run(() => sm.SomeMethod(SomeLongRunningData.CallBackMethod2));
        Delegates.Arithmetic add = (num1, num2) => Console.WriteLine($"Addition: {num1 + num2}");
        Delegates.Arithmetic subtract = (num1, num2) => Console.WriteLine($"Subtraction: {num1 - num2}");
        Delegates.Arithmetic multiply = (num1, num2) => Console.WriteLine($"Multiplication: {num1 * num2}");
        Delegates.Arithmetic divide = (num1, num2) =>
        {
            if (num2 != 0)
                Console.WriteLine($"Division: {num1 / num2}");
            else
                Console.WriteLine("Division by zero is not allowed.");
        };


        Console.WriteLine("Type in first number");
        double number1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Type in second number");
        double number2 = Convert.ToDouble(Console.ReadLine());
        Delegates.Arithmetic operation = null;
        bool operationCheck = false;
        while (!operationCheck)
        {
            Console.WriteLine("Choose Operation(add, subtract, multiply,divide)");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "add":
                    operation = add;
                    operationCheck = true;
                    break;
                case "subtract":
                    operation = subtract;
                    operationCheck = true;
                    break;
                case "multiply":
                    operation = multiply;
                    operationCheck = true;
                    break;
                case "divide":
                    operation = divide;
                    operationCheck = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        operation(number1, number2);
        return;


    }
}