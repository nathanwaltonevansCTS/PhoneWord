using System.Text;

namespace Core
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
        {
            //if nothing is inputted it ignores it
            if (string.IsNullOrWhiteSpace(raw))
                return null;
            //all the characters in the string are changed to the upper case variant
            raw = raw.ToUpperInvariant();
            //creates a blank string to save the final phoneword to
            var newNumber = new StringBuilder();
            //loops through the inputted phoneword to see if there is a number 
            //and adds it directly to the blank string
            foreach (var c in raw)
            {
                if (" -0123456789".Contains(c))
                    newNumber.Append(c);
                else
                {
                    //this decides if there is something over than a number or letter 
                    //in the phoneword for example a "!" which would be return as nothing
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                    // Bad character?
                    else
                        return null;
                }
            }
            //returns the completed translated number
            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }
        //splits the alphabet into the respective groups 
        //in which numbers are assigned to it
        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        // loops through the string to see if there is a character in the string,
        //if there is a character in it, that character is replaced with 2 more 
        //than the current letter group starting from 0 when looping
        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}