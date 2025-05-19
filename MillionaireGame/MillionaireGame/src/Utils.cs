using System;
using System.Text.RegularExpressions;

static class Utils
{
    public static string GetValidUsername()
    {
        while (true)
        {
            Console.Write("Введіть ваше ім'я (латиницею): ");
            string input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                return input;

            Console.WriteLine("Некоректне ім'я!");
        }
    }

    public static bool AskForRestart(string recordFile)
    {
        while (true)
        {
            Console.Write("Зіграти ще раз, переглянути рекорди чи вийти? (y/r/n): ");
            string response = Console.ReadLine()?.Trim().ToLower();

            if (response == "y") return true;
            if (response == "r") { RecordManager.ShowRecords(recordFile); }
            else if (response == "n") return false;
            else Console.WriteLine("Введіть 'y', 'r' або 'n'.");
        }
    }

    public static string GetDifficultyLevel(int level) => level switch
    {
        0 => "Легкий",
        1 => "Середній",
        2 => "Складний",
        _ => "Невідомий"
    };

    public static string GetRandomWrongAnswer(Question question)
    {
        Random rand = new Random();
        int wrong;
        do { wrong = rand.Next(0, 4); }
        while (wrong == question.CorrectAnswer - 1);
        return question.Answers[wrong];
    }
}