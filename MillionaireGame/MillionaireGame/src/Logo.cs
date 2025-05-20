using System;
using System.Collections.Generic;
using System.Threading;


public class Logo
{
    public static void ShowLogo()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("+----------------------------------------+");
        Console.WriteLine("|                 Welcome                |");
        Console.WriteLine("|                   to                   |");
        Console.WriteLine("|       Who wants to be a millionaire?   |");
        Console.WriteLine("+----------------------------------------+");
        Console.ResetColor();
    }
 }