using System;
using System.IO;

static class RecordManager
{
    public static void SaveRecord(string playerName, int score, string recordFile)
    {
        using var writer = new StreamWriter(recordFile, true);
        writer.WriteLine($"Гравець: {playerName}, Рахунок: {score}, Дата: {DateTime.Now}");
        Console.WriteLine("Рекорд збережено.");
    }

    public static void ShowRecords(string recordFile)
    {
        Console.WriteLine("\n--- Таблиця рекордів ---");
        if (File.Exists(recordFile))
        {
            foreach (var line in File.ReadAllLines(recordFile))
                Console.WriteLine(line);
        }
        else Console.WriteLine("Файл рекордів ще не створено.");
    }
}