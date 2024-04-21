using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizApp
{
    public class Question
    {
        public string QuestionText;
        public List<string> Answers;
        public int CorrectAnswerIndex;
    }

    [Serializable]
    public class Repository
    {
        public List<Question> Questions;

        public Repository()
        {
            Questions = new List<Question>();
        }
    }

    public static class QuizLogic
    {
        public static Repository LoadRepository()
        {
            if (File.Exists(Constants.RepositoryFilePath))
            {
                XmlSerializer reader = new XmlSerializer(typeof(Repository));
                using (FileStream file = File.OpenRead(Constants.RepositoryFilePath))
                {
                    return (Repository)reader.Deserialize(file);
                }
            }
            else
            {
                return new Repository();
            }
        }

        public static void SerializeRepository(Repository repository)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Repository));
            using (FileStream file = File.Create(Constants.RepositoryFilePath))
            {
                writer.Serialize(file, repository);
            }
        }

        public static void AddQuestion(string questionText, List<string> answers, int correctAnswerIndex)
        {
            var repository = LoadRepository();
            var question = new Question
            {
                QuestionText = questionText,
                Answers = answers,
                CorrectAnswerIndex = correctAnswerIndex
            };
            repository.Questions.Add(question);
            SerializeRepository(repository);
        }

        public static Question GetRandomQuestion()
        {
            var repository = LoadRepository();
            Random random = new Random();
            int index = random.Next(repository.Questions.Count);
            return repository.Questions[index];
        }

        public static bool IsAnswerCorrect(Question question, int selectedAnswerIndex)
        {
            return selectedAnswerIndex == question.CorrectAnswerIndex;
        }

        public static void ClearRepository()
        {
            File.Delete(Constants.RepositoryFilePath);
        }
    }
}