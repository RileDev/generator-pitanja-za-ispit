using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator_pitanja_za_ispit
{
    internal class Question
    {

        static List<string> _questionsList;

        public Question(List<string> list)
        {
            _questionsList = new List<string>();
        }


        public void WriteQuestions(string questionBase)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(questionBase))
                {
                    foreach (string question in _questionsList)
                    {
                        sr.WriteLine(question);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pristup ka datoteci nije dozvoljen :(");
                ProgramHandling.ExitProgram();
            }

        }

        public void PrintAllQuestions()
        {
            foreach (string question in _questionsList)
            {
                Console.WriteLine(question);
            }
        }

        public void GenerateQuestions(int questionNo, string[] questions)
        {
            for (int i = 0; i < questionNo; i++)
            {
                string question = questions[GetRandomNumber(questions)];
                if (!_questionsList.Contains(question))
                {
                    _questionsList.Add(question);
                }
                else
                {
                    continue;
                }
            }
        }

        private static int GetRandomNumber(string[] questions)
        {
            Random rand = new Random();
            int result = 0;
            try
            {
                result = rand.Next(questions.Length);
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;

        }
    }
}
