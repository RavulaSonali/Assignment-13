using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TextProcessor
{
    static void Main()
    {
        Console.WriteLine("Enter a piece of text:");
        string inputText = Console.ReadLine();

        int wordCount = CountWords(inputText);
        List<string> emailAddresses = ValidateEmailAddresses(inputText);
        List<string> mobileNumbers = ExtractMobileNumbers(inputText);

        Console.WriteLine($"Word Count: {wordCount}");

        Console.WriteLine("Email Addresses:");
        foreach (var email in emailAddresses)
        {
            Console.WriteLine(email);
        }

        Console.WriteLine("Mobile Numbers:");
        foreach (var number in mobileNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("Enter a custom regular expression:");
        string customRegexPattern = Console.ReadLine();
        List<string> customRegexMatches = CustomRegexSearch(inputText, customRegexPattern);

        Console.WriteLine("Custom Regex Matches:");
        foreach (var match in customRegexMatches)
        {
            Console.WriteLine(match);
        }
    }

    static int CountWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static List<string> ValidateEmailAddresses(string text)
    {
        List<string> emailAddresses = new List<string>();
        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            emailAddresses.Add(match.Value);
        }

        return emailAddresses;
    }

    static List<string> ExtractMobileNumbers(string text)
    {
        List<string> mobileNumbers = new List<string>();
        string pattern = @"\b\d{10}\b|\(\d{3}\)\s?\d{3}-\d{4}";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            mobileNumbers.Add(match.Value);
        }

        return mobileNumbers;
    }

    static List<string> CustomRegexSearch(string text, string pattern)
    {
        List<string> customRegexMatches = new List<string>();

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            customRegexMatches.Add(match.Value);
        }

        return customRegexMatches;
    }
}