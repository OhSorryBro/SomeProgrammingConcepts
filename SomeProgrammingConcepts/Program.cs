using SomeProgrammingConcepts;
using System;
using System.Diagnostics;
using static SomeProgrammingConcepts.SomeLongRunningData;
using static SomeProgrammingConcepts.Task1;
using static SomeProgrammingConcepts.Task2;
using static SomeProgrammingConcepts.Task3;
using static SomeProgrammingConcepts.Task5;

public class Program
{

    public static void Main(string[] args)
    {
        //Intermediate Delegates tasks
        //1. Custom Where with logging

        Delegates_Intermediate di = new Delegates_Intermediate();
        List<int> FilteredWithLogResult = di.FilterWithLog<int>(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, di.isEven, di.PrintItem);
        di.PrintList<int>(FilteredWithLogResult);


        //2. Map & Reduce
        List<string> strings = new List<string>();
        strings.AddRange( new[] { "apple", "banana", "cherry", "laptop" });

        di.PrintFromReduce(di.MapReduce(strings, di.CountChars, di.Sum));


        //3. Retry with delay
        di.RetryWithDelay(di.UnreliableOperation, 5, di.WaitStrategy1);

        //4. Batch processor

        di.ProcessInBatches<int>(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, di.PrintBatch);


        /*
        //7. Validation
        RealDelegates3 rd3 = new RealDelegates3();
        int value = 15;
        rd3.Validate<int>(value, rd3.isGreaterThan10, rd3.OnValidAction, rd3.OnInvalidAction);
        value = 5;
        rd3.Validate<int>(value, rd3.isGreaterThan10, rd3.OnValidAction, rd3.OnInvalidAction);


        //8. Retry logic
        rd3.Retry(rd3.UnreliableOperation, 5);

        //9. Event bus
        rd3.EventBusExample();

        //10. Pipeline
        rd3.steps = new List<Func<int, int>>()
        {
            rd3.Add2,
            rd3.MultiplyBy3
        };
        rd3.RunPipeLine(5, rd3.steps, rd3.OutputResult);
        */




        // Task 4,5,6 new RealDelegates2
        /*
        RealDelegates2 rd2 = new RealDelegates2();

        // Task 4 new RealDelegates2
        Func<int, int> ComposedFunction = rd2.Compose(rd2.AddOne, rd2.AddTwo);
        int x= ComposedFunction(3);
        Console.WriteLine(x);


        // Task 5 new RealDelegates2
        int[] numbers = new int[] { 1, 2};
        int result = rd2.DoOperation(numbers, rd2.Min);
        Console.WriteLine($"{result}");

        //Task 6 new RealDelegates2
        List<string> words = new List<string>() { "apple", "banana", "cherry" };

            foreach (string word in words)
                {
            rd2.TransformString(word, rd2.ToUpp, rd2.PrintString);
                }
        */

        /*
        //Task 1 new RealDelegates1
        RealDelegates1 rd = new RealDelegates1();
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> evenNumbers = rd.FilterList(numbers, num => num % 2 == 0);
        rd.PrintList(evenNumbers);


        //Task 2 new RealDelegates1
        List<string> words = new List<string>() { "apple", "banana", "cherry" };
        List <int> wordsLenght = rd.TransformList(words, str => str.Length);
        rd.PrintList(wordsLenght);

        //Task 3 new RealDelegates1
        rd.PerformAction(numbers, rd.PrintNumber);
        rd.PerformAction(numbers,rd.PrintNumberTwice);



        */

        /*
        Task5 t5 = new Task5();
        List<int> numbers = new List<int>() {1,2,3,4,5,6,7,8,9,10 };
        TestDel TD = t5.Square;
        TD += t5.Double;
        TD += t5.PrintStars;





        string question = "2,3,Add";
        t5.questions.Add(question);
        Console.WriteLine(question);
        Task5.Operation op = t5.Add;
        int answer = Convert.ToInt16(Console.ReadLine());
        int goodAnswer = op(2, 3);
        if(answer == goodAnswer)
            Console.WriteLine("Correct");
        else
            Console.WriteLine($"Wrong, seems like you eat bananas for their shape and not for their taste, " +
                $" the correct answer is {goodAnswer}");
        question = "12,3,Subtract";
        t5.questions.Add(question);
        Console.WriteLine(question);
        op = t5.Subtract;
        answer = Convert.ToInt16(Console.ReadLine());
        goodAnswer = op(12, 3);
        if (answer == goodAnswer)
            Console.WriteLine("Correct");
        else
            Console.WriteLine($"Wrong, seems like you eat bananas for their shape and not for their taste, " +
                $" the correct answer is {goodAnswer}");

        */



        /*🔹 Level 4 – Async file download and progress bar


        Task4 t4 = new Task4();
        for (int i =0; i<2; i++)
            t4.DownloadFile("http://example.com/file1", (result) => Console.WriteLine(result));
        t4.ProcessData(10, step=> t4.PrintProgressBar(step, 10));
        */

        /*🔹 Level 3 – Calculator and filter
        Task3 t3 = new Task3();
        Operation o = t3.Add;
        var Result = t3.RunOperation(4, 5, o);
        t3.PrintResult(Result,o);

        o = t3.Subtract;
        var Result2 = t3.RunOperation(4, 5, o);
        t3.PrintResult(Result2, o);

        o = t3.Multiply;
        var Result3 = t3.RunOperation(4, 5, o);
        t3.PrintResult(Result3, o);


        o = t3.Max;
        var Result4 = t3.RunOperation(4, 5, o);
        t3.PrintResult(Result4, o);




        Filter filter = t3.IsEven;
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        List<int> resultNumbers = t3.FilterList(numbers, filter);
        t3.PrintFilteredList(resultNumbers);

        filter = t3.IsGreaterThan10;
        List <int> resultNumbers2 = t3.FilterList(numbers, filter);
        t3.PrintFilteredList(resultNumbers2);

        filter = t3.IsDivisibleBy3;
        List<int> resultNumbers3 = t3.FilterList(numbers, filter);
        t3.PrintFilteredList(resultNumbers3);
        /*



        /* Level 2 – Multiple subscribers


        Task2 t2 = new Task2();
        Logger l = t2.LogToConsole;
        l("123");
        l += t2.LogToList;
        l("456");
        l("a");
        l("b");
        l("c");
        t2.PrintLogToList();

        Task2.Clock clock = new Task2.Clock();
                clock.Tick += t2.ClockLogToConsole;
                clock.Tick += t2.ClockCountElapsedTime;
                Task.Run(() => clock.Start());
        // Running the clock in a separate task to avoid blocking the main thread
        Console.ReadKey();
        */


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