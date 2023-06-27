using System;

namespace PasswordChecker
{
    public static class SafenessChecker
    {
        private static bool HaveDigits(string str)
        {
            foreach(char c in str)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HaveSpecialSymbols(string str)
        {
            foreach (char c in str)
            {
                if (c == '@' || c == '/' || c == '#' || c == '*' || c == '$')
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HaveCapitals(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HaveLower(string str)
        {
            foreach (char c in str)
            {
                if (char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static int CheckSafeness(string password)
        {
            int safenessLevel = 0;

            if (HaveDigits(password) == true)
            {
                safenessLevel++;
            }

            if (HaveSpecialSymbols(password) == true) 
            {
                safenessLevel++;
            }

            if (HaveLower(password) == true && HaveCapitals(password) == true)
            {
                safenessLevel++;
            }
            return safenessLevel;
        }
    }
}
