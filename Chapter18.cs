using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.IO;

namespace Practice
{
    class Chapter18
    {

        internal static void GetCount(params int[] intArray)
        //question 1.
        {
            Dictionary<int, int> myStorage = new Dictionary<int, int>();

            foreach (int item in intArray)
            {
                if (myStorage.ContainsKey(item))
                    myStorage[item] = myStorage[item] + 1;
                else
                    myStorage[item] = 1;
            }
            string displayString = "";
            foreach (int item in myStorage.Keys)
            {
                displayString = displayString + $"{Convert.ToString(item)} =>{ Convert.ToString(myStorage[item])}times, ";
            };
            Console.WriteLine(displayString);
        }

        internal static void RemoveOddFrequency(params int[] intArray)
        //question 2.
        {
            Dictionary<int, int> myStorage = new Dictionary<int, int>();

            foreach (int item in intArray)
            {
                if (myStorage.ContainsKey(item))
                    myStorage[item] = myStorage[item] + 1;
                else
                    myStorage[item] = 1;
            }
            List<int> returnArray = new List<int>();
            foreach (int Key in intArray)
            {
                if (myStorage[Key] % 2 == 0)
                    returnArray.Add(Key);
            }
            Console.WriteLine($"{{{String.Join(',', returnArray)}}}");

        }
        internal static void GetWordCount(string textFile) { 
            string text = File.ReadAllText($"../../../{textFile}");
            Console.WriteLine(text);
        }
    }
}
