/// \file HintSystem.cs
/// \brief Provides hint functionalities for the quiz game.

/// <summary>
/// A static class that handles the hint system during a question.
/// Offers different types of hints to assist the player.
/// </summary>
static class HintSystem
{
    /// <summary>
    /// Displays the available hints and allows the user to choose one.
    /// Applies the selected hint and removes it from the list.
    /// </summary>
    /// <param name="question">The current question for which the hint will be used.</param>
    /// <param name="hints">The list of remaining hints.</param>
    public static void ShowHintMenu(Question question, List<string> hints)
    {
        if (hints.Count == 0)
        {
            Print.HintUsed();
            return;
        }

        Print.HintNotUsed();
        for (int i = 0; i < hints.Count; i++)
            Console.WriteLine($"{i + 1}. {hints[i]}");

        Print.HintChoose();

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= hints.Count)
        {
            UseHint(hints[choice - 1], question);
            hints.RemoveAt(choice - 1);
        }
        else
        {
            Print.Error();
        }
    }

    /// <summary>
    /// Executes the selected hint logic based on its type.
    /// </summary>
    /// <param name="hint">The selected hint (e.g., "50/50", "Допомога друга").</param>
    /// <param name="question">The question to apply the hint to.</param>
    static void UseHint(string hint, Question question)
    {
        switch (hint)
        {
            case "50/50":
                Console.WriteLine($"1. {question.Answers[question.CorrectAnswer - 1]}   2. {Utils.GetRandomWrongAnswer(question)}");
                break;
            case "Допомога друга":
            case "Допомога залу":
                Console.WriteLine($"Порада: {question.Answers[question.CorrectAnswer - 1]}");
                break;
        }
    }
}
