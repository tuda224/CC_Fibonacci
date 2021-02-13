using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CC_Fibonacci
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var input = ReadInput();
                var positionOfNumber = int.Parse(input);
                Stopwatch sw = new Stopwatch();

                sw.Start();
                var result = CalculateFibNumber(positionOfNumber);
                sw.Stop();
                var normalCalculation = sw.ElapsedTicks;

                sw.Restart();
                var recursiveResult = CalculateRecursive(positionOfNumber);
                sw.Stop();
                var recursiveCalculation = sw.ElapsedTicks;

                Console.WriteLine($"result: {result} - {normalCalculation} ticks");
                Console.WriteLine($"result: {recursiveResult} - {recursiveCalculation} ticks");
            }
        }

        private static int CalculateRecursive(int positionOfNumber, int currentRun = 0, int last = 0, int preLast = 0)
        {
            if (currentRun == 0 || currentRun == 1)
            {
                last = currentRun;
                return CalculateRecursive(positionOfNumber, ++currentRun, last, 0);
            }
            else if (currentRun < positionOfNumber)
            {
                var temp = last;
                last += preLast;
                preLast = temp;
                return CalculateRecursive(positionOfNumber, ++currentRun, last, preLast);
            }

            return last + preLast;
        }

        private static int CalculateFibNumber(int positionOfNumber)
        {
            var last = 0;
            var preLast = 0;
            for (int i = 0; i <= positionOfNumber; i++)
            {
                // start with 0 and 1
                if (i == 0 || i == 1)
                {
                    last = i;
                }
                // every following number sum of the two numbers before
                else
                {
                    var temp = last;
                    last = last + preLast;
                    preLast = temp;
                }
            }
            return last;
        }

        private static string ReadInput()
        {
            Console.WriteLine("Using input file: C:\\temp\\input.txt\nPress Return for run.");
            Console.ReadLine();
            var input = File.ReadAllText("C:\\temp\\input.txt");
            return input;
        }
    }
}