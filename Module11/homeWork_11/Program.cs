using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_11
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var list = CsvReader.Exec("StudentMark.csv");
            foreach (var student in list){Console.WriteLine(student);}
            // 0- name, 1- lesson, 2- start date, 3- end date, 4- min mark, 5- max mark, 6- quanity
            foreach (var result in Query.QueryFilter(list, new Filter("-Ivan D -English -20150101 -20180101 -2 -8 -1")))
            {
                Console.WriteLine(result);    
            }
            Console.ReadKey();
        }
    }
}
