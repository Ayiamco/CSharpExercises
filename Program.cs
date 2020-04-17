using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------Chapter9.SelectTask Test---------------------------------------------------
            //Chapter9.SelectTask();

            //---------------------Chapter9.GetMax Test---------------------------------------------
            //Console.WriteLine(Chapter9.GetMax( 1, 2, 3 ,4, 5));
            //int[] array = { 1, 7, 3, 4, 5, 5 };
            //List<int> lst = new List<int>(array);
            //Console.WriteLine(Convert.ToString(Chapter9.CheckGreater(10, array)));

            ////---------------------Chapter9.Sort Test--------------------------------------
            //long[] unsorted_array = new long[] { 1, 2, 3, 4, 5, 9, 1, 24, 3 };//values could be changed
            //long[] sorted_array = Chapter9.Sort(unsorted_array);
            //string sorted_string = string.Join(",", sorted_array.ToArray());
            //string unsorted_string = string.Join(",", unsorted_array.ToArray());
            //Console.WriteLine("UnSorted Array: " + unsorted_string);
            //Console.WriteLine("Sorted Array: " + sorted_string);

            ////---------------------- Chapter11.GetTriangleArea --------------------------------------------
            //Console.WriteLine(Convert.ToString(Chapter11.GetTriangleArea(3, 4, 5)));
            //Console.WriteLine(Convert.ToString(Chapter11.GetTriangleArea(side_a:3, side_b:4, angle:90)));

            //----------------------------Chapter11.isLeap Test--------------------------------------------
            //Console.Write("Enter your year: ");
            //string year = Console.ReadLine();
            //Console.WriteLine(year+ " is a leap year:  "+Convert.ToString(Chapter11.isLeap(year)));

            //---------------------------------Chapter11.GetDayCount Test --------------------------------
            //Console.WriteLine("Work Day Count: "+ Chapter11.GetDayCount("04/21/2020"));

            //Chapter12.GetSqrt("boy");
            //Console.WriteLine(Convert.ToString(null));
            Chapter12.ReadNumber(1, 100);

        }

        static void FindPath(int row, int col, char[,] lab)
        {
            if (row < 0 || col < 0 || row >= lab.GetLength(0) || col >= lab.GetLength(1))
            {
                //we are out of the Labrynth
                return;
            }

            // Check if we have found the exit
            if (lab[row, col] == 'e')
            {
                Console.WriteLine("Found the exit!");
            }

            if (lab[row, col] != ' ')
            {
                //we have met a road block
                //current cell is not free
                return;

            }
            // mark current cell as visited
            lab[row, col] = 's';

            //looking for the next free cell
            FindPath(row, col - 1, lab);//left
            FindPath(row, col + 1, lab);//right
            FindPath(row + 1, col, lab);//top
            FindPath(row - 1, col, lab);//bottom

            //mark back the cell as free
            lab[row, col] = ' ';
        }
       
    }
}
