using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator_pitanja_za_ispit
{
    internal class ProgramHandling
    {
        public static void ExitProgram()
        {
            Console.WriteLine("Pretisni bilo koje dugme za izlaz...");
            Console.Read();
            Environment.Exit(1);
        }
    }
}
