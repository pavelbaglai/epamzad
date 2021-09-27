using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2
{
    public class FindUniqChar
    {
        public static string Exec(string a, string b)
        {
            return new String(String.Concat(a + b).Select(x => x).OrderBy(x=>x).Distinct().ToArray());
        }
        
    }
}
