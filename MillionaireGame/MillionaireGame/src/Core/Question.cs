/// \file Question.cs
/// \brief Represents a quiz question with answers and related data.

/// <summary>
/// Represents a single quiz question, including the question text,
/// multiple choice answers, the correct answer index, and the point value.
/// </summary>
class Question
{
    /// <summary>
    /// Gets the question text.
    /// </summary>
    public string Text { get; }

    /// <summary>
    /// Gets the array of answer options.
    /// </summary>
    public string[] Answers { get; }

    /// <summary>
    /// Gets the index (1-based) of the correct answer.
    /// </summary>
    public int CorrectAnswer { get; }

    /// <summary>
    /// Gets the number of points awarded for a correct answer.
    /// </summary>
    public int Point { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Question"/> class.
    /// </summary>
    /// <param name="text">The question text.</param>
    /// <param name="answers">Array of 4 possible answers.</param>
    /// <param name="correctAnswer">The correct answer index (1-based).</param>
    /// <param name="point">Points awarded for correct answer.</param>
    public Question(string text, string[] answers, int correctAnswer, int point)
    {
        Text = text;
        Answers = answers;
        CorrectAnswer = correctAnswer;
        Point = point;
    }

    /// <summary>
    /// Loads a list of questions from a file.
    /// Each line in the file should be formatted as:
    /// QuestionText|Answer1|Answer2|Answer3|Answer4|CorrectAnswerIndex|Points
    /// </summary>
    /// <param name="filePath">Path to the questions file.</param>
    /// <returns>List of loaded questions.</returns>
    public static List<Question> LoadQuestions(string filePath)
    {
        var questions = new List<Question>();
        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('|');
            if (parts.Length == 7)
            {
                string text = parts[0];
                string[] answers = new[] { parts[1], parts[2], parts[3], parts[4] };
                int correctAnswer = int.Parse(parts[5]);
                int points = int.Parse(parts[6]);
                questions.Add(new Question(text, answers, correctAnswer, points));
            }
        }
        return questions;
    }
}
