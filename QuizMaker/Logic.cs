using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public static class Logic
    {
        public static Question GetRandomQuestion(Repository repository)
        {
            Random random = new Random();
            int index = random.Next(repository.Questions.Count);
            return repository.Questions[index];
        }

        public static void EvaluateAnswer(Question question, string userChoice)
        {
            int choiceIndex = Array.IndexOf(Constants.ChoiceLetters, userChoice);
            if (choiceIndex == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct answer!");
            }
            else
            {
                Console.WriteLine("Wrong answer. The correct answer is: " + question.Answers[question.CorrectAnswerIndex]);
            }
        }

        public static void SerializeRepository(Repository repository)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Repository));
            var path = @"Repository.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, repository);
            }
        }
    }
}

