using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGenerator
{
    class Input
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a word or sentence youd like the program to generate");
            string inputString = Convert.ToString(Console.ReadLine());
            char[] array = inputString.ToCharArray();

            Program.Generator(array);
        }
    }
}
