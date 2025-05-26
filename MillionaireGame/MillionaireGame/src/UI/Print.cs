/// \file Print.cs
/// \brief Displays start and finish logos for the game.

/// <summary>
/// Static class responsible for showing stylized console logos
/// at the start and end of the game session.
/// </summary>
public class Print
{
    /// <summary>
    /// Displays the start logo with a welcome message.
    /// </summary>
    public static void StartLogo()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("+----------------------------------------+");

        string[] lines = {
            "                 Welcome                ",
            "                   to                   ",
            "       Who wants to be a millionaire?   "
        };

        foreach (string line in lines)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("|");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(line);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("|");
        }

        Console.WriteLine("+----------------------------------------+");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the finish logo with a thank you message and
    /// pauses for 10 seconds before closing.
    /// </summary>
    public static void FinishLogo()
    {
        string[] lines = {
            "         Thank you for playing!         ",
            "         Good luck next time!           "
        };
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("+----------------------------------------+");
        foreach (string line in lines)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("|");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(line);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("|");
        }
        Console.WriteLine("+----------------------------------------+");
        Console.ResetColor();
        Thread.Sleep(10000);
    }

    public static void True(Question question)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ Правильно! + {question.Point}$ до вашого балансу.");
        Console.ResetColor();
    }

    public static void False()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Неправильно! Гра закінчена.");
        Console.ResetColor();  
    }

    public static void Error()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Некоректний вибір.");
        Console.ResetColor();
    }

    public static void Answer()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nВведіть 'hint' або номер відповіді (1-4): ");
        Console.ResetColor();
    }

    public static void HintUsed()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Всі підказки використано.");
        Console.ResetColor();
    }

    public static void HintNotUsed()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nДоступні підказки:");
        Console.ResetColor();
    }

    public static void HintChoose()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("Виберіть підказку: ");
        Console.ResetColor();
    }

    public static void Category()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Категорії питань:");
        Console.ResetColor();
    }

    public static void CategoryChoose(string category)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Ви вибрали: {category}");
        Console.ResetColor();
    }
    
    public static void QuestionAndAnswers(Question question)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n{question.Text}");
        Console.ResetColor();

        for (int i = 0; i < 4; i++)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{i + 1}. {question.Answers[i]}");
            Console.ResetColor();
        }
    }
}
