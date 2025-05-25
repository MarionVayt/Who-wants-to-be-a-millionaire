/// \file RecordManager.cs
/// \brief Provides functionality to save and display player records.

/// <summary>
/// Static class responsible for managing game records,
/// including saving player scores to a file and displaying the records table.
/// </summary>
static class RecordManager
{
    /// <summary>
    /// Saves a player's record to the specified file with the current date and time.
    /// </summary>
    /// <param name="playerName">Name of the player.</param>
    /// <param name="score">Player's score.</param>
    /// <param name="recordFile">Path to the record file.</param>
    public static void SaveRecord(string playerName, int score, string recordFile)
    {
        using var writer = new StreamWriter(recordFile, true);
        writer.WriteLine($"Гравець: {playerName}, {score}, Дата: {DateTime.Now}");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Рекорд збережено.");
        Console.ResetColor();
    }

    /// <summary>
    /// Reads and displays all saved records from the specified file
    /// in a formatted table in the console.
    /// </summary>
    /// <param name="recordFile">Path to the record file.</param>
    public static void ShowRecords(string recordFile)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\n--- Таблиця рекордів ---");
        Console.ResetColor();

        if (File.Exists(recordFile))
        {
            var records = new List<string>();

            using var reader = new StreamReader(recordFile);
            string record;
            while ((record = reader.ReadLine()) != null)
                records.Add(record);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("+------------+---------+----------------------+");
            Console.WriteLine("| Гравець    | Баланс  | Дата                 |");
            Console.WriteLine("+------------+---------+----------------------+");

            foreach (var line in records)
            {
                // Record format: "Гравець: playerName, score, Дата: дата"
                // Clean and split the line for formatted output
                string cleanLine = line.Replace("Гравець: ", "").Replace("Дата: ", "");
                string[] parts = cleanLine.Split(',');

                if (parts.Length == 3)
                {
                    string playerName = parts[0].Trim();
                    string score = parts[1].Trim();
                    string date = parts[2].Trim();

                    Console.WriteLine($"| {playerName,-10} | {score, -7} | {date,-20} |");
                }
            }

            Console.WriteLine("+------------+---------+----------------------+");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Файл рекордів ще не створено.");
        }
    }
}
