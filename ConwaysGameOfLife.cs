using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConwaysGameofLife
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // array for printing and comparing alive or dead cells
            int[] array = new int[14570];
            // array for holding changes so that it doesnt affect other cell comparisons
            int[] tempArray = new int[14570];
            int arrayPos;
            int neighbourCount = 0; //count variable for amount of neighbours any cell has 
            int arrayX = 150;
            int arrayY = 50;
            Random rnd = new Random();
            //array[2875 / 2] = 1;
            //array[(2875 / 2) + 1] = 1;
            //array[(2875 / 2) - 1] = 1;
            //array[(2875 / 2) - 114] = 1;
            //array[(2875 / 2) - 230] = 1;

            Console.SetWindowSize(151, 51);
            Console.ForegroundColor = ConsoleColor.Black;
            //filling array randomly
            for (int y = 0; y < arrayY; y++)
            {
                Console.WriteLine("");
                for (int x = 0; x < (arrayX - 1); x++)
                {
                    int temp = rnd.Next(0, 2);
                    array[(y * arrayX) + x] = temp;
                    Console.Write(array[(y * arrayX) + x]);
                }
            }
            
            while (true)
            {
                // loops for checking every cell for neighbouring alive cells
                for (int y = 0; y < arrayY; y++)
                {
                    for (int x = 0; x < arrayX; x++)
                    {
                        // setting the array pos varible to the correct cell using x and y loop counters
                        if (y > 0 && x > 0)
                            arrayPos = (y * arrayX) + x;
                        else if (x > 0)
                            arrayPos = x;
                        else
                            arrayPos = y * arrayX;

                        // north
                        if (y != 0)
                            neighbourCount += N(array, arrayPos, arrayX, arrayY);
                        // north east
                        if (y != 0 && x != (arrayX - 1))
                            neighbourCount += NE(array, arrayPos, arrayX, arrayY);
                        // north west
                        if (y != 0 && x != 0)
                            neighbourCount += NW(array, arrayPos, arrayX, arrayY);
                        // south
                        if (y != (arrayY - 1))
                            neighbourCount += S(array, arrayPos, arrayX, arrayY);
                        // south east
                        if (y != (arrayY - 1) && x != (arrayX - 1))
                            neighbourCount += SE(array, arrayPos, arrayX, arrayY);
                        // south west
                        if (y != (arrayY - 1) && x != 0)
                            neighbourCount += SW(array, arrayPos, arrayX, arrayY);
                        // east
                        if (x != (arrayX - 1))
                            neighbourCount += E(array, arrayPos, arrayX, arrayY);
                        // west
                        if (x != 0)
                            neighbourCount += W(array, arrayPos, arrayX, arrayY);

                        // setting cell alive/dead state
                        if (neighbourCount == 3) 
                            tempArray[arrayPos] = 1;
                        else if (neighbourCount == 2 && array[arrayPos] == 1)
                            tempArray[arrayPos] = 1;
                        else
                            tempArray[arrayPos] = 0;
                        neighbourCount = 0;
                    }
                }

                // filing array with tempArray and printing
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                //redrawing array
                for (int y = 0; y < arrayY; y++)
                {
                    Console.WriteLine("");
                    for (int x = 0; x < arrayX; x++)
                    {
                        array[(y * arrayX) + x] = tempArray[(y * arrayX) + x];
                        if (array[(y * arrayX) + x] == 1)
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(array[(y * arrayX) + x]);
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
            }
        }

        // methods to check array positions for alive cells
        public static int N(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            int temp = arrayPos - arrayX;
            if (array[temp] == 1) //north
            {
                return 1;
            }
            return 0;
        }
        public static int NE(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            if (array[(arrayPos - (arrayX - 1))] == 1) //north east
            {
                return 1;
            }
            return 0;
        }
        public static int NW(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            if (array[(arrayPos - (arrayX + 1))] == 1) //north west
            {
                return 1;
            }
            return 0;
        }
        public static int S(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            if (array[(arrayPos + arrayX)] == 1) //south
            {
                return 1;
            }
            return 0;
        }
        public static int SE(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            if (array[(arrayPos + (arrayX + 1))] == 1) //south east
            {
                return 1;
            }
            return 0;
        }
        public static int SW(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            if (array[(arrayPos + (arrayX - 1))] == 1) //south west
            {
                return 1;
            }
            return 0;
        }
        public static int E(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            if (array[(arrayPos + 1)] == 1) //east
            {
                return 1;
            }
            return 0;
        }
        public static int W(int[] array, int arrayPos, int arrayX, int arrayY)
        {
            if (array[arrayPos - 1] == 1) //west
            {
                return 1;
            }
            return 0;
        }
    }
}
