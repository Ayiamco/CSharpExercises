using System;
using System.Collections.Generic;
using System.Linq;


namespace Practice
{
    class Program
    {
        delegate int MyDelegate(string gg);
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
            //Chapter12.ReadNumber(1, 100);


            // Console.WriteLine(" obi</upcase>".Substring( 2,4));

            //Console.WriteLine(Chapter13.UpCase("bi <upcase>is a boy, obi</upcase> <upcase> obi</upcase> secondary schhol"));

            //Console.WriteLine("palindromes: {0}", Chapter13.GetPalindromes("mum used to be the madam of Abba"));
            //Chapter14.Book my_book = new Chapter14.Book("bible",book_release_date:"20/11/2000");
            //Console.WriteLine(my_book.title);

            //Chapter18.GetCount(1, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 8);
            // Chapter18.RemoveOddFrequency(4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6);
            //Chapter18.GetWordCount("word.txt");

            Console.Write("how olde are you?: ");
            int age= int.Parse(Console.ReadLine());
            switch (age)
            {
                case int aa when (age > 0 && age <=25):
                    Console.WriteLine("congrats youth!!!");
                    break;
                default:
                    Console.WriteLine("you don old!!!!");
                    break;
            }
            MyDelegate new1 = new MyDelegate(CalcAge);
            Console.WriteLine(new1("04/04/1995"));

        }

        static int CalcAge(string dob)
        {
            return DateTime.Now.Year- Convert.ToDateTime(dob).Year;
        }

        
       
    }
}
