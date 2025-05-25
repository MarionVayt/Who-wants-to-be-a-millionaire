/// \file Logo.cs
/// \brief Displays start and finish logos for the game.

/// <summary>
/// Static class responsible for showing stylized console logos
/// at the start and end of the game session.
/// </summary>
public class Logo
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
}
