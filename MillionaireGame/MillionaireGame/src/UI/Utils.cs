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
    
    public static int GetValidCategoryChoice(int maxOption)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Виберіть категорію (1-" + maxOption + "): ");
            Console.ResetColor();
            string input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= maxOption)
                return choice;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Некоректний ввід. Введіть число від 1 до {maxOption}.");
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
                Console.WriteLine("Введіть 'y', 'r' або 'n'.");
                Console.ResetColor();
            }
            Console.ResetColor();
        }
    }

    public static bool AskForContinueCategory(ref int score)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"Ваш баланс: {score}$. Чи бажаєте продовжити гру? (y/n): ");
            string response = Console.ReadLine()?.Trim().ToLower();
            if(response == "y") return true;
            else if(response == "n") return false;
            else
            {
                Console.WriteLine("Введіть 'y', 'r' або 'n'.");
                Console.ResetColor();
            }
            Console.ResetColor();
        }
    }
    
    public static bool AskForContinueNextCategory(ref int score)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"🎉 Вітаю, Ви пройшли категорію! Ваш баланс: {score}$. Чи бажаєте продовжити гру? (y/n): ");
            string response = Console.ReadLine()?.Trim().ToLower();
            if(response == "y") return true;
            else if(response == "n") return false;
            else
            {
                Console.WriteLine("Введіть 'y', 'r' або 'n'.");
                Console.ResetColor();
            }
            Console.ResetColor();
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