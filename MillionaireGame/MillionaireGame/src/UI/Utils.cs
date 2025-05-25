using System.Text.RegularExpressions;

/// \file Utils.cs
/// \brief Utility methods for user input validation and game flow control.

/// <summary>
/// Static helper class providing methods for validating user input,
/// asking for user decisions during the game, and retrieving random wrong answers.
/// </summary>
static class Utils
{
    /// <summary>
    /// Prompts the user to enter a valid username consisting of Latin letters and spaces.
    /// Keeps asking until a valid input is provided.
    /// </summary>
    /// <returns>A validated username string.</returns>
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

    /// <summary>
    /// Prompts the user to select a category number within a valid range.
    /// Keeps asking until a valid integer within range is entered.
    /// </summary>
    /// <param name="maxOption">Maximum valid category option number.</param>
    /// <returns>The selected category number.</returns>
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

    /// <summary>
    /// Asks the user whether to restart the game, view records, or exit.
    /// </summary>
    /// <param name="recordFile">Path to the records file to show if requested.</param>
    /// <returns>True if user wants to play again, false to exit.</returns>
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

    /// <summary>
    /// Asks the player whether to continue the current category.
    /// </summary>
    /// <param name="score">Current player score.</param>
    /// <returns>True to continue, false to stop.</returns>
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

    /// <summary>
    /// Asks the player whether to continue to the next category after completing the current one.
    /// </summary>
    /// <param name="score">Current player score.</param>
    /// <returns>True to continue to next category, false to stop.</returns>
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

    /// <summary>
    /// Returns a random incorrect answer from the question's answer options.
    /// </summary>
    /// <param name="question">The question to get a wrong answer from.</param>
    /// <returns>A random wrong answer string.</returns>
    public static string GetRandomWrongAnswer(Question question)
    {
        Random rand = new Random();
        int wrong;
        do { wrong = rand.Next(0, 4); }
        while (wrong == question.CorrectAnswer - 1);
        return question.Answers[wrong];
    }
}
