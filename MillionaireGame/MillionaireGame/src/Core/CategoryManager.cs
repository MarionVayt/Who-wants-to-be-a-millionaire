public class CategoryManager
{
    private static List<string> availablecategories;

    public CategoryManager(string folderPath = "Questions")
    {
        availablecategories = Directory.GetFiles(folderPath).ToList();
    }

    public void ShowCategories()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Категорії питань:");
        for (int i = 0; i < availablecategories.Count; i++)
        {
            string categoryName = File.ReadLines(availablecategories[i]).FirstOrDefault()?.Trim();
            Console.WriteLine($"{i + 1}. {categoryName}");
        }
        Console.ResetColor();
    }

    public string ChooseCategory(int choise)
    {
        if (choise >= 1 && choise <= availablecategories.Count)
        {
            return availablecategories[choise - 1];
        }
        else
        {
            Utils.GetValidCategoryChoice(availablecategories.Count);
        }
        throw new Exception();
    }

    public void ShowCategory(string filePath)
    {
        if (File.Exists(filePath))
        {
            string categoryName = File.ReadLines(filePath).FirstOrDefault();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Ви вибрали: {categoryName}");
            Console.ResetColor();
        }
    }
    
    public void RemoveCategory(string filePath)
    {
        availablecategories.Remove(filePath);
    }

    public int CategoryCount() => availablecategories.Count;
    public bool HasCategories => availablecategories.Count > 0;
}