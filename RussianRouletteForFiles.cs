using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RussianRoulette
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Copy and paste folder directory");
            Console.WriteLine("Add another \\ after each in directory name");
            var dir = new DirectoryInfo(Convert.ToString(Console.ReadLine()));

            char restart = 'y';
            while (restart == 'y')
            {
                foreach (var file in dir.EnumerateFiles("*"))
                {
                    Random rdm = new Random();
                    int shoot = rdm.Next(1, 7);
                    if (shoot == 1)
                    {
                        Console.WriteLine("Deleted " + file);
                        file.Delete();
                        Console.WriteLine("Again? Y/N");
                        restart = Convert.ToChar(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("You got lucky");
                        Console.WriteLine("Again? Y/N");
                        restart = Convert.ToChar(Console.ReadLine());
                        break;
                    }
                }
            }
        }
    }
}
