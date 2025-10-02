
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MindfulnessProgram
{
    class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity",
                   "This activity will help you reflect on the good things in your life by listing them.")
        { }

        private string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];

        private string ReadLineWithTimeout(int timeoutSeconds)
        {
            if (timeoutSeconds <= 0) return null;
            var task = Task.Run(() => Console.ReadLine());
            bool finished = task.Wait(TimeSpan.FromSeconds(timeoutSeconds));
            return finished ? task.Result : null;
        }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
            Console.WriteLine("You will have a few seconds to think...");
            ShowCountDown(5);

            List<string> items = new List<string>();
            DateTime start = DateTime.Now;

            Console.WriteLine("\nStart listing. Press Enter after each item.");
            while ((DateTime.Now - start).TotalSeconds < _duration)
            {
                int remaining = _duration - (int)(DateTime.Now - start).TotalSeconds;
                Console.Write("> ");
                string input = ReadLineWithTimeout(remaining);
                if (input == null) break;
                if (!string.IsNullOrWhiteSpace(input))
                    items.Add(input.Trim());
            }

            Console.WriteLine($"\nYou listed {items.Count} item(s).");

            try
            {
                string logLine = $"{DateTime.Now:u} - {_name} for {_duration}s; Items: {items.Count}{Environment.NewLine}";
                File.AppendAllText("mindfulness_log.txt", logLine);
            }
            catch { }

            DisplayEndingMessage();
        }
    }
}
