using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_4
{
    internal static class Say
    {
        public static string SayHello(this string name)
        {
            return ($"Hello, {name}!");
        }

        public static string SayGoodbye(this string name)
        {
            return String.Format("Goodbye, {0}. See you again soon!", name);
        }
    }
}
