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
            Question q = new Question(questionsList);
            Console.WriteLine("Dobrodosli na generator pitanja za ispite");
            Console.Write("Unesi putanju ka bazi: ");
            string databasePath = Console.ReadLine();
            try
            {
                allQuestionBase = File.ReadAllLines(databasePath);

            }catch (Exception ex)
            {
                Console.WriteLine("Unos datoteke nije validna");
                ProgramHandling.ExitProgram();
            }
            Console.Write($"Napisi koliko pitanja zelis od 1 do {allQuestionBase.Length}: ");
            int questionNo = 0;
            string userQuestioNo = Console.ReadLine();
            if (!Int32.TryParse(userQuestioNo, out questionNo))
            {
                
                Console.WriteLine("Unos nije ispravan!");
                Console.WriteLine("Gasim program!");
                ProgramHandling.ExitProgram();
            }
            if (questionNo > allQuestionBase.Length)
            {
                Console.WriteLine("Broj pitanja ne sme da bude veci od broj baza pitanja");
                ProgramHandling.ExitProgram();
            }else if (questionNo <= 0)
            {
                Console.WriteLine("Broj pitanja ne sme da bude manji ili jednak nuli");
                ProgramHandling.ExitProgram();
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
            q.GenerateQuestions(questionNo, allQuestionBase);
            q.WriteQuestions(questionBase);
            Console.WriteLine("=====PITANJA=====");
            q.PrintAllQuestions();
            Console.WriteLine("=====KRAJ PITANJA=====");
            ProgramHandling.ExitProgram();
        }
    }
}