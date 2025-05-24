public class PrintCategory
{
    public static void Categories()
    {
        string folderPath = "Questions";
        List<string> categories = new List<string>();

        try
        {
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                string name = File.ReadLines(file).First();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    categories.Add(name);
                }
            }

            Console.WriteLine("Категорії питань:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void Category(string filePaht)
    {
        string category = File.ReadLines(filePaht).First();
        Console.WriteLine($"Ви вибрали {category}");
    }
}