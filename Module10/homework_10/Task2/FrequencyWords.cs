using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace homework_10.Task2
{
    public static class FrequencyWords
    {
        public static Dictionary<string,int> Exec(string filename)
        {
            if (filename==null) throw new FileNotFoundException();
            string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Task2\"+filename);
            string str = null;
            try
            {
                str = File.ReadAllText(filepath);
            }
            catch(FileNotFoundException)
            {
                throw new FileNotFoundException();
            }

            string[] words = str.Split(' ');

            var dict = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var word in words)
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict[word] = 1;

            return dict.Where(x=>x.Value>1).ToDictionary(x=>x.Key,x=>x.Value);
        }
    }
}