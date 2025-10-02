
using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What did you learn about yourself through this experience?",
            "How can you apply this experience in the future?"
        };

        public ReflectingActivity()
            : base("Reflecting Activity",
                   "This activity will help you reflect on times when you have shown strength and resilience.")
        { }

        private string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];
        private string GetRandomQuestion() => _questions[_random.Next(_questions.Count)];

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
            Console.WriteLine("Think about it...");
            ShowSpinner(4);

            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalSeconds < _duration)
            {
                Console.WriteLine($"\n{GetRandomQuestion()}");
                int remaining = _duration - (int)(DateTime.Now - start).TotalSeconds;
                ShowSpinner(Math.Min(5, remaining));
            }

            DisplayEndingMessage();
        }
    }
}
