using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGenerator
{
    class Program
    {       
        public static void Generator(char[] testArray) 
        { 
            // Program that generates hello world sequentially in c#

            Random rnd = new Random();
            char[] generatedArray = new char[testArray.Length]; //Array to hold generated numbers
            const string pool = " abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";

            for (int i = 0; i < testArray.Length; i++)
            {
                Console.Write(testArray[i]);
            }

            for (int i = 0; i < testArray.Length; i++)
            {
                generatedArray[i] = pool[rnd.Next(0, pool.Length)]; //generates number 1-26 and fills it into array position
                Console.Write(generatedArray[i]);         //converts the same number to letter and prints
                if (generatedArray[i] != testArray[i]) //checks against test array, helloWorldArray
                {
                    i -= 1;
                }
            }
            Console.WriteLine();
            
            for (int i = 0; i < testArray.Length; i++) //prints finalised generation
            {
                Console.Write(generatedArray[i]);
            }
            
            Console.ReadKey();
        }

        
    }
}
