using QuizMaker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizApp
{
    public class Logic
    {

        List<Questions> questions = new List<Questions>();
        bool addingQuestions = true;
        public void CreatingQuestions()
        {
            while (addingQuestions)
            {
                Console.WriteLine("Enter the question: ");
                string questionText = Console.ReadLine();

                Console.WriteLine("Enter the answers: ");
                string questionAnswerOne = Console.ReadLine();
                string questionAnswerTwo = Console.ReadLine();
                string questionAnswerThree = Console.ReadLine();

                questions.Add(new Questions() { Text = questionText, AnswerOne = questionAnswerOne, AnswerTwo = questionAnswerTwo, AnswerThree = questionAnswerThree });

                Console.WriteLine("Do you want to add another question?");
                string anotherQuestionAsk = Console.ReadLine();

                if (anotherQuestionAsk.ToLower() != "yes")
                {
                    addingQuestions = false; // Here we implement the start of the Quiz *** NEXT STEP - START OF THE QUIZ ***
                }
            }
        }


    }
}