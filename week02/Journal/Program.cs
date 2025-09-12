// EXTRA FEATURE FOR CREATIVITY:
// I extended the Entry class by adding a "Mood" field. 
// Now, when the user writes in the journal, they can also record 
// how they are feeling (e.g., happy, stressed, grateful).

using System;


class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();

                // Ask the user for their mood and save it in the entry
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._prompt = prompt;
                newEntry._response = response;

                Console.Write("How are you feeling today (mood)? ");
                newEntry._mood = Console.ReadLine(); 

                myJournal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                myJournal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
        }
    }
}
