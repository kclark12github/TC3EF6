using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Base
{
    /// <summary>
    ///  String Extension functions, many approximating those available in Visual Basic.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method that works out if a string is all digits
        /// </summary>
        /// <param name="value">string that may be all digits</param>
        /// <returns>true if all digits</returns>
        public static bool IsAllDigits(this String value) => value.All(Char.IsDigit);
        /// <summary>
        /// Extension method that works out if a string is numeric
        /// </summary>
        /// <param name="value">string that may be a number</param>
        /// <returns>true only if numeric</returns>
        public static bool IsNumeric(this String value)
        {
            return (Double.TryParse(value, out double myNum));
        }
        /// <summary>Returns a string containing a specified number of characters from the left side of a string.</summary>
        /// <param name="value">Required. String expression from which the leftmost characters are returned.</param>
        /// <param name="length">Required. Integer expression. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in value, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the left side of a string.</returns>
        /// <exception cref="System.ArgumentException">MaxLength < 0.</exception>
        public static string Left(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return value;
            length = Math.Abs(length);
            return (value.Length <= length ? value : value.Substring(0, length));
        }
        /// <summary>Returns a string containing a specified number of characters from the right side of a string. </Summary>
        /// <param name="value">Required. String expression from which the rightmost characters are returned.</param>
        /// <param name="length">Required. Integer. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in str, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the right side of a string.</returns>
        /// <exception cref="System.ArgumentException">length < 0.</exception>
        public static string Right(this string value, int length) {
            if (string.IsNullOrEmpty(value)) return value;
            length = Math.Abs(length);
            return (value.Length <= length ? value : value.Substring(value.Length - length, length));
        }
        public static string TrimTabs(this string value)
        {
            string retval = null;
            retval = value.Trim();
            while (retval.StartsWith("\t")) {
                retval = retval.Substring(1);
            }
            while (retval.EndsWith("\t")) {
                retval = retval.Substring(0, retval.Length - 1);
            }
            return retval;
        }
        /// <summary>Parses a given string by delimiter</summary>
        /// <param name="Source">String to work on</param>
        /// <param name="Delimiter">Token delimiter</param>
        /// <param name="Encapsulator">Optional: Allows for tokens to return strings encapsulated with "Delimiter" characters</param>
        /// <returns>Returns string array</returns>
        public static string[] Parse(this string Source, string Delimiter, string Encapsulator = "")
        {
            char ctrlA = (char)1;
            string[] delim = new string[] { Delimiter };
            if (string.IsNullOrEmpty(Source)) throw new ArgumentException("Work string must be specified.");
            if (string.IsNullOrEmpty(Delimiter)) throw new ArgumentException("Delimiter must be specified.");
            if ((Encapsulator == null)) Encapsulator = string.Empty;

            if (Delimiter.Length > 1 || (Encapsulator.Length > 0 && Source.IndexOf(Encapsulator) > -1)) {
                //Strategy: Replace all occurrences of Delimiter (not encapsulated by Encapsulator) with a
                //          substitute delimiter which can be later used in a String.Split operation.
                int cntEncap = 0;
                delim = new string[] { ctrlA.ToString() };
                int sPos = 0;
                while (sPos < Source.Length) {
                    if (sPos + Encapsulator.Length < Source.Length && Encapsulator.Length > 0 && Source.Substring(sPos, Encapsulator.Length) == Encapsulator) {
                        cntEncap += 1;
                        sPos += Encapsulator.Length;
                    } else if (sPos + Delimiter.Length < Source.Length && Source.Substring(sPos, Delimiter.Length) == Delimiter && cntEncap % 2 == 0) {
                        Source = string.Format("{0}{1}{2}", Source.Substring(0, sPos), delim[0], Source.Substring(sPos + Delimiter.Length));
                        sPos += delim.Length;
                    } else {
                        sPos += 1;
                    }
                }
            }
            return Source.Split(delim, StringSplitOptions.RemoveEmptyEntries);
        }
        /// <summary>Retrieve specified token of string</summary>
        /// <param name="Source">String to work on</param>
        /// <param name="TokenNum">Returns specified token in string</param>
        /// <param name="Delimiter">Token delimiter</param>
        /// <param name="Encapsulator">Optional: Allows for tokens to return strings encapsulated with "Delimiter" characters</param>
        /// <param name="Preserve">Optional: Preserves encapsulating characters when token is encapsulated</param>
        /// <returns>Returns string token.  If none is found, will return ""</returns>
        public static string Parse(this string Source, int TokenNum, string Delimiter, string Encapsulator = "", bool Preserve = false)
        {
            string retval = string.Empty;
            if (TokenNum < 1)
                throw new ArgumentException("TokenNum must be greater than zero.");
            string[] Tokens = Source.Parse(Delimiter, Encapsulator);
            if (TokenNum <= Tokens.Length)
                retval = Tokens[TokenNum - 1];
            if (!Preserve && Encapsulator.Length > 0 && retval.StartsWith(Encapsulator) && retval.EndsWith(Encapsulator))
                retval = retval.Substring(1, retval.Length - 2);
            return retval;
        }
        /// <summary>Counts number of tokens in a string</summary>
        /// <param name="Source">String to work on</param>
        /// <param name="Delimiter">String Delimiter</param>
        /// <param name="Encapsulator">Optional: Allows for tokens to return strings encapsulated with "strDelimiter" characters</param>
        /// <returns>Number of tokens found</returns>
        public static int Tokens(this string Source, string Delimiter, string Encapsulator = "")
        {
            int retval = 0;
            if ((Source == null) || Source.Length == 0) return 0;
            if ((Delimiter == null) || Delimiter == string.Empty) return 0;
            if ((Encapsulator == null)) Encapsulator = string.Empty;

            string[] Tokens = Source.Parse(Delimiter, Encapsulator);
            retval = Tokens.Length;
            bool continueLoop = true;
            for (int i = Tokens.GetUpperBound(0); i >= 0 && continueLoop; i += -1) {
                if (Tokens[i].Length == 0)
                    retval -= 1;
                else
                    continueLoop = false;
            }
            return retval;
        }
    }
}
