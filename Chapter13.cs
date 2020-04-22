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
//def Upcase(input_string):
//    output_string = input_string.split("<upcase>")
//    for index,word in enumerate(output_string, start= 0) :
//        closing_tag_index=word.find("</upcase>")
//        if closing_tag_index>-1:
//            try:
//                output_string[index]=word[:closing_tag_index].upper() + word[closing_tag_index + 9:]
//            except IndexError:
//                output_string[index]=word[:closing_tag_index].upper()
//    return str.join(" ",output_string).replace("</upcase>",'')
        public static string UpCase(string input_string)
            //Question 6 
        {
            string[] output_string = input_string.Split("<upcase>");
            int closing_tag_count = 0;
            
            for (int index=0;index<output_string.Length;index++)
            {
                int closing_tag_index = output_string[index].IndexOf("</upcase>");
                if (closing_tag_index>-1)
                {
                    closing_tag_count++;
                    try
                    {
                        int backstring_start = closing_tag_index + 9;
                        string word = output_string[index];
                        int size = word.Length - 1;
                        Console.WriteLine("back string: {0}",word.Substring(backstring_start, output_string[index].Length - 1)); //correct this bug/
                        output_string[index] = output_string[index].Substring(0, closing_tag_index).ToUpper() +
                            output_string[index].Substring(11, output_string[index].Length - 1);
                      
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        output_string[index] = output_string[index].Substring(0, closing_tag_index).ToUpper();
                    }
                }
            }
            
            if (closing_tag_count != output_string.Length-1)
            {
                //number opening and closing tags do not match
                return Convert.ToString(-1);
            }
            else
                return String.Join(' ', output_string);

        }


        public static bool IsPalindrome(string input_string)
        {
            string reverse_string = "";
            for (int index=0;index< input_string.Length; index++)
            {
                reverse_string = reverse_string + input_string[input_string.Length - 1-index];
            }
            Console.WriteLine("string : {0} , reversed_string: {1}, last index: {2}", input_string, reverse_string, input_string.Length - 1);
            if (reverse_string.ToLower() == input_string.ToLower())
            {
                return true;
            }
            else
                return false;
        }

        public static string GetPalindromes(string input_string)
            //Question 21
        {
            string palindrome = "";
            foreach(string value in input_string.Split())
            {
                if (IsPalindrome(value))
                { palindrome=palindrome + value + " "; }
            }
            return palindrome;
        }

    }
}
