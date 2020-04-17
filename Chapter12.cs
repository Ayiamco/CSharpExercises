using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Chapter12
    {
        public static string GetSqrt(object number)
        //Question 7
        {
            try
            {
               double sqrt=Math.Sqrt(Convert.ToDouble(number));
                if (Convert.ToString(sqrt) =="NaN")
                { Console.WriteLine("Invalid Input"); }
                else
                { return Convert.ToString(sqrt); }
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine(fe.StackTrace);
                
            }
            finally
            {
                Console.WriteLine("GoodBye!!!");
                
            }
            return "Could not finish";

        }

        public static long ReadNumber(int start,int end)
            //Question 8
        {
            Exception f = new Exception("Input is in Wrong Format!!!");
            Exception o = new Exception("Number Out Of Start and End Range!!!");
            Console.Write("Enter Number : ");
            try
            {
                long number=Convert.ToInt64(Console.ReadLine());
                if (number < start || number >end)
                {
                    throw o;
                }
                else
                {
                    return number;
                }
            }
            catch(FormatException)
            {
                throw f;
            }
            
           
        }
    }
}
