using QuizApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class Repository
    {
        public List<Question> Questions;

        public Repository()
        {
            Questions = new List<Question>();
        }
    }
}