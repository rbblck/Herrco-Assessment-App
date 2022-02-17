using System;
namespace HerrcoApp.Classes
{
    public class HelperClass
    {
        /// <summary>
        /// Coverts an int to a string safely.
        /// </summary>
        /// <param name="numberStr">The number string.</param>
        /// <returns>int</returns>
        public int ConvertIntToStr(string numberStr)
        {
            int num;

            try
            {
                num = Int32.Parse(numberStr);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{numberStr}'");
                num = -1;
            }

            return num;
        }

    }
}
