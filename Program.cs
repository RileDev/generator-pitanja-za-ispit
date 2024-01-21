using System;

namespace generator_pitanja_za_ispit
{
    internal class Program
    {
        static List<string> questionsList = new List<string>();
        static string fileName = "zadaci.txt";
        static string[] allQuestionBase = { };
        static void Main(string[] args)
        {
            Console.WriteLine("Dobrodosli na generator pitanja za ispite");
            Console.Write("Unesi putanju ka bazi: ");
            string databasePath = Console.ReadLine();
            try
            {
                allQuestionBase = File.ReadAllLines(databasePath);

            }catch (Exception ex)
            {
                Console.WriteLine("Unos datoteke nije validna");
                Environment.Exit(1);
            }
            Console.Write($"Napisi koliko pitanja zelis od 1 do {allQuestionBase.Length}: ");
            int questionNo = 0;
            string userQuestioNo = Console.ReadLine();
            if (!Int32.TryParse(userQuestioNo, out questionNo))
            {
                
                Console.WriteLine("Unos nije ispravan!");
                Console.WriteLine("Gasim program!");
                Environment.Exit(1);
            }
            if (questionNo > allQuestionBase.Length)
            {
                Console.WriteLine("Broj pitanja ne sme da bude veci od broj baza pitanja");
                Environment.Exit(1);
            }
            Console.Write("Unesi putanju za cuvanje pitanja (*.txt) ili pretisni enter ako zelis u root programa da cuvas: ");
            string questionBase = Console.ReadLine();
            if (questionBase == "")
            {
                questionBase = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + fileName;
            }
            else if(!questionBase.Contains(".txt"))
            {
                questionBase += ".txt";
            }
            GenerateQuestions(questionNo, allQuestionBase);
            WriteQuestions(questionBase);
            Console.WriteLine("=====PITANJA=====");
            PrintAllQuestions();
            Console.WriteLine("=====KRAJ PITANJA=====");
            Console.Read();
        }

        private static void WriteQuestions(string questionBase)
        {
            using(StreamWriter sr  = new StreamWriter(questionBase))
            {
                foreach (string question in questionsList)
                {
                    sr.WriteLine(question);
                }
                
            }
        }

        private static void PrintAllQuestions()
        {
            foreach(string question in questionsList)
            {
                Console.WriteLine(question);
            }
        }

        private static void GenerateQuestions(int questionNo, string[] questions)
        {
            for(int i = 0;  i < questionNo; i++)
            {
                string question = questions[GetRandomNumber(questions)];
                if (!questionsList.Contains(question))
                {
                    questionsList.Add(question);
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
            }catch (Exception e)
            {
                result = 0;
            }
            return result;

        }
    }
}