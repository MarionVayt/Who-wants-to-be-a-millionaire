/// \file CategoryManager.cs
/// \brief Contains the CategoryManager class for handling question categories.

/// <summary>
/// Manages the list of question categories for the quiz game.
/// Responsible for loading categories from files, displaying them,
/// allowing selection, and updating the list after each selection.
/// </summary>
public class CategoryManager
{
    /// <summary>
    /// List of available category file paths.
    /// </summary>
    private static List<string> availablecategories;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryManager"/> class.
    /// Loads all category files from the specified folder path.
    /// </summary>
    /// <param name="folderPath">Path to the folder containing category files (default: "Questions").</param>
    public CategoryManager(string folderPath = "Questions")
    {
        availablecategories = Directory.GetFiles(folderPath).ToList();
    }

    /// <summary>
    /// Displays the list of available categories to the user.
    /// </summary>
    public void ShowCategories()
    {
        Print.Category(availablecategories);
    }

    /// <summary>
    /// Returns the file path for the chosen category based on user input.
    /// </summary>
    /// <param name="choise">User's numeric choice (1-based index).</param>
    /// <returns>File path of the selected category.</returns>
    /// <exception cref="Exception">Thrown if the choice is invalid.</exception>
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

    /// <summary>
    /// Displays the name of the selected category.
    /// </summary>
    /// <param name="filePath">Path to the selected category file.</param>
    public void ShowCategory(string filePath)
    {
        if (File.Exists(filePath))
        {
            string categoryName = File.ReadLines(filePath).FirstOrDefault();
            Print.CategoryChoose(categoryName);
        }
    }

    /// <summary>
    /// Removes the specified category from the list of available categories.
    /// </summary>
    /// <param name="filePath">Path to the category file to remove.</param>
    public void RemoveCategory(string filePath)
    {
        availablecategories.Remove(filePath);
    }

    /// <summary>
    /// Gets the number of available categories.
    /// </summary>
    /// <returns>The count of categories.</returns>
    public int CategoryCount() => availablecategories.Count;

    /// <summary>
    /// Gets a value indicating whether there are any categories remaining.
    /// </summary>
    public bool HasCategories => availablecategories.Count > 0;
}
