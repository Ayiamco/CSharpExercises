using System;
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
        
    }
}
