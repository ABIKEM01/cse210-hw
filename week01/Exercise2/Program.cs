using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeInput = Console.ReadLine();

       
        int gradePercentage = int.Parse(gradeInput);

      
        string letter = "";

       
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

     
        Console.WriteLine($"Your grade is: {letter}");

        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Don't give up! Try again and you can do it next time.");
        }

        string sign = "";

       
        int lastDigit = gradePercentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

       
        if (letter == "A" && sign == "+")
        {
            sign = ""; 
        }
        if (letter == "F")
        {
            sign = ""; 
        }

       
        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}
