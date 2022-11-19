using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HiTechManagement.Validator
{
    internal class Validator
    {
        // User ID: 4-digit number
        public static bool IsValidId(string input)
        {

            if (!(Regex.IsMatch(input, @"^\d{4}$")))
            {
                return false;

            }
            return true;
        }
        // Valid user name
        public static bool IsValidName(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((!Char.IsLetter(input[i])) && (!Char.IsWhiteSpace(input[i])))

                {

                    return false;

                }

            }
            return true;
        }

        // student ID : 7-digit number
        public static bool IsValid(string input)
        {
            if (input.Length != 4)
            {
                return false;
            }
            else // 7 : 1234abc/ abc1234/
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(Char.IsDigit(input[i])))
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public static bool IsValidID(string input)
        {
            if (input.Length != 7)
            {
                return false;
            }
            else // 7 : 1234abc/ abc1234/
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(Char.IsDigit(input[i])))
                    {
                        return false;
                    }

                }
            }
            return true;
        }



    }
}
