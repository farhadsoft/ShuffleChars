using System;
using System.Collections.Generic;
using System.Text;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentException">Source string is null or empty or white spaces.</exception>
        /// <exception cref="ArgumentException">Count of iterations less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"Source string is null or empty or white spaces. {nameof(source)}");
            }

            if (count <= 0)
            {
                throw new ArgumentException("Count of iterations less than 0.");
            }

            int index = 0;
            string result = source;
            int length = source.Length;
            List<string> strList = new List<string>();
            StringBuilder evenChar = new StringBuilder((length / 2) + 1);
            StringBuilder oddChar = new StringBuilder((length / 2) + 1);

            for (int a = 0; a < count; a++)
            {
                if (index == 0)
                {
                    for (int i = 0; i < length; i += 2)
                    {
                        evenChar.Append(result[i]);
                        if (i + 1 < length)
                        {
                            oddChar.Append(result[i + 1]);
                        }
                    }

                    result = string.Concat(evenChar.ToString(), oddChar.ToString());
                    evenChar.Clear();
                    oddChar.Clear();
                    strList.Add(result);
                }
                else
                {
                    int needed = a % (index + 1);
                    result = strList[needed];
                }

                if (index == 0 && result == source)
                {
                    index = a;
                }
            }

            return result;
        }
    }
}
