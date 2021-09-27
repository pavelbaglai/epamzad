using System;
using System.Linq;

namespace homework_7.Task2
{
    public static class TitleCase
    {
        public static string Exec(string str, string strpas=null)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentOutOfRangeException(nameof(str));

            var wordsList = str.Split(new[] { " "}, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < wordsList.Length; i++)
            {
                if (string.IsNullOrEmpty(strpas) || strpas.IndexOf(wordsList[i])<=-1||i==0)
                { 
                    var word = wordsList[i];
                        wordsList[i] = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
                }
            }

            return string.Join(" ", wordsList);
        }
    }
}