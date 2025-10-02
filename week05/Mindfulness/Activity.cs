
using System;
using System.IO;
using System.Threading;

namespace MindfulnessProgram
{
    class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration; // seconds
        protected static Random _random = new Random();

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"=== {_name} ===\n");
            Console.WriteLine(_description);
            Console.WriteLine();

            Console.Write("How long, in seconds, would you like for your session? ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    _duration = seconds;
                    break;
                }
                Console.Write("Please enter a positive number: ");
            }

            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
            LogActivity();
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }

        protected void ShowSpinner(int seconds)
        {
            char[] sequence = { '|', '/', '-', '\\' };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(sequence[i % sequence.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
            Console.WriteLine();
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\r  \r"); // erase number
            }
        }

        protected void LogActivity()
        {
            try
            {
                string logLine = $"{DateTime.Now:u} - Completed {_name} for {_duration} seconds{Environment.NewLine}";
                File.AppendAllText("mindfulness_log.txt", logLine);
            }
            catch { }
        }

        public int Duration => _duration;
    }
}
