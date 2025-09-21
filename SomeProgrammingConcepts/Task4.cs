using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    internal class Task4
    {
        /*
🔹 Level 4 – Callback usage
7. Simulated background task
    Write a method DownloadFile(string url, Action<string> callback).
    Simulate downloading (Thread.Sleep(1000)), then invoke the callback with "Downloaded: " + url.
       */
        public void DownloadFile(string url, Action<string>callback)
        {
            System.Threading.Thread.Sleep(1000);
            callback("Downloaded: " + url);
        }






        /*
8. Progress reporting
    Write ProcessData(int steps, Action<int> onProgress).
    Each step calls the callback with the step number.
    Hook up a method that prints a progress bar in the console ([#####.....]).

       */

        public void ProcessData(int steps, Action<int> onProgress)
        {
            for (int i=1; i<=steps;i++)
                {
                System.Threading.Thread.Sleep(500);
                onProgress(i);
            }
        }
        public void PrintProgressBar(int step, int totalSteps)
        {
            int totalBlocks = totalSteps;
            int filledBlocks = step;
            int emptyBlocks = totalBlocks - filledBlocks;
            string progressBar = "[" + new string('#', filledBlocks) + new string('.', emptyBlocks) + "]";
            Console.Write($"\r{progressBar} {step * 100 / totalSteps}%");
        }
    }
}
