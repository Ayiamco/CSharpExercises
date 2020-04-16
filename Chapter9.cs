using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Chapter9
    {
        public static bool CheckGreater (int index,params int[] my_array)
            //Question 5
        {
            if (index < my_array.Length)
            {
                int left_side = my_array[index - 1];
                int right_side = my_array[index + 1];
                if (my_array[index] > left_side + right_side)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                //Error index is out of range of array
                Console.WriteLine("Index is out of Array Range");
            return false;           
        }
        public static long[] Sort( params long[] numbers_array)
            //Question 9
        {
            List<long> sorted_list= new List<long>();
            long[] numbers_array_copy = numbers_array;
            List<long> current_list = new List<long>(numbers_array_copy);
            while (numbers_array_copy.Length>0)
            {
                long current_max = GetMax(numbers_array_copy);//get max of current array;
                sorted_list.Add(current_max);//update sorted array with new item
                int max_item_index=current_list.IndexOf(current_max);
                current_list.RemoveAt(max_item_index);
                numbers_array_copy = current_list.ToArray();
            }
            return sorted_list.ToArray();
        }

        public static void SelectTask()
        //Question 11
        {
            Console.WriteLine("Select Category:\n" +
                " 1.)Reversed Order\n " +
                "2.)GetAverage. \n " +
                "3.)Solve linear Equation. (Ax+B=C)" +
                "\n Reply with 1,2 or 3");
            int users_choice = int.Parse(Console.ReadLine());
            if (users_choice == 1)
            {
                Console.Write("Enter Your Number: ");
                string method_argument = Console.ReadLine();
                Console.Write("Reversed Number:  ");
                Console.Write(ReverseOrder(method_argument));
            }
            else if (users_choice == 2)
            {
                Console.WriteLine("Enter your number list (separate with a comma):");
                string method_argument = Console.ReadLine();
                Console.Write("Items Average: ");
                Console.Write(GetAverage(method_argument));
            }
            else if (users_choice == 3)
            {
                Console.Write("Enter the Value of A: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter the Value of B: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Enter the Value of C: ");
                int c = int.Parse(Console.ReadLine());
                Console.Write("Value of X: ");
                Console.Write(LinearEquation(a: a, b: b, c: c));
            }
        }
        static long ReverseOrder(string number_string)
        {
            //function reverses order of numbers
            string reversed_string = "";
            for (int index = 0; index < number_string.Length; index++)
            {
                reversed_string = reversed_string + number_string[number_string.Length - index - 1];
            }
            return Convert.ToInt64(reversed_string);
        }
        static long GetAverage(string item_string)
        {
            //function to get average
            char[] delimiters = new char[] { '\r', '\n', ',', ' ' };
            string[] string_array = item_string.Split(delimiters);
            long array_sum = 0;
            for (int index = 0; index < string_array.Length; index++)
            { array_sum = array_sum + Convert.ToInt64(string_array[index]); }
            return array_sum / string_array.Length;

        }
        static long LinearEquation(int a = 1, int b = 2, int c = 0)
        {
            //function to solve linear equation of the form
            //AX+B=C
            long x = (c - b) / a;
            return x;

        }

        public static long GetMax(params long[] numbers)
        // function to get the largest number of an array
        {
            long my_max = numbers[0];
            for (int index=1;index<numbers.Length;index++ )
            {
                if (my_max<numbers[index])
                    { my_max = numbers[index]; }
            }
            return my_max;
        }

    }
}
