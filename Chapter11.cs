﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Chapter11
    {
        public static bool isLeap(string year)
        //Question 1
        {
            int index_a = year.Length - 1;
            int index_b = year.Length - 2;
            Console.WriteLine("index_a: " + index_a + ",  index_b: " + index_b);

            string value = Convert.ToString(year[index_b]) + year[index_a];
            Console.WriteLine(value);
            long day = Convert.ToInt64(value);
            Console.WriteLine(day);
            if (day % 4 == 0)
            {
                return true;
            }
            else { return false; }
        }

        public static double GetTriangleArea(double side_a = -1.0,double side_b=-1.0,double altitude=-1.0,double angle=-1.0)
        {
            double area = 0;
            if (angle >= 180)
            {
                Console.WriteLine("Angle cannot be greater or Equal to 180");
                return 0.0;
            }
            else
            {
                if (side_a != -1.0 && side_b != -1.0 && altitude != -1.0)
                {
                    double s = (side_a + side_b + altitude) / 2.0;
                    area = Math.Sqrt(s * (s - side_a) * (s - side_b) * (s - altitude));
                }
                else if ((side_a != -1.0 && side_b == -1.0 && altitude != -1.0))
                {
                    area = 0.5 * side_a * altitude;
                }
                else if (side_a == -1.0 && side_b != -1.0 && altitude != -1.0)
                {
                    area = 0.5 * side_b * altitude;
                }
                else if (angle > 0.0 && altitude == -1.0) 
                {
                    altitude = Math.Sqrt(Math.Pow(side_a, 2.0) + Math.Pow(side_b, 2.0)- 2 * side_b * side_a * Math.Sin(angle));
                    Console.WriteLine(Convert.ToString(altitude));
                    double s = (side_a + side_b + altitude) / 2.0;
                    area = Math.Sqrt(s * (s - side_a) * (s - side_b) * (s - altitude));
                }

                 return area;
            }
           
        }
        public static void GetAdvertisement()
        //Question 11
        {
            string[] Laudatory_phrases = { "The product is excellent.",
                "This is a great product.", "I use this product constantly.",
                "This is the best product from this category."};
            string[] Laudatory_stories ={ "Now I feel better.",
                "I managed to change.", "It made some miracle.",
                "I can’t believe it, but now I am feeling great.",
                    "You should try it, too. I am very satisfied."};
            string[] First_name = { "Dayan", "Stella", "Hellen", "Kate" };
            string[] Last_name = { "Johnson", "Peterson", "Charls", "okon" };
            string[] Cities = { "London", "Paris", "Berlin", "New York", "Madrid" };
            Random index = new Random();

            Console.WriteLine(Laudatory_phrases[index.Next(4)] + " " + Laudatory_stories[index.Next(5)] + " --" + First_name[index.Next(4)]
                + " " + Last_name[index.Next(4)] + " " + Cities[index.Next(5)]);
        }


        static int GetDayCount(string end_date_string)
        //Question 9
        {
            int count = 0;
            try
            {
                DateTime current_date = DateTime.Today;
                DateTime end_date_datetime = Convert.ToDateTime(end_date_string);
                TimeSpan time_span = end_date_datetime.Subtract(DateTime.Today);
                string[] time_span_array = Convert.ToString(time_span).Split(":");
                time_span_array = time_span_array[0].Split(".");
                long no_of_days = Convert.ToInt64(time_span_array[0]);
                for (int counter = 0; counter < no_of_days; counter++)
                {
                    count++;
                    current_date = current_date.AddDays(1);
                    if (Convert.ToString(current_date.DayOfWeek) == "Saturday" || Convert.ToString(current_date.DayOfWeek) == "Sunday")
                    {
                        count--;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Input In wrong Format");

            }

            return count;
        }
        
        
        class ShunttingYard
        {
            Queue output_queue = new Queue();
            Stack operator_stack = new Stack();


            Dictionary<string, int> operator_precedence = new Dictionary<string, int>();

            public ShunttingYard()
            {
                operator_precedence.Add("^", 5);
                operator_precedence.Add("/", 4);
                operator_precedence.Add("*", 3);
                operator_precedence.Add("+", 2);
                operator_precedence.Add("-", 1);
                operator_precedence.Add("(", 6);

            }

            public string PostFix(string infix)
            {
                Exception e = new Exception(" Mathematical Expression Contains invalid Characters ");
                List<object> infix_list = new List<object>();
                bool is_same_digit = true;
                string digit = "";
                int index_count = 0;
                foreach (char item in infix)
                {
                    index_count++;
                    if ("1234567890".Contains(item))
                    {
                        digit = digit + Convert.ToString(item);
                        if (index_count == infix.ToCharArray().Length)
                        {
                            infix_list.Add(digit);
                        }
                    }
                    else if ("*^()/-+".Contains(item))
                    {
                        if (digit != "")
                            infix_list.Add(digit);
                        infix_list.Add(item);
                        digit = "";
                    }
                    else
                    { throw e; }
                }

                foreach (object value in infix_list)
                {
                    if ("^()*/-+".Contains(Convert.ToString(value)))
                    {
                        if (operator_stack.IsEmpty())
                        {
                            operator_stack.Push(value);
                        }
                        else
                        {

                            if ("(".Contains(Convert.ToString(value)))
                            {
                                operator_stack.Push(value);
                            }
                            else if (")".Contains(Convert.ToString(value)))
                            {

                                while (Convert.ToString(operator_stack.Peek()) != "(")
                                {
                                    output_queue.Enqueue(operator_stack.Pop());
                                }
                                operator_stack.Pop();
                            }
                            else
                            {
                                if (operator_precedence[Convert.ToString(operator_stack.Peek())] >
                                operator_precedence[Convert.ToString(value)])
                                //new item has greater precedence that item at top of stack
                                {
                                    while (operator_precedence[Convert.ToString(operator_stack.Peek())] >
                                            operator_precedence[Convert.ToString(value)])
                                    {
                                        if (Convert.ToString(operator_stack.Peek()) == "(")
                                        {
                                            operator_stack.Push(value);
                                            break;
                                        }
                                        else
                                        {
                                            output_queue.Enqueue(operator_stack.Pop());
                                            operator_stack.Push(value);
                                        }
                                    }
                                }
                                else
                                {
                                    operator_stack.Push(value);
                                }
                            }
                        }
                    }
                    else
                    {
                        output_queue.Enqueue(value);
                    }
                }

                while (operator_stack.Size() != 0)
                {
                    output_queue.Enqueue(operator_stack.Pop());
                }
                string postfix = "";
                while (output_queue.Size() != 0)
                {
                    postfix = postfix + Convert.ToString(output_queue.Dequeue()) + " ";
                }
                return postfix;

            }

            private static string GetEval(string postfix_string)
            {
                Console.WriteLine("GetEval Postfix: " + postfix_string);
                string output_string = "";
                string[] postfix_ = postfix_string.Split(" ");
                List<string> postfix_array = new List<string>(postfix_);
                string my_operator = "";
                long item_1 = 0;
                long item_2 = 0;
                long ans = 0;
                int operator_index = new int();

                for (int counter = postfix_array.Count - 1; counter == 2; counter--)
                {
                    if ("/*^+-".Contains(postfix_array[counter]))

                    {
                        try
                        {

                            item_1 = Convert.ToInt64(postfix_array[counter - 1]);
                            item_2 = Convert.ToInt64(postfix_array[counter - 2]);
                            my_operator = Convert.ToString(postfix_array[counter]);
                            operator_index = Convert.ToInt32(counter - 2);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Condition Not MET:");

                        }

                    }

                }

                Console.WriteLine("PostFix Array after remove: " + String.Join(" ", postfix_array));
                if (my_operator == "*")
                { ans = item_1 * item_2; }

                else if (my_operator == "/")
                { ans = item_1 * item_2; }

                else if (my_operator == "-")
                { ans = item_1 - item_2; }

                else if (my_operator == "+")
                { ans = item_1 + item_2; }

                else if (my_operator == "^")
                { ans = item_1 ^ item_2; }

                Console.WriteLine("MY ans= " + Convert.ToString(ans));
                Console.WriteLine("PostFix Array before removal: " + String.Join(" ", postfix_array));
                postfix_array[operator_index] = Convert.ToString(ans);
                Console.WriteLine("PostFix Array before removal1: " + String.Join(" ", postfix_array));
                postfix_array.RemoveAt(operator_index + 1);
                Console.WriteLine("PostFix Array before remova2: " + String.Join(" ", postfix_array));
                postfix_array.RemoveAt(operator_index + 1);

                output_string = String.Join(" ", postfix_array);
                Console.WriteLine("GetEval output_string= " + Convert.ToString(output_string));
                return output_string;

            }


            public long Calculate(string postfix)
            {
                long ans = 0;
                postfix = PostFix(postfix);
                Console.WriteLine("PostFix Output: " + postfix);
                while (postfix.Split(" ").Length > 1)
                {
                    try
                    {
                        ans = Convert.ToInt64(postfix);
                        break;
                    }
                    catch
                    {
                        postfix = GetEval(postfix);
                    }

                }
                ans = Convert.ToInt64(postfix);
                return ans;
            }
        }
    }

}
}
