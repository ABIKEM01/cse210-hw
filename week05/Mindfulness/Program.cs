
// Exceeding Requirements:
// 1. A logfile ("mindfulness_log.txt") records every completed activity with timestamp.
// 2. Spinner and countdown animations included for user experience.
// 3. ListingActivity uses a timeout so it respects the duration limit while reading input.
// 4. Prompts and questions are randomized for variety.
// 5. Clean OOP design with inheritance and multiple files (Activity base + 3 derived classes).
// 6. Menu-driven loop so the user can choose activities repeatedly.



using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Mindfulness Program ===");
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflecting Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Quit");
                Console.Write("Enter choice (1-4): ");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    var a = new BreathingActivity();
                    a.Run();
                }
                else if (choice == "2")
                {
                    var a = new ReflectingActivity();
                    a.Run();
                }
                else if (choice == "3")
                {
                    var a = new ListingActivity();
                    a.Run();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye! Take care.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }
    }
}
