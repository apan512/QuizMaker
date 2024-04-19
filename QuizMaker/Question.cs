using System.Collections.Generic;

namespace QuizMaker
{
    public class Question
    {
        public string QuestionText;
        public List<string> Answers;
        public int CorrectAnswerIndex;

        
        public Question()
        {
        }

        public Question(string questionText, List<string> answers, int correctAnswerIndex)
        {
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}
