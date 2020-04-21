using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Chapter13
    {
        public static bool CheckParenthesis(string str_char)
            //Question 4
        {
            Stack stack = new Stack();
            bool is_balanced = true;
            int counter = 0;
            while (is_balanced == true && counter < str_char.Length)
            {

                if (str_char[counter] == '(' || str_char[counter] == '{' || str_char[counter] == '[')
                    stack.Push(str_char[counter]);
                else if (str_char[counter] == ')' || str_char[counter] == ')' || str_char[counter] == ')')
                {
                    if (stack.IsEmpty())
                        is_balanced = false;
                    else if (stack.IsEmpty() == false && Convert.ToString(stack.Peek()) != Convert.ToString(str_char[counter]))
                        is_balanced = false;
                    else
                        stack.Pop();
                }
                counter++;
            }
            if (stack.IsEmpty())
                return is_balanced;
            else
                return false;

        }

        public static long SubstringCount(string main_string,string substring)
            //Question 5
        {
            long count = 0;
            bool has_substring = true;

            while (has_substring)
            {
                int index = main_string.IndexOf(substring);
                if (index==-1)
                {
                    has_substring = false;
                    break;
                }
                else

                {
                    
                    count++;
                    Console.WriteLine("main string before change: {0}", main_string);
                    Console.WriteLine("Subtring Lenght: {0}, Substring start:{1} ,substring End:{2} ", substring.Length, index,index + substring.Length);
                    Console.WriteLine("Substring: {0}",main_string.Substring(index, substring.Length));
                    main_string = main_string.Remove(index, substring.Length);
                    Console.WriteLine("Count: {0}, Index:{1}", count, index);
                    Console.WriteLine("main string after change: {0}",main_string);
                }
            }
            return count;
        }

        public static string UpperCase(string input_string)
            //Question 6 
        {
            StringBuilder output_string = new StringBuilder(input_string);
            bool has_upper = true;
        
            while(has_upper)
            {
                int start=input_string.IndexOf("<upcase>");
                Console.WriteLine(start);
                int end = input_string.IndexOf("</upcase>");
                break;
            }
            //output_string.Replace(input_string.Substring(0,12),"name is face");

            return output_string.ToString();

        }

    }
}
