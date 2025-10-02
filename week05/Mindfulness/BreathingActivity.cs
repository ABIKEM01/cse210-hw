
using System;

namespace MindfulnessProgram
{
    class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly.")
        { }

        public void Run()
        {
            DisplayStartingMessage();

            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalSeconds < _duration)
            {
                if ((DateTime.Now - start).TotalSeconds >= _duration) break;

                Console.WriteLine("\nBreathe in...");
                int remaining = _duration - (int)(DateTime.Now - start).TotalSeconds;
                ShowCountDown(Math.Min(4, remaining));

                if ((DateTime.Now - start).TotalSeconds >= _duration) break;

                Console.WriteLine("\nBreathe out...");
                remaining = _duration - (int)(DateTime.Now - start).TotalSeconds;
                ShowCountDown(Math.Min(6, remaining));
            }

            DisplayEndingMessage();
        }
    }
}
