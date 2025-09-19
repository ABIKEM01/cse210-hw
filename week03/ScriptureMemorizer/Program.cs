using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       
        // To show creativity and exceed requirements, I added two features:
        // 1. The program randomly picks one scripture from a list at startup.
        // 2. The program progressively hides words each time the user presses Enter,
        //    turning the memorization into an interactive challenge.
  

        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture("Philippians 4:13", "I can do all things through Christ which strengtheneth me."),
            new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture("Mosiah 2:17", "When ye are in the service of your fellow beings ye are only in the service of your God.")
        };

        Random rand = new Random();
        Scripture chosenScripture = scriptures[rand.Next(scriptures.Count)];

        Console.WriteLine("Welcome to the Scripture Memorizer Program!");
        Console.WriteLine();
        Console.WriteLine($"Today's scripture: {chosenScripture.GetReference()}");
        Console.WriteLine(chosenScripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            bool stillHasWords = chosenScripture.HideRandomWord();

            Console.Clear();
            Console.WriteLine($"Today's scripture: {chosenScripture.GetReference()}");
            Console.WriteLine(chosenScripture.GetDisplayText());

            if (!stillHasWords || chosenScripture.IsFullyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Great job memorizing!");
                break;
            }
        }
    }
}
