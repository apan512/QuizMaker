using System.Collections.Generic;

namespace QuizMaker
{
    public class Repository
    {
        public List<Question> Questions;

        public Repository()
        {
            Questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
    }
}

