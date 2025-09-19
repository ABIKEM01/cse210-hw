using System;
using System.Collections.Generic;

public class Scripture
{
    private string reference;
    private List<string> words;
    private Random rand = new Random();

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = new List<string>(text.Split(' '));
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetDisplayText()
    {
        return string.Join(" ", words);
    }

    public bool HideRandomWord()
    {
        List<int> visibleIndexes = new List<int>();

        // Find words that are not yet hidden
        for (int i = 0; i < words.Count; i++)
        {
            if (!words[i].Contains("_"))
            {
                visibleIndexes.Add(i);
            }
        }

        if (visibleIndexes.Count == 0)
        {
            return false; // no words left to hide
        }

        // Randomly pick one of the visible words to hide
        int randomIndex = visibleIndexes[rand.Next(visibleIndexes.Count)];
        words[randomIndex] = new string('_', words[randomIndex].Length);

        return true;
    }

    public bool IsFullyHidden()
    {
        foreach (var word in words)
        {
            if (!word.Contains("_"))
            {
                return false;
            }
        }
        return true;
    }
}
