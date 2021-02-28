using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestingAssignment
{
    public static class AssignmentBLL
    {
        public static int WordCount(String input)
        {
            int ln = input.Length;
            String[] words = input.Split(' ');

            return words.Length;
        }

        public static bool NumberValidation(String input)
        {
            int n;
            bool isNumeric = int.TryParse(input, out n);
            return isNumeric;
        }

        public static String AddLowerCase(String input)
        {
            StringBuilder str = new StringBuilder(input);
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    str[i] = (char)(str[i] + 32);
            }
            return str.ToString();
        }

        public static String AddUpperCase(String input)
        {
            StringBuilder str = new StringBuilder(input);
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                    str[i] = (char)(str[i] - 32);
            }
            return str.ToString();
        }

        public static bool CheckLowerCase(String str)
        {
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckUpperCase(String str)
        {
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    return false;
                }
            }
            return true;
        }

        public static string FirstUpperLetter(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static String LastCharacterRemove(String str)
        {
            if (str == null)
                return null;
            else
                return str.Substring(0, str.Length - 1);
        }

        public static int StringToInt(String input)
        {
            int x = 0;

            Int32.TryParse(input, out x);
            return x;
        }
    }
}
