using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Common
{
    public static class Numerology
    {
        public static int TruncateLeft(int number)
        {
            return number % (int)Math.Pow(10, (int)Math.Log10(number));
        }

        public static bool IsPandigital(int number)
        {
            if(number % 9 != 0) return false; //all 1..9 pandigitals are divisible by 9
            return IsPandigital(number.ToString());
        }

        public static bool IsPandigital(string number)
        {
            var digits = number.ToCharArray();
            Array.Sort(digits);
            string s = new string(digits);
            return s.Equals("123456789");
        }

        public static bool HasEvenDigits(int number)
        {
            while (number > 0) {
                if (number % 2 == 0) return true;
                number /= 10;
            }
            return false;
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;
            char temp;
            temp = a;
            a = b;
            b = temp;
        }

        public static List<string> Permutations(string s)
        {
            var result = new List<string>();
            char[] characters = s.ToCharArray();
            GetPer(characters, 0, characters.Length - 1, ref result);
            return result;
        }

        private static void GetPer(char[] s, int k, int m, ref List<string> result)
        {
            if (k == m)
            {
                result.Add(new string(s));
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref s[k], ref s[i]);
                    GetPer(s, k + 1, m, ref result);
                    Swap(ref s[k], ref s[i]);
                }
        }
        public static int FirstDigit(int number) {
            while (number > 10) {
                number /= 10;
            }
            return number;
        }

        public static bool IsPalindromic(int number) {
            return number == Reverse(number);
        }

        public static int Reverse(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result = result * 10 + number % 10;
                number /= 10;
            }
            return result;
        }

        public static int LastDigit(int number)
        {
            return number % 10;
        }

        public static bool IsPalindromic_simple(string s)
        {
            char[] c = s.ToCharArray();

            Array.Reverse(c);
            string s2 = new string(c);
            return s.Equals(s2);
        }
        public static bool IsPalindromic(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) return false;
            }
            return true;
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b, a % b);
            }
        }

        public static bool IsHexagonal(long x) {
            // x = n(2n-1)
            // 2n^2 - n - x == 0
            double n = (1 + Math.Sqrt(1 + 8 * x)) / 4;
            return n%1 == 0;
        }

        public static bool IsPentagonal(long x)
        {
            // x = n(3n-1)/2
            // (3/2)n^2 - (1/2)n - x == 0
            // n = (1/6) * (sqrt(24x + 1) + 1)
            double n = (Math.Sqrt(24 * x + 1) + 1)/6;
            return n % 1 == 0;
        }

        public static bool IsTriangle(long x)
        {
            // n = (1/2) * (sqrt(8x+1) - 1)
            double n = (Math.Sqrt(8 * x + 1) - 1) / 2;
            return n % 1 == 0;
        }
    }
}
