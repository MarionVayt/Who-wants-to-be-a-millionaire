using System;
using System.Collections.Generic;
using System.Threading;


public class Logo
{
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
        Thread.Sleep(30000);
    }
 }