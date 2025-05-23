using System;
using System.Text.RegularExpressions;

static class Utils
{
    public static string GetValidUsername()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Введіть ваше ім'я (латиницею): ");
            Console.ResetColor();
            string input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                return input;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некоректне ім'я!");
            Console.ResetColor();
        }
    }

    public static bool AskForRestart(string recordFile)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Зіграти ще раз, переглянути рекорди чи вийти? (y/r/n): ");
            Console.ResetColor();
            string response = Console.ReadLine()?.Trim().ToLower();

            if (response == "y") return true;
            if (response == "r")
            {
                Console.Clear();
                RecordManager.ShowRecords(recordFile);
            }
            else if (response == "n") return false;
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Введіть 'y', 'r' або 'n'.");
                Console.ResetColor();
            }
        }
    }

    public static void GetDifficultyLevel(int level)
    {
        switch (level)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Легкий рівень");
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Середній рівень");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Складний рівень");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Невідомий");
                break;
        }
    }

    public static string GetRandomWrongAnswer(Question question)
    {
        Random rand = new Random();
        int wrong;
        do { wrong = rand.Next(0, 4); }
        while (wrong == question.CorrectAnswer - 1);
        return question.Answers[wrong];
    }
}