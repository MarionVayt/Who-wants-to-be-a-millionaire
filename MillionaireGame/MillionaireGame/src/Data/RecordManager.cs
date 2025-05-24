using System;
using System.IO;

static class RecordManager
{
    public static void SaveRecord(string playerName, int score, string recordFile)
    {
        using var writer = new StreamWriter(recordFile, true);
        writer.WriteLine($"Гравець: {playerName}, Рахунок: {score}, Дата: {DateTime.Now}");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Рекорд збережено.");
        Console.ResetColor();
    }

    public static void ShowRecords(string recordFile)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\n--- Таблиця рекордів ---");
        Console.ResetColor();
        if (File.Exists(recordFile))
        {
            List<string> records = new List<string>();
            using var reader = new StreamReader(recordFile);
            {
                string record;
                while ((record = reader.ReadLine()) != null)
                    records.Add(record);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("+------------+----------+----------------------+");
            Console.WriteLine("| Гравець    | Баланс  | Дата                 |");
            Console.WriteLine("+------------+----------+----------------------+");
            foreach (string line in records)
            {
                string[] parts = line.Replace("Гравець: ", "").Replace("Баланс: ", "").Replace("Дата: ", "").Split(',');
                if (parts.Length == 3)
                {
                    Console.WriteLine($"| {parts[0].Trim(),-10} | {parts[1].Trim(),-8}$ | {parts[2].Trim(),-20} |");
                }
            }
            Console.WriteLine("+------------+----------+----------------------+");
            Console.ResetColor();


        }
        else Console.WriteLine("Файл рекордів ще не створено.");
    }
}