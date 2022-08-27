using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMExtension.Xamarin
{
    public static class AdditionalStrings
    {
        /// <summary>
        /// Return a reversed string
        /// </summary>
        /// <param name="InputString"></param>
        /// <returns></returns>
        public static string Reverse(String InputString)
        {
            string ReturnString = "";
            for (int i = InputString.Length - 1; i >= 0; i--)
            {
                ReturnString += InputString[i];
            }

            return ReturnString;
        }

        /// <summary>
        /// Converts integer numbers to string and place zeros befor or after it. 
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="TotalLenght">Your number digit count plus zero count</param>
        /// <param name="After">If true, zero(s) will place after the number</param>
        /// <returns></returns>
        public static string CompleteNumber(int Number, int TotalLenght, bool After = false)
        {
            string Answer = Number.ToString();

            if (After)
            {
                while (Answer.Length < TotalLenght)
                {
                    Answer += "0";
                }
            }
            else
            {
                while (Answer.Length < TotalLenght)
                {
                    Answer = Answer.Insert(0, "0");
                }
            }
            return Answer;
        }

        public static string Capital(string InputString)
        {
            int TotalLength = InputString.Length;
            string FirstChar = InputString.Substring(0, 1);
            string RemainSting = InputString.Substring(1, TotalLength - 1);
            FirstChar = FirstChar.ToUpper();

            return FirstChar + RemainSting;
        }

        /// <summary>
        /// Removes a special character from hole string and return new string
        /// </summary>
        /// <param name="InputString"></param>
        /// <param name="BadChar">Character to remove</param>
        /// <returns>String</returns>
        public static string Remove(string InputString, char BadChar)
        {
            try
            {
                while (InputString.Contains(BadChar))
                {
                    int index = InputString.IndexOf(BadChar);
                    InputString = InputString.Remove(index, 1);
                }
                return InputString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string NumberFormat(UInt64 Number)
        {
            return string.Format(new System.Globalization.CultureInfo("fa-IR"), "{0:N0}", Number);
        }

        public static string NumberFormat(long Number)
        {
            return string.Format(new System.Globalization.CultureInfo("fa-IR"), "{0:N0}", Number);
        }

        public static string NumberFormat(double Number)
        {
            return string.Format(new System.Globalization.CultureInfo("fa-IR"), "{0:N0}", Number);
        }

        public static string NumberFormat(Int32 Number)
        {
            return string.Format(new System.Globalization.CultureInfo("fa-IR"), "{0:N0}", Number);
        }

        public static string NumberFormat(Int16 Number)
        {
            return string.Format(new System.Globalization.CultureInfo("fa-IR"), "{0:N0}", Number);
        }
    }
}
