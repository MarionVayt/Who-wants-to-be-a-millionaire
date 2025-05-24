using System.Collections.Generic;
using System.IO;

class Question
{
    public string Text { get; }
    public string[] Answers { get; }
    public int CorrectAnswer { get; }
    public int Point { get; }

    public Question(string text, string[] answers, int correctAnswer, int point)
    {
        Text = text;
        Answers = answers;
        CorrectAnswer = correctAnswer;
        Point = point;
    }

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
