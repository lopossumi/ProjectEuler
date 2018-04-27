using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ProjectEuler.Common.Numerology;

namespace ProjectEuler.Problems
{

    public class Euler042 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            string[] words;
            int count = 0;
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\p042_words.txt");

            using (TextFieldParser csvParser = new TextFieldParser(filePath))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                words = csvParser.ReadFields();
            }

            HashSet<int> triangles = new HashSet<int>();
            for (int i = 0; i < 1000; i++)
            {
                triangles.Add(i * (i + 1) / 2);
            }

            foreach (string item in words)
            {
                char[] word = item.ToCharArray();

                int sumOfChars = 0;
                foreach (char letter in word)
                {
                    sumOfChars += letter - 'A' + 1;
                }
                if (triangles.Contains(sumOfChars))
                {
                    count++;
                }
            }

            return count;
        }
    }
}


